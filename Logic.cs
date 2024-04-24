using System.Xml.Serialization;

namespace quiz_maker
{
    internal class Logic
    {
        //method to save quiz takesList<Quiz> and returns it as same type, needs to be static
        static XmlSerializer serializer = new XmlSerializer(typeof(List<QuizCard>));

        //used to randomly select a question, need to be static
        static Random pickQuizCardAtRandom = new Random();

        static int totalScore = 0;

        //relative path to xml file
        const string PATH = @"myFile.xml";
        const int INCREMENT_SCORE = 5;
        
        /// <summary>
        /// method that takes the questions user has entered and saves in an xml file
        /// stores them in a path having xml file
        /// </summary>
        public static void SaveQuizToXML(List<QuizCard> questionsList)
        {

            using (FileStream file = File.Create(PATH))
            {
                serializer.Serialize(file, questionsList);
            }

        }

        /// <summary>
        /// method that loads the list of quizzes from the corresponding xml file
        /// </summary>
        /// <returns>a list of unserialized quizzes</returns>
        public static List<QuizCard> LoadQuizFromXML()
        {
            List<QuizCard> quizList = new List<QuizCard>();

            using (FileStream file = File.OpenRead(PATH))
            {
                quizList = serializer.Deserialize(file) as List<QuizCard>;
            }

            return quizList;
        }

        //show randomly selected question, pass argument of list of questions
        public static QuizCard RandomlySelectedQuizCard(List<QuizCard> quizCardList)
        {
            int randomNumber = pickQuizCardAtRandom.Next(0, quizCardList.Count);
            return quizCardList[randomNumber];
        }

        /// <summary>
        /// method to determine if what user entered matches the answer in the correct quiz
        /// </summary>
        /// <param name="userGuess">answer user has inputted as correct</param>
        /// <param name="quiz">extract the correct answer</param>
        /// <returns>true if user has the right answer, else false</returns>
        public static bool checkIfAnswerIsCorrect(string userGuess, QuizCard quiz)
        {
            if (userGuess == quiz.correctAnswer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// show the user's total score by taking bool argument
        /// </summary>
        /// <param name="userGuess">argument to determine if user is right or wrong</param>
        /// <param name="quiz">extract the correct answer</param>
        /// <returns>true or false</returns>
        public static int getUserTotalScore(string userGuess, QuizCard quiz)
        {
            if (userGuess == quiz.correctAnswer)
            {
                totalScore += INCREMENT_SCORE;
            }

            return totalScore;
        }
        
    }
}
