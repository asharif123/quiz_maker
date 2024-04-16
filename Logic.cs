using System.Xml.Serialization;

namespace quiz_maker
{
    internal class Logic
    {
        int totalScore = 0;

        //method to save the quiz
        //takes in an argument of List<Quiz> and returns it as same type

        XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));

        //relative path to xml file
        const string PATH = @"..\myFile.xml";

        public static List<Quiz> SaveQuizOnXML(List<Quiz> questionsList)
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
        public static void LoadQuizFromXML(List<Quiz> questionsList)
        {
            //list to store quizzes
            var QuizList = new List<Quiz>();

            //confirm if xml file exists or not
            Console.WriteLine(File.Exists(PATH) ? "\nFile exists." : "File does not exist.\n");

            //get path of xml file location
            Console.WriteLine(new FileInfo(PATH).Directory.FullName);

            //deserialization
            using (FileStream file = File.OpenRead(PATH))
            {
                QuizList = serializer.Deserialize(file) as List<Quiz>;
            }
        }
    }
}
