using System.Collections.Generic;
using System.Xml.Serialization;

namespace quiz_maker
{
    /// <summary>
    /// Program.cs file takes each of the UIMethods and Logic methods to generate a quiz
    /// saves and loads the randomly generated quiz
    /// user can either create or play an existing quiz in the database
    /// get the user's total score at the end
    /// use while loop so user can continue playing or quit
    /// </summary>
    public class Program
    {
      
        static void Main()
        {
            bool replay = true;

            UIMethods.PrintWelcomeMessage();

            while (replay)
            {
                char playTheGame = UIMethods.ReadyToPlay();

                if (playTheGame == Constants.NEW_QUIZ)
                {
                    List<QuizCard> totalListOfQuestions = UIMethods.CreateListOfQuizCards();

                    Logic.SaveQuizToXML(totalListOfQuestions);
                    UIMethods.PrintQuizSavedMessage();
                }

                else
                {
                    List<QuizCard> listofQuizCards = Logic.LoadQuizFromXML();

                    UIMethods.PrintRandomlySelectingAQuestionMessage();

                    QuizCard selectedQuizCard = Logic.GetRandomQuizCard(listofQuizCards);

                    string guessOfUser = UIMethods.GetUserAnswer(selectedQuizCard);                

                    bool answerIfCorrect = Logic.checkIfAnswerIsCorrect(guessOfUser, selectedQuizCard);

                    int totalUserScore = Logic.getUserTotalScore(guessOfUser, selectedQuizCard);

                    UIMethods.PrintResultInformation(answerIfCorrect, totalUserScore, selectedQuizCard);
                   

                }

                if (UIMethods.AskUserToPlayAgain() == false)
                {
                    replay = false;
                }
        
            }
        }
    }
}
