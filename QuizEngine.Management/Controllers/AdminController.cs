using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using QuizEngine.Data.Entities;
using QuizEngine.Data.Repositories;
using QuizEngine.Management.Models;
using QuizEngine.Management.Models.Response.Concrete;

namespace QuizEngine.Management.Controllers
{
    public class AdminController : Controller
    {
        public IUserRepository UserRepository { get; }
        public IQuizRepository QuizRepository { get; }
        public IQuestionRepository QuestionRepository { get; }

        public AdminController(IUserRepository userRepository, IQuizRepository quizRepository, IQuestionRepository questionRepository)
        {
            // TODO implement IoC container
            UserRepository = userRepository;
            QuizRepository = quizRepository;
            QuestionRepository = questionRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login(string username, string password)
        {
            // TODO: needs to be updated to latest techniques use a salt, move to db
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));

            var admin = UserRepository.Get(username);
            if (md5data.ToString() != admin.Password)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.Unauthorized);
            }

            var publishedQuizzes = QuizRepository.GetPublished();
            var unpublishedQuizzes = QuizRepository.GetUnpublished();

            var adminQuizzesModel = new AdminQuizzesResponseModel() { PublishedQuizzes = publishedQuizzes, UnpublishedQuizzes = unpublishedQuizzes };

            return View(adminQuizzesModel);
        }

        public IActionResult CreateQuiz()
        {
            // TODO: needs to be paged
            var questions = QuestionRepository.GetAll();

            var questionsResponseModel = new CreateQuizResponseModel();
            questionsResponseModel.Questions = questions;

            return View(questionsResponseModel);
        }

        public IActionResult EditQuiz(string quizId)
        {
            var quiz = QuizRepository.Get(quizId);

            var editQuizResponseModel = new EditQuizResponseModel();
            editQuizResponseModel.Quiz = quiz;
            
            var questions = QuestionRepository.GetAll();
            editQuizResponseModel.Questions = questions;

            return View(quiz);
        }

        public IActionResult SaveQuiz(Quiz quiz)
        {
            QuizRepository.Save(quiz);

            return View(quiz);
        }

        public IActionResult DeleteQuiz(string quizId)
        {
            QuizRepository.Delete(quizId);

            var publishedQuizzes = QuizRepository.GetPublished();
            var unpublishedQuizzes = QuizRepository.GetUnpublished();

            var adminQuizzesResponseModel = new AdminQuizzesResponseModel();
            adminQuizzesResponseModel.PublishedQuizzes = publishedQuizzes;
            adminQuizzesResponseModel.UnpublishedQuizzes = unpublishedQuizzes;

            return View(adminQuizzesResponseModel);
        }

        public IActionResult PublishQuiz(string quizId)
        {
            // get the unpublished quiz
            var quiz = QuizRepository.Get(quizId);

            // get the next version id to publish against
            var nextPublishedQuizId = GetNextPublishedQuizId(quiz);

            // add the quiz against the new id
            QuizRepository.Create(nextPublishedQuizId, quiz);

            // get the new list of published and unpublished quizzes
            var publishedQuizzes = QuizRepository.GetPublished();
            var unpublishedQuizzes = QuizRepository.GetUnpublished();

            var adminQuizzesModel = new AdminQuizzesResponseModel() { PublishedQuizzes = publishedQuizzes, UnpublishedQuizzes = unpublishedQuizzes };

            return View(adminQuizzesModel);
        }

        public IActionResult CreateQuestion(Question question)
        {
            return View();
        }

        public IActionResult SaveQuestion(Question question)
        {
            QuestionRepository.Save(question);

            var saveQuestionResponseModel = new SaveQuestionResponseModel();
            saveQuestionResponseModel.Question = question;

            return View(saveQuestionResponseModel);
        }

        private string GetNextPublishedQuizId(Quiz quiz)
        {
            return $"{quiz.Id}_{quiz.LatestVersion + 1}";
        }
    }
}
