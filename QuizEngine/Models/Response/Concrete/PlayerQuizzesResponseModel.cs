using System.Collections.Generic;
using QuizEngine.Data.AbstractModels;
using QuizEngine.Data.Entities;

namespace QuizEngine.Models.Response.Concrete
{
    public class PlayerQuizzesResponseModel : QuizzesModel
    {
        public List<Quiz> CompletedQuizzes { get; set; }
    }
}