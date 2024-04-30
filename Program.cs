using System.Collections.Generic;
using System.Xml.Serialization;

namespace quiz_maker
{
    /// <summary>
    /// Program.cs file takes each of the UIMethods and Logic methods to generate a quiz
    /// saves and loads the randomly generated quiz
    /// user can either create or play an existing quiz in the database
    /// if there are no quizzes in the database, inform user
    /// if quiz available to load, load a random quiz, use for loop to load every quiz
    /// get the user's total score at the end
    /// use while loop so user can continue playing or quit
    /// </summary>
    public class Program
    {

        static void Main()
        {
            bool replay = true;

            while (replay)
            {
                char playTheGame = UIMethods.AskUserToCreateOrPlayRandomQuiz();

                if (playTheGame == Constants.NEW_QUIZ)
                {
                    List<QuizCard> totalListOfQuestions = UIMethods.CreateListOfQuizCards();

                    Logic.SaveQuizToXML(totalListOfQuestions);
                }

                else
                {
                    List<QuizCard> listofQuizCards = Logic.LoadQuizFromXML();

                    if (UIMethods.GetNumberOfQuizzesInDatabase(listofQuizCards) == Constants.NO_QUIZ_IN_DATABASE)
                    {
                        break;
                    }

                    else
                    {
                        HashSet<QuizCard> uniqueListOfQuizCards = Logic.GetUniqueListOfQuizCards(listofQuizCards);
                        foreach (QuizCard uniqueQuizCard in uniqueListOfQuizCards)
                        {
                            string guessOfUser = UIMethods.GetUserAnswer(uniqueQuizCard);

                            bool answerIfCorrect = Logic.checkIfAnswerIsCorrect(guessOfUser, uniqueQuizCard);

                            int totalUserScore = Logic.getUserTotalScore(guessOfUser, uniqueQuizCard);

                            UIMethods.PrintResultInformation(answerIfCorrect, totalUserScore, uniqueQuizCard);
                        }

                    }

                }

                if (UIMethods.AskUserToPlayAgain() == false)
                {
                    replay = false;
                }

            }
        }
    }
}
