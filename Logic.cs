using System.IO;
using System.Xml.Serialization;

namespace quiz_maker
{
    internal class Logic
    {
        int totalScore = 0;
        //path to xml file
        const string PATH = @"..\myFile.xml";

        public static List<Quiz> XMLSerialization(List<Quiz> questionsList)
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
    }
}
