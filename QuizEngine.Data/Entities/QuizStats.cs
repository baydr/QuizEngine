using System.Collections.Generic;

namespace QuizEngine.Data.Entities
{
    public class QuizStats
    {
        public IList<int> PlayerCountPerBracket { get; set; }
        public int TotalPlayers { get; set; }
    }
}