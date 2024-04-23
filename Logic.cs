using System.Xml.Serialization;

namespace quiz_maker
{
    internal class Logic
    {
        //method to save quiz takesList<Quiz> and returns it as same type, needs to be static
        static XmlSerializer serializer = new XmlSerializer(typeof(List<QuizCard>));

        //used to randomly select a question, need to be static
        static Random pickQuizCardAtRandom = new Random();

        //relative path to xml file
        const string PATH = @"myFile.xml";

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
    }
}
