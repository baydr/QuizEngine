using System.Collections.Generic;
using QuizEngine.Data.Entities;

namespace QuizEngine.Models.Response.Concrete
{
    public class QuizResponseModel
    {
        public string Id { get; set; }
        public IList<Question> Questions { get; set; }
        public int CurrentVersion { get; set; }
    }
}
