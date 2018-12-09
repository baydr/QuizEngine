using System.Collections.Generic;
using QuizEngine.Data.Entities;

namespace QuizEngine.Management.Models.Response.Concrete
{
    internal class EditQuizResponseModel
    {
        public Quiz Quiz { get; set; }
        public IList<Question> Questions { get; set; }
    }
}