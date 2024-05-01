///<summary>
///quiz to store questions, answers and the correct answer
///each quiz card is filled with a question and four answers where user selects the right one
///NOTE: this DOES NOT use static since QuizCard is meant to be instantiated and used more than once
///</summary>

namespace quiz_maker
{
    public class QuizCard
    {
        public string question = "";

        public List<string> answers = new List<string>();

        public string correctAnswer = "";
    }
}