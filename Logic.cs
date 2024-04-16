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

            //return a list of quizzes after serialization
            return questionsList;
        }

        //method to load the quiz
        public static void LoadQuizFromXML()
        {
            //deserialization
            //confirm if xml file exists or not
            Console.WriteLine(File.Exists(PATH) ? "\nFile exists." : "File does not exist.\n");
        }
    }
}
