using System.Linq.Expressions;
using System.Xml.Serialization;

namespace quiz_maker
{
    internal class Logic
    {
        //method to save quiz takesList<Quiz> and returns it as same type, needs to be static
        static XmlSerializer serializer = new XmlSerializer(typeof(List<QuizCard>));

        //used to randomly select a question, need to be static
        static Random pickQuizCardAtRandom = new Random();

        //user initially starts at a score of 0, increment by 5 for each correct answer
        static int totalScore = 0;

        /// <summary>
        /// method that takes the questions user has entered and saves in an xml file
        /// stores them in a path having xml file
        /// </summary>
        public static void SaveQuizToXML(List<QuizCard> questionsList)
        {

            using (FileStream file = File.Create(Constants.PATH))
            {
                serializer.Serialize(file, questionsList);
            }
        }

        /// <summary>
        /// method that loads the list of quizzes from the corresponding xml file
        /// first, verify if xml file exists
        /// </summary>
        /// <returns>a list of unserialized quizzes</returns>
        public static List<QuizCard> LoadQuizFromXML()
        {
            List<QuizCard> quizList = new List<QuizCard>();

            if (File.Exists(Constants.PATH))
            {
                using (FileStream file = File.OpenRead(Constants.PATH))
                {
                    quizList = serializer.Deserialize(file) as List<QuizCard>;
                }
            }
            return quizList;
        }

        /// <summary>
        /// method to take a randomly selected quiz by using a random number as index to select the quiz
        /// </summary>
        /// <param name="quizCardList">take a list of quizzes</param>
        /// <returns>a randomly selected quiz</returns>
        public static QuizCard GetRandomQuizCard(List<QuizCard> quizCardList)
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
            return userGuess == quiz.correctAnswer;
        }

        /// <summary>
        /// show the user's total score by taking bool argument, use checkIfAnswerIfCorrect method above
        /// </summary>
        /// <param name="userGuess">argument to determine if user is right or wrong</param>
        /// <param name="quiz">extract the correct answer</param>
        /// <returns>true or false</returns>
        public static int getUserTotalScore(string userGuess, QuizCard quiz)
        {
            if (checkIfAnswerIsCorrect(userGuess, quiz))
            {
                totalScore += Constants.INCREMENT_SCORE;
            }
            return totalScore;
        }

        /// <summary>
        /// method to remove a quiz from the xml database once user has played it to ensure user does not play repetitive quizzes
        /// </summary>
        /// <param name="quizCardList">list of quizzes that are being loaded from database</param>
        /// <param name="quizCard">quizcard that has been selected and remove it once played by user</param>
        public static void QuizAlreadyPlayedByUser(List<QuizCard> quizCardList, QuizCard quizCard)
        {
            quizCardList.RemoveAt(quizCardList.IndexOf(quizCard));
        }

    }
}
