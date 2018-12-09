using System.Collections.Generic;
using QuizEngine.Data.Entities;

namespace QuizEngine.Data.Repositories
{
    public interface IQuestionRepository
    {
        IList<Question> GetAll();

        void Save(Question questionToSave);
    }
}