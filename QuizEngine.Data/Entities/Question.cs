using System.Collections.Generic;

namespace QuizEngine.Data.Entities
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> OtherAnswers { get; set; }
        public string SelectedAnswer { get; set; }
        public int Id { get; internal set; }
    }
}