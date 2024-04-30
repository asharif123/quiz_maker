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
                        for (int i = 0; i <  listofQuizCards.Count; i++)
                        {
                            QuizCard selectedQuizCard = Logic.GetRandomQuizCard(listofQuizCards);

                            string guessOfUser = UIMethods.GetUserAnswer(selectedQuizCard);

                            bool answerIfCorrect = Logic.checkIfAnswerIsCorrect(guessOfUser, selectedQuizCard);

                            int totalUserScore = Logic.getUserTotalScore(guessOfUser, selectedQuizCard);

                            UIMethods.PrintResultInformation(answerIfCorrect, totalUserScore, selectedQuizCard);
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
