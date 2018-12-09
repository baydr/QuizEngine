using System.Collections.Generic;
using QuizEngine.Data.Entities;

namespace QuizEngine.Management.Models.Response.Concrete
{
    internal class CreateQuizResponseModel
    {
        public IList<Question> Questions { get; set; }
    }
}