using System.Collections.Generic;
using System.Xml.Serialization;

namespace quiz_maker
{
    public class Program
    {
        const char START_GAME = 'y';
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

                //serialization on the entire list of Questions user has inputted
                //take in a list of quizzes
                List<Quiz> serializedQuestions = Logic.SaveQuizOnXML(totalListOfQuestions);

                //user has option to play a random quiz or the most recent quiz
                char playTheGame = UIMethods.ReadyToPlay();

                //if user decides to play a random quiz
                if (playTheGame == START_GAME)
                {

                    //deserialization
                    List<Quiz> deserializedQuestions = Logic.LoadQuizOnXml(serializedQuestions);

                    //randomly select a question of Quiz (name class) type
                    //pass random rd as an argument
                    Quiz randomQuestion = UIMethods.RandomlySelectedQuestion(totalListOfQuestions, rd);
                }

                //if user decides to play the most recent quiz
                else
                {
                    replay = false;
                }

                if (UIMethods.AskUserToPlayAgain() == false)
                {
                    replay = false;
                }
            }
        }
    }
}
