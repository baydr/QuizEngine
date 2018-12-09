using System.Collections.Generic;

namespace QuizEngine.Data.Entities
{
    public class Player
    {
        public string Id { get; set; }
        public List<Quiz> CompletedQuizzes { get; set; }
    }
}