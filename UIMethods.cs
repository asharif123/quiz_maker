﻿using System.ComponentModel;

namespace quiz_maker
{
    internal class UIMethods
    {
        const char CREATE_QUIZ = 'c';
        const char CONTINUE_PLAYING = 'y';
        //increment score by 5 points
        const int INCREMENT_SCORE = 5;
        //user can enter 4 answers per question
        const int MIN_ANSWERS = 1;
        const int MAX_ANSWERS = 4;

        //record the user's total score
        //make it static to be accesible to the static methods utizling it
        static int totalScore = 0;

        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("\nWelcome to Quiz Maker!\n");
        }

        public static void PrintQuizSavedMessage()
        {
            Console.WriteLine("Your quiz has been saved!\n");
        }

        /// <summary>
        /// asks user to input how many questions to enter, expects a positive integer
        /// </summary>
        /// <returns>returns the number of questions user has entered</returns>
        public static int AskNumberOfQuestions()
        {
            bool notValidInput = true;
            int numberOfQuestions = 0;

            while (notValidInput)
            {
                Console.WriteLine("\nHow many questions would you like to create?\n");
                string questionsToInput = Console.ReadLine();

                bool isValid = int.TryParse(questionsToInput, out numberOfQuestions);

                if (!isValid)
                {
                    Console.WriteLine("Please enter a valid integer!\n");
                }
                else
                {
                    notValidInput = false;
                }
            }
            return numberOfQuestions;
        }
        /// <summary>
        /// asks user to input a string question to be stored as a quiz
        /// </summary>
        /// <returns>returns the inputted question</returns>
        public static string InputQuestion()
        {
            Console.WriteLine("\nPlease input your question!\n");
            string inputQuestions = Console.ReadLine();
            return inputQuestions;
        }
        public static void PrintInputAnswers()
        {
            Console.WriteLine($"\nPlease input your answers, you can enter up to {MAX_ANSWERS} answers!\n");
        }

        public static string InputAnswers()
        {
            string inputAnswers = Console.ReadLine();
            return inputAnswers;
        }

        /// <summary>
        /// message asking user to decide which question should be the correct answer by inputting index.
        /// </summary>
        public static void PrintMessageAskingUserForIndices()
        {
            Console.WriteLine($"\nWhich answer would you like to make as the correct answer? Enter 1 to" +
            $" mark first answer as correct, 2 to mark second answer as correct, " +
            $"3 to mark the third answer as the correct answer, etc..\n");
        }

        /// <summary>
        /// asks user to enter an index from 1 to 4 to be assigned as the correct answer
        /// </summary>
        /// <param name="answers">takes the list of answers corresponding to the loaded question</param>
        /// <returns>returns the index to use to assign as the correct answer</returns>
        public static int GetIndexOfCorrectAnswerFromUser(List<string> answers)
        {
            bool inValidInput = true;
            int indexOfAssignedCorrectAnswer = 1;

            while (inValidInput)
            {
                PrintMessageAskingUserForIndices();

                string assignCorrectAnswer = Console.ReadLine();

                bool isValid = int.TryParse(assignCorrectAnswer, out indexOfAssignedCorrectAnswer);
                if (!isValid)
                {
                    Console.WriteLine("\nPlease enter a valid integer!\n");
                }

                else if (indexOfAssignedCorrectAnswer < 1 || indexOfAssignedCorrectAnswer > answers.Count())
                {
                    Console.WriteLine($"\nPlease enter a valid range from {MIN_ANSWERS} to {answers.Count()}!\n");
                }

                else
                {
                    inValidInput = false;
                }
            }
            return indexOfAssignedCorrectAnswer;
        }

        /// <summary>
        /// takes a list of created questions and stores them as a quiz
        /// user first enters a question then enters 4 answers corresponding to that question
        /// each quiz then gets added to a list of quizzes
        /// </summary>
        /// <returns>a list of quizzes to be serialized</returns>
        public static List<QuizCard> CreateListOfQuizCards()
        {
            List<QuizCard> listOfQuizCards = new List<QuizCard>();

            int maxQuestions = AskNumberOfQuestions();

            for (int numberOfQuestions = 0; numberOfQuestions < maxQuestions; numberOfQuestions++)
            {
                string questionToAdd = InputQuestion();

                List<string> answers = new List<string>();

                PrintInputAnswers();

                for (int numberOfAnswers = 0; numberOfAnswers < MAX_ANSWERS; numberOfAnswers++)
                {
                    string answersToAdd = InputAnswers();
                    answers.Add(answersToAdd.ToLower());
                }

                int indexOfCorrectAnswer = GetIndexOfCorrectAnswerFromUser(answers);

                string storeCorrectAnswer = "";

                storeCorrectAnswer = answers[indexOfCorrectAnswer-1];

                listOfQuizCards.Add(new QuizCard { questions = questionToAdd, answers = answers, correctAnswer = storeCorrectAnswer });
            }
            return listOfQuizCards;
        }

        //ask user if ready to play after inputting all the quizzes
        public static char ReadyToPlay()
        {
            Console.WriteLine($"\nPress {CREATE_QUIZ} to create a quiz or any key to play a random quiz!\n");
            char startPlaying = char.ToLower(Console.ReadKey().KeyChar);
            return startPlaying;
        }

        public static void PrintRandomlySelectingAQuestionMessage()
        {
            Console.WriteLine("\nRandomly selecting a question...\n");
        }

        public static void PrintMessageAskingUserToSelectCorrectAnswer()
        {
            Console.WriteLine($"\nEnter a value from {MIN_ANSWERS} to {MAX_ANSWERS} to select the correct answer.\n");
        }

        public static void PrintMessageUserHasChosenCorrectAnswer(int score)
        {
            Console.WriteLine("\nThat is the correct answer!\n");
            Console.WriteLine($"\nYour total score is {score} points!");
        }

        public static void PrintMessageUserHasChosenWrongAnswer(QuizCard quiz, int score)
        {
            Console.WriteLine("\nSorry that is not the correct answer!\n");
            Console.WriteLine($"\nThe correct answer is {quiz.correctAnswer}\n");
            Console.WriteLine($"\nYour total score is {score} points!\n");
        }

        /// <summary>
        /// load the quiz that has been randomly chosen showing the questions and possible answers
        /// </summary>
        /// <param name="quiz">take the randomly selected quiz and show its contents</param>
        /// <returns>the user's guess once he has chosen an appropriate index</returns>        
        public static string UserPlaysLoadedQuiz(QuizCard quiz)
        {
            Console.WriteLine(quiz.questions);

            Console.WriteLine();

            for (int i = 0; i < quiz.answers.Count; i++) 
            {
                Console.WriteLine($"{i+1} - {quiz.answers[i]}");
            }
            PrintMessageAskingUserToSelectCorrectAnswer();

            bool notValidInput = true;

            string guessOfUser = "";

            while (notValidInput)
            {
                guessOfUser = Console.ReadLine();

                int indexGuessOfUser;

                bool isValid = int.TryParse(guessOfUser, out indexGuessOfUser);

                if (!isValid)
                {
                    Console.WriteLine("\nPlease enter an integer value!\n");
                }

                else if (indexGuessOfUser < MIN_ANSWERS || indexGuessOfUser > MAX_ANSWERS)
                {
                    Console.WriteLine($"\nPlease enter a valid integer from {MIN_ANSWERS} to {MAX_ANSWERS}!\n");
                }
                
                else
                {
                   guessOfUser = quiz.answers[indexGuessOfUser-1];
                   notValidInput = false;
                }
            }
            return guessOfUser;
        }

        /// <summary>
        /// show the total score of the user, where each correct answer is 5 points
        /// user can see the final score
        /// </summary>
        /// <param name="guessOfUser">the answer user has guessed to be the correct answer</param>
        /// <param name="quiz">the randomly selected quiz to obtain the correctAnswer content</param>
        /// <returns>total score the user has obtained</returns>
        public static int GetUserTotalScore(string guessOfUser, QuizCard quiz)
        {
            if (guessOfUser == quiz.correctAnswer)
            {
                totalScore += INCREMENT_SCORE;
                PrintMessageUserHasChosenCorrectAnswer(totalScore);
            }

            else
            {
                PrintMessageUserHasChosenWrongAnswer(quiz, totalScore);
            }
            return totalScore;
        }

        /// <summary>
        /// gives user to continue playing or quit the game
        /// </summary>
        /// <returns>true if user wishes to continue, false to quit the program</returns>
        public static bool AskUserToPlayAgain()
        {
            Console.WriteLine($"\nPress {CONTINUE_PLAYING} to continue playing or any key to quit!\n");
            char optionToContinue = Char.ToLower(Console.ReadKey().KeyChar);
            if (optionToContinue != CONTINUE_PLAYING)
            {
                Console.WriteLine("\nExiting the game!\n");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
