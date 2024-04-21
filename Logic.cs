using System.Xml.Serialization;

namespace quiz_maker
{
    internal class Logic
    {
        int totalScore = 0;

        //method to save the quiz
        //takes in an argument of List<Quiz> and returns it as same type
        //Note: this is a static variable because we want to use it once AND
        //make this static so that it is available in static methods
        static XmlSerializer serializer = new XmlSerializer(typeof(List<QuizCard>));

        //used to randomly select a question
        //declare it as static to be used in the static method
        static Random pickQuizCardAtRandom = new Random();

        //relative path to xml file
        const string PATH = @"myFile.xml";

        //if using static, method will NOT belong to instance of class but to class directly
        //ex: if SaveQuizOnXML is static, cannot access it through instance but as Logic.SaveQuizOnXML
        //so use static since want to use each method below once
        //using static means it's only available once in your code and CANNOT be instantiated
        public static List<QuizCard> SaveQuizToXML(List<QuizCard> questionsList)
        {
            //serialization

            using (FileStream file = File.Create(PATH))
            {
                serializer.Serialize(file, questionsList);
            }

            //return a list of quizzes after serialization
            return questionsList;
        }

        //method to load the quiz
        public static List<QuizCard> LoadQuizFromXML()
        {
            //list to store quizzes
            List<QuizCard> quizList = new List<QuizCard>();

            //deserialization
            using (FileStream file = File.OpenRead(PATH))
            {
                quizList = serializer.Deserialize(file) as List<QuizCard>;
            }

            return quizList;
        }

        //show randomly selected question, pass argument of list of questions
        //pass random value as an argument
        public static QuizCard PrintRandomlySelectedQuizCard(List<QuizCard> quizCardList)
        {
            int randomNumber = pickQuizCardAtRandom.Next(0, quizCardList.Count);
            return quizCardList[randomNumber];
        }
    }
}
