using QuizEngine.Data.Entities;

namespace QuizEngine.Models.Response.Concrete
{
    public class ResultResponseModel
    {
        public int Score { get; set; }
        public Quiz Quiz { get; set; }
        public int PercentageScore { get; set; }
    }
}
