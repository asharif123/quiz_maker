using System.Xml.Serialization;

namespace quiz_maker
{
    internal class Logic
    {
        int totalScore = 0;

        //method to save the quiz
        //takes in an argument of List<Quiz> and returns it as same typ
        //Note: this is a NON-STATIC variable so methods using it need to be non-static
        XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));

        //relative path to xml file
        const string PATH = @"..\myFile.xml";

        //if using static, method will NOT belong to instance of class but to class directly
        //ex: if SaveQuizOnXML is static, cannot access it through instance but as Quiz.SaveQuizOnXML
        //so DON'T put static inside of class
        //using static means it's only available once in your code and CANNOT be instantiated
        public List<Quiz> SaveQuizOnXML(List<Quiz> questionsList)
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
        public void LoadQuizFromXML(List<Quiz> questionsList)
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
