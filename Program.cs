﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace quiz_maker
{
    public class Program
    {
        const char NEW_QUIZ = 'c';
        static void Main()
        {
            //loop and give user option to replay
            bool replay = true;

            //print welcome message
            UIMethods.PrintWelcomeMessage();

            //user can either create a new quiz or play a random quiz
            //have user select an answer, see if it's correct or not
            //if correct answer selected, increment totalScore
            //if user wants to replay, reset the score otherwise exit the game
            while (replay)
            {

                //user has option to either create a quiz or play a random quiz
                char playTheGame = UIMethods.ReadyToPlay();

                //if user decides to play a random quiz
                if (playTheGame == NEW_QUIZ)
                {
                    //show total number of questions user has inputted
                    //use List<Quiz> type since you are showing a list of questions stored as classes
                    List<QuizCard> totalListOfQuestions = UIMethods.CreateListOfQuizCards();

                    //serialization on the entire list of Questions user has inputted
                    //take in a list of quizzes
                    List<QuizCard> serializedQuestions = Logic.SaveQuizToXML(totalListOfQuestions);
                    UIMethods.PrintQuizSavedMessage();
                }

                //if user decides to play a random quiz
                else
                {
                    //print out a list of QuizCards
                    List<QuizCard> listofQuizCards = Logic.LoadQuizFromXML();

                    //randomly display a Quiz Card
                    UIMethods.PrintRandomlySelectingAQuestionMessage();

                    //Load the quizCard that is autogenerated
                    QuizCard selectedQuizCard = Logic.RandomlySelectedQuizCard(listofQuizCards);

                    //record the user's guess when playing the loaded quiz
                    string guessOfUser = UIMethods.UserPlaysLoadedQuiz(selectedQuizCard);

                    //return total score of the user
                    int totalScoreOfUser = UIMethods.GetUserTotalScore(guessOfUser, selectedQuizCard);

                }

                if (UIMethods.AskUserToPlayAgain() == false)
                {
                    replay = false;
                }
            }
        }
    }
}
