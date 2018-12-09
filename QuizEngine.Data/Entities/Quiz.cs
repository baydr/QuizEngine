using System.Collections.Generic;
using QuizEngine.Data.Entities;

namespace QuizEngine.Data.Entities
{
    public class Quiz
    {
        public IList<Question> Questions { get; set; }
        public int LatestVersion { get; set; }
        public int CurrentVersion { get; set; }
        public string Id { get; set; }
    }
}