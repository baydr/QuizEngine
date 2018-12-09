using System.Collections.Generic;
using QuizEngine.Data.Entities;
using QuizEngine.Data.Repositories;

namespace QuizEngine.Data.Repositories.Concrete
{
    public class QuizRepository : IQuizRepository
    {
        public void Create(string publishedQuizId, Quiz quiz)
        {
            throw new System.NotImplementedException();
        }
        
        public void Delete(string quizId)
        {
            throw new System.NotImplementedException();
        }

        public Quiz Get(string quizId)
        {
            // Get the quiz

            // return quiz;

            throw new System.NotImplementedException();
        }

        public List<Quiz> GetPublished(string userId = null)
        {
            var quizzes = new List<Quiz>();

            // Get the published quizzes returning the name of the quiz and published datetime only return where version is not 0

            return quizzes;
        }

        public List<Quiz> GetUnpublished()
        {
            var quizzes = new List<Quiz>();

            // Get the unpublished quizzes returning the name of the quiz and published datetime only

            return quizzes;
        }

        public void Save(Quiz quiz)
        {
            throw new System.NotImplementedException();
        }
    }
}