using System.Collections.Generic;
using System.Xml.Serialization;

namespace quiz_maker
{
    public class Program
    {
        static void Main()
        {
            //loop and give user option to replay
            bool replay = true;

            //print welcome message
            UIMethods.PrintWelcomeMessage();

            //used to randomly select a question
            Random rd = new Random();

            //randomly select a question (deserialization)
            //have user select an answer, see if it's correct or not
            //if correct answer selected, increment totalScore
            //if user wants to replay, reset the score otherwise exit the game
            while (replay)
            {
                //show total number of questions user has inputted
                //use List<Quiz> type since you are showing a list of questions stored as classes
                List<Quiz> totalListOfQuestions = UIMethods.CreateListOfQuestions();

                //randomly select a question of Quiz (name class) type
                //pass random rd as an argument
                Quiz randomQuestion = UIMethods.RandomlySelectedQuestion(totalListOfQuestions, rd);

                //serialization on the entire list of Questions user has inputted
                //take in a list of quizzes
                List<Quiz> serializedQuestions = Logic.SaveQuizOnXML(totalListOfQuestions);

                //deserialization
                List<Quiz> deserializedQuestions = Logic.LoadQuizOnXml(totalListOfQuestions);

                if (UIMethods.AskUserToPlayAgain() == false)
                {
                    replay = false;
                }
            }
        }
    }
}
