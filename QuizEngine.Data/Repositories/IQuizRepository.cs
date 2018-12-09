using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizEngine.Data.Entities;

namespace QuizEngine.Data.Repositories
{
    public interface IQuizRepository
    {
        List<Quiz> GetPublished(string userId = null);

        List<Quiz> GetUnpublished();

        Quiz Get(string quizId);

        void Delete(string quizId);

        void Create(string publishedQuizId, Quiz quiz);

        void Save(Quiz quiz);
    }
}
