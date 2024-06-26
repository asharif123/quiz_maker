﻿using System.Xml.Serialization;

namespace quiz_maker
{
    internal static class Logic
    {
        //method to save quiz takes List<Quiz> and returns it as same type
        //made static so can be accessed anywhere without needing to be instantiated
        //variable is shared among all instances of class
        //ex: if method is static and members are non-static, to access non-static
        //you would need to instantiate method would would be impossible to access in this case
        static XmlSerializer serializer = new XmlSerializer(typeof(List<QuizCard>));

        //used to randomly select a question, need to be static
        //made static so can be accessed anywhere without needing to be instantiated
        //variable is shared among all instances of class
        static Random pickQuizCardAtRandom = new Random();

        //user initially starts at a score of 0, increment by 5 for each correct answer
        //made static so can be accessed anywhere without needing to be instantiated
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
        /// first, verify if xml file exists then load the quizcards56y
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
        public static bool CheckIfAnswerIsCorrect(string userGuess, QuizCard quiz)
        {
            return userGuess == quiz.correctAnswer;
        }

        /// <summary>
        /// show the user's total score by taking bool argument, use checkIfAnswerIfCorrect method above
        /// </summary>
        /// <param name="userGuess">argument to determine if user is right or wrong</param>
        /// <param name="quiz">extract the correct answer</param>
        /// <returns>true or false</returns>
        public static int GetUserTotalScore(string userGuess, QuizCard quiz)
        {
            if (CheckIfAnswerIsCorrect(userGuess, quiz))
            {
                totalScore += Constants.INCREMENT_SCORE;
            }
            return totalScore;
        }

        /// <summary>
        /// get index of quizcard already played by user and remove it from loaded quizcards from the database
        /// </summary>
        /// <param name="quizCardList">list of quizzes that are being loaded from database</param>
        /// <param name="quizCard">quizcard that has been selected and remove it once played by user</param>
        public static void RemoveAlreadyPlayedQuizCard(List<QuizCard> quizCardList, QuizCard quizCard)
        {
            quizCardList.RemoveAt(quizCardList.IndexOf(quizCard));
        }
    }
}
