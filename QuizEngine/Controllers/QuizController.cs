using Microsoft.AspNetCore.Mvc;
using QuizEngine.Data.Repositories;
using QuizEngine.Models.Response.Concrete;

namespace QuizEngine.Controllers
{
    public class QuizController : Controller
    {
        public QuizController(IQuizRepository quizRepository)
        {
            QuizRepository = quizRepository;
        }

        public IQuizRepository QuizRepository { get; }

        public IActionResult TakeQuiz(string quizId)
        {
            var quiz = QuizRepository.Get(quizId);

            // TODO: move this to model\utility\extension method
            QuizResponseModel quizResponseModel = new QuizResponseModel();
            quizResponseModel.Id = quiz.Id;
            quizResponseModel.Questions = quiz.Questions;
            quizResponseModel.CurrentVersion = quiz.LatestVersion;

            return View(quizResponseModel);
        }
    }
}