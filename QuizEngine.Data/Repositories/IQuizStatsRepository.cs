using QuizEngine.Data.Entities;

namespace QuizEngine.Data.Repositories
{
    public interface IQuizStatsRepository
    {
        QuizStats Get(string quizId);
        void Save(QuizStats updatedStats);
    }
}
