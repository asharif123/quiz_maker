using System.Xml.Serialization;

namespace quiz_maker
{
    internal class Logic
    {
        int totalScore = 0;

        //relative path to xml file
        const string PATH = @"..\myFile.xml";

        //method to save the quiz
        //takes in an argument of List<Quiz> and returns it as same type
        public static List<Quiz> SaveQuizOnXML(List<Quiz> questionsList)
        {
            //serialization
            XmlSerializer writer = new XmlSerializer(questionsList.GetType());

            using (FileStream file = File.Create(PATH))
            {
                writer.Serialize(file, questionsList);
            }
            Console.WriteLine(questionsList.GetType());

            //return a list of quizzes after serialization
            return questionsList;
        }

        //method to load the quiz
        public static List<Quiz> LoadQuizOnXml(List<Quiz> questionsList)
        {
            //deserialization
            XmlSerializer serializer = new XmlSerializer(questionsList.GetType());
            using(FileStream file = File.OpenRead(PATH))
            {
                questionsList = serializer.Deserialize(file) as List<Quiz>;
            }

            return questionsList;
        }
    }
}
