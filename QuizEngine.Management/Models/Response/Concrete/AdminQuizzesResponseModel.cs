using System.Collections.Generic;
using QuizEngine.Data.Entities;
using QuizEngine.Data.AbstractModels;

namespace QuizEngine.Management.Models.Response.Concrete
{
    public class AdminQuizzesResponseModel : QuizzesModel
    {
        public List<Quiz> UnpublishedQuizzes { get; set; }
    }
}