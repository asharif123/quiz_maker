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
        /// </summary>
        /// <param name="questionsList">list of questions user has entered</param>
        /// <returns>serialized list of questions</returns>
        public static List<QuizCard> SaveQuizToXML(List<QuizCard> questionsList)
        {

            using (FileStream file = File.Create(PATH))
            {
                serializer.Serialize(file, questionsList);
            }

            return questionsList;
        }

        /// <summary>
        /// method that takes the serialized saved quizzes and loads a list of quizzes
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
