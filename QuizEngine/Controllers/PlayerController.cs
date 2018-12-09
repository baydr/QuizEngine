using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuizEngine.Data.Entities;
using QuizEngine.Data.Repositories;
using QuizEngine.Models;
using QuizEngine.Models.Response.Concrete;
using QuizEngine.Repositories;

namespace QuizEngine.Controllers
{
    public class PlayerController : Controller
    {
        public IQuizRepository QuizRepository { get; }
        public IPlayerRepository PlayerRepository { get; }
        public IResultRepository ResultRepository { get; }
        public IQuizStatsRepository QuizStatsRepository { get; }

        public PlayerController(IQuizRepository quizRepository, IPlayerRepository playerRepository, IResultRepository resultRepository, IQuizStatsRepository quizStatsRepository)
        {
            QuizRepository = quizRepository;
            PlayerRepository = playerRepository;
            ResultRepository = resultRepository;
            QuizStatsRepository = quizStatsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetPlayerQuizzes(string playerId)
        {
            var player = PlayerRepository.Get(playerId);
            
            var publishedQuizzes = QuizRepository.GetPublished();

            var quizIdsCompletedByPlayer = player.CompletedQuizzes.Select(y => y.Id);

            // TODO: need to review this
            var filteredPublishedQuizzes = publishedQuizzes.Where(x => !quizIdsCompletedByPlayer.Contains(x.Id));

            var model = new PlayerQuizzesResponseModel() { PlayerId = player.Id, PublishedQuizzes = publishedQuizzes, CompletedQuizzes = player.CompletedQuizzes };

            return View(model);
        }

        public IActionResult GetResult(string playerId, string QuizId)
        {
            var result = ResultRepository.Get(playerId, QuizId);

            // split this out into a utility class\model\extension method
            ResultResponseModel resultModel = new ResultResponseModel();
            resultModel.Quiz = result.Quiz;
            resultModel.Score = result.Score;
            resultModel.PercentageScore = result.PercentageScore;

            return View(resultModel);
        }

        public IActionResult SaveResult(string playerId, string quizId, Quiz playerAnswers)
        {
            #region validate the data

            if (string.IsNullOrWhiteSpace(playerId))
            {
                throw new ArgumentNullException(nameof(playerId));
            }

            if (string.IsNullOrWhiteSpace(quizId))
            {
                throw new ArgumentNullException(nameof(quizId));
            }

            if (playerAnswers == null)
            {
                throw new ArgumentNullException(nameof(playerAnswers));
            }

            #endregion

            // get the answers to the quiz
            var quiz = QuizRepository.Get(quizId);
            
            // Calculate the players score
            var playerQuizResult = CalculatePlayerQuizResult(quiz, playerAnswers);

            // Get the latest stats for that quiz
            var quizStats = QuizStatsRepository.Get(quizId);

            // Update the quiz stats with this result and save
            var updatedStats = UpdateQuizStats(quizStats, playerQuizResult.PercentageScore);
            QuizStatsRepository.Save(updatedStats);

            // Save the player's result
            ResultRepository.Save(playerId, JsonConvert.SerializeObject(playerQuizResult));

            // create the model
            var results = new SummaryResultsResponseModel { Result = playerQuizResult, QuizStats = updatedStats };

            // return the results
            return View(results);
        }

        private QuizStats UpdateQuizStats(QuizStats quizStats, int percentageScore)
        {
            var playerScoreInBracket = quizStats.PlayerCountPerBracket[(int)Math.Floor((double)percentageScore / 10)];

            playerScoreInBracket += 1;

            return quizStats;
        }

        private Result CalculatePlayerQuizResult(Quiz quiz, Quiz playerQuiz)
        {
            var result = new Result();
            foreach(var question in quiz.Questions)
            {
                result.Quiz = quiz;
                if (playerQuiz.Questions[question.Id].SelectedAnswer == question.CorrectAnswer)
                {
                    result.Score += 1;
                }
            }

            result.PercentageScore = result.Score / quiz.Questions.Count() * 100;

            return result;
        }
    }
}
