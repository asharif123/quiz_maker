using System.Xml.Serialization;

namespace quiz_maker
{
    public class Program
    {
        static void Main()
        {
            //user can enter 4 answers per question
            const int NUMBER_OF_ANSWERS = 4;

            //loop and give user option to replay
            bool replay = true;

            //path to xml file
            const string PATH = @"C";
            Console.WriteLine(PATH);
            //print welcome message
            UIMethods.PrintWelcomeMessage();

            //used to randomly select a question
            Random rd = new Random();

            while (replay)
            {
                //initiate a new quiz
                var newQuiz = new Quiz();

                int maxQuestions = UIMethods.AskNumberOfQuestions();

                //take number of questions user wants to input and add to list
                for (int numberOfQuestions = 0; numberOfQuestions < maxQuestions; numberOfQuestions++)
                {
                    //record questions user is entering
                    string questionToAdd = UIMethods.InputQuestions();
                    newQuiz.listOfQuestions.Add(questionToAdd);
                }

                for (int numberOfAnswers = 0; numberOfAnswers < NUMBER_OF_ANSWERS; numberOfAnswers++)
                {
                    //answers to add
                    string answersToAdd = UIMethods.InputAnswers();
                    newQuiz.listOfAnswers.Add(answersToAdd);
                }

                //serialization
                XmlSerializer writer = new XmlSerializer(typeof(Quiz));

                using (FileStream file = File.Create(PATH))
                {
                    writer.Serialize(file, new Quiz());
                }

                if (UIMethods.AskUserToPlayAgain() == false)
                {
                    replay = false;
                }
            }
        }
    }
}
