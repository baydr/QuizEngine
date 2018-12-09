using QuizEngine.Data.Entities;

namespace QuizEngine.Data.Repositories
{
    public interface IResultRepository
    {
        Result Get(string userId, string quizId);
        void Save(string playerId, string quizResults);
    }
}