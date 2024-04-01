using System.Xml.Serialization;

namespace quiz_maker
{
    public class Program
    {
        static void Main()
        {
            //loop and give user option to replay
            bool replay = true;

            //path to xml file
            const string PATH = @"C";
            Console.WriteLine(PATH);

            //print welcome message
            UIMethods.PrintWelcomeMessage();

            //used to randomly select a question
            Random rd = new Random();

            //initiate a new quiz
            //ask user number of questions to input
            //ask user a question with 4 answers
            //initiate a quiz with question and 4 answers, store each question in a list
            //do this until all questions have been added
            //randomly select a question (deserialization)
            //have user select an answer, see if it's correct or not
            //if correct answer selected, increment totalScore
            //if user wants to replay, reset the score otherwise exit the game
            while (replay)
            {
                //show total number of questions user has inputted
                //use List<Quiz> type since you are showing a list of questions stored as classes
                List<Quiz> totalNumberOfQuestions = UIMethods.CreateListOfQuestions();

                //randomly select a question of Quiz (name class) type
                Quiz randomQuestion = UIMethods.RandomlySelectedQuestion(totalNumberOfQuestions);
/*
                Console.WriteLine(randomQuestion);*/

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
