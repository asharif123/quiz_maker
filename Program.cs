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

            //used to randomly select a question
            Random rd = new Random();

            //user can either create a new quiz or play a random quiz
            //have user select an answer, see if it's correct or not
            //if correct answer selected, increment totalScore
            //if user wants to replay, reset the score otherwise exit the game
            while (replay)
            {

                //user has option to either create a quiz or play a random quiz
                char playTheGame = UIMethods.ReadyToPlay();

                //create totalListOfQuestions variable to make it accesible regardless if user decies
                //to create a new quiz or play a random quiz
                List<Quiz> totalListOfQuestions = null;

                //if user decides to play a random quiz
                if (playTheGame == NEW_QUIZ)
                {
                    //show total number of questions user has inputted
                    //use List<Quiz> type since you are showing a list of questions stored as classes
                    totalListOfQuestions = UIMethods.CreateListOfQuestions();

                    //serialization on the entire list of Questions user has inputted
                    //take in a list of quizzes
                    List<Quiz> serializedQuestions = Logic.SaveQuizOnXML(totalListOfQuestions);

                    UIMethods.QuizSavedMessage();

                }

                //if user decides to play a random quiz
                else
                {
                    //randomly select a question of Quiz (name class) type
                    //pass random rd as an argument
                    Quiz randomQuestion = UIMethods.RandomlySelectedQuestion(totalListOfQuestions, rd);

                }

                if (UIMethods.AskUserToPlayAgain() == false)
                {
                    replay = false;
                }
            }
        }
    }
}
