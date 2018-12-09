using System.Collections.Generic;
using QuizEngine.Data.Entities;

namespace QuizEngine.Data.AbstractModels
{
    public abstract class QuizzesModel
    {
        public List<Quiz> PublishedQuizzes { get; set; }
        public string PlayerId { get; set; }
    }
}