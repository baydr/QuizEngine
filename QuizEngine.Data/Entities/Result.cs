using QuizEngine.Repositories;

namespace QuizEngine.Data.Entities
{
    public class Result
    {
        public int Score { get; set; }
        public Quiz Quiz { get; set; }
        public int PercentageScore { get; set; }
    }
}