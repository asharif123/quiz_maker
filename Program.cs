using System.Collections.Generic;
using System.Xml.Serialization;

namespace quiz_maker
{
    /// <summary>
    /// Program.cs file takes each of the UIMethods and Logic methods to generate a quiz
    /// saves and loads the randomly generated quiz
    /// get the user's total score at the end
    /// use while loop so user can continue playing or quit
    /// </summary>
    public class Program
    {
        const char NEW_QUIZ = 'c';
        static void Main()
        {
            bool replay = true;

            UIMethods.PrintWelcomeMessage();

            while (replay)
            {
                char playTheGame = UIMethods.ReadyToPlay();

                if (playTheGame == NEW_QUIZ)
                {
                    List<QuizCard> totalListOfQuestions = UIMethods.CreateListOfQuizCards();

                    Logic.SaveQuizToXML(totalListOfQuestions);
                    UIMethods.PrintQuizSavedMessage();
                }

                else
                {
                    List<QuizCard> listofQuizCards = Logic.LoadQuizFromXML();

                    UIMethods.PrintRandomlySelectingAQuestionMessage();

                    QuizCard selectedQuizCard = Logic.RandomlySelectedQuizCard(listofQuizCards);

                    string guessOfUser = UIMethods.UserPlaysLoadedQuiz(selectedQuizCard);

                    UIMethods.GetUserTotalScore(guessOfUser, selectedQuizCard);

                }

                if (UIMethods.AskUserToPlayAgain() == false)
                {
                    replay = false;
                }
            }
        }
    }
}
