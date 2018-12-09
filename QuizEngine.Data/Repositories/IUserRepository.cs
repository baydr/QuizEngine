using QuizEngine.Data.Entities;

namespace QuizEngine.Data.Repositories
{
    public interface IUserRepository
    {
        User Get(string username);
    }
}