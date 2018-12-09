using QuizEngine.Data.Entities;

namespace QuizEngine.Models.Response.Concrete
{
    internal class SummaryResultsResponseModel
    {
        public Result Result { get; set; }
        public QuizStats QuizStats { get; set; }
    }
}