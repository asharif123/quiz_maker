using System.ComponentModel;

namespace quiz_maker
{
    internal static class UIMethods
    {
        /// <summary>
        /// takes in an input of c if user wants to create a new quiz, or input any key to play a random quiz
        /// </summary>
        /// <returns>a char argument</returns>
        public static char AskUserToCreateOrPlayRandomQuiz()
        {
            Console.WriteLine($"\nPress {Constants.NEW_QUIZ} to create a quiz or any key to play a random quiz!\n");
            char startPlaying = char.ToLower(Console.ReadKey().KeyChar);
            return startPlaying;
        }

        /// <summary>
        /// asks user to input how many questions to enter, expects a positive integer
        /// use tryparse to force user to enter a value that can convert to an integer
        /// NOTE: need to initialize numberOfQuestions as an integer so method can return an integer
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

        /// <summary>
        /// asks user to enter answers for each question
        /// </summary>
        /// <returns>answers in string format</returns>
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
            $"3 to mark the third answer as correct, " +
            $"or 4 to mark the fourth answer as the correct answer.");
        }

        /// <summary>
        /// asks user to enter an index from 1 to 4 to be assigned as the correct answer
        /// </summary>
        /// <param name="answers">takes the list of answers corresponding to the loaded question</param>
        /// <returns>returns the index to use to assign as the correct answer</returns>
        public static int GetIndexOfCorrectAnswer(List<string> answers)
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

                else if (indexOfAssignedCorrectAnswer < Constants.MIN_ANSWERS || indexOfAssignedCorrectAnswer > answers.Count())
                {
                    Console.WriteLine($"\nPlease enter a valid range from {Constants.MIN_ANSWERS} to {answers.Count()}!\n");
                }

                else
                {
                    inValidInput = false;
                }
            }
            return indexOfAssignedCorrectAnswer;
        }

        /// <summary>
        /// takes a list of created questions w/its corresponding answers and stores them as a quiz
        /// user first enters a question then enters 4 answers corresponding to that question
        /// put answers empty list to reset answers each time user enters a question.
        /// user then decides which answer will be the correct one
        /// each quiz class then gets added to a list of quizzes
        /// </summary>
        /// <returns>a list of quizzes to be serialized</returns>
        /// 
        public static List<QuizCard> CreateListOfQuizCards()
        {
            List<QuizCard> listOfQuizCards = new List<QuizCard>();

            int maxQuestions = AskNumberOfQuestions();

            for (int numberOfQuestions = 0; numberOfQuestions < maxQuestions; numberOfQuestions++)
            {
                string questionToAdd = InputQuestion();

                List<string> answers = new List<string>();

                Console.WriteLine($"\nPlease input your answers, you can enter up to {Constants.MAX_ANSWERS} answers!\n");

                for (int numberOfAnswers = 0; numberOfAnswers < Constants.MAX_ANSWERS; numberOfAnswers++)
                {
                    string answersToAdd = InputAnswers();
                    answers.Add(answersToAdd.ToLower());
                }

                int indexOfCorrectAnswer = GetIndexOfCorrectAnswer(answers);

                string storeCorrectAnswer = "";

                storeCorrectAnswer = answers[indexOfCorrectAnswer - 1];

                listOfQuizCards.Add(new QuizCard { question = questionToAdd, answers = answers, correctAnswer = storeCorrectAnswer });
            }
            return listOfQuizCards;
        }

        /// <summary>
        /// method to determine if there are available quizzes to play when user wants to load a quiz
        ///force user to break out of the loop if there are no available quizzes to play with
        /// </summary>
        /// <param name="quizCards">list of quizzes in database</param>
        /// <returns>number of quizzes in database</returns>
        public static int GetNumberOfQuizzesInDatabase(List<QuizCard> quizCards)
        {
            if (quizCards.Count == Constants.NO_QUIZ_IN_DATABASE)
            {
                Console.WriteLine("\nThere are no quizzes in the database, please create at least one!\n");
            }

            else
            {
                Console.WriteLine("\nStarting the game!\n");
            }

            return quizCards.Count;
        }

        /// <summary>
        /// print contents of the randomly selected quiz to display to the user
        /// </summary>
        /// <param name="quiz">randomly selected quiz</param>
        public static void PrintContentsOfLoadedQuiz(QuizCard quiz)
        {
            Console.WriteLine();

            Console.WriteLine(quiz.question);

            Console.WriteLine();

            for (int i = 0; i < quiz.answers.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {quiz.answers[i]}");
            }

            Console.WriteLine($"\nEnter a value from {Constants.MIN_ANSWERS} to {Constants.MAX_ANSWERS} to select the correct answer.\n");
        }
        /// <summary>
        /// give user the option to guess the correct answer from list of possible answers
        /// Added 2 Console.WriteLine() statements to make the loaded quiz readable
        /// NOTE: need to initialize guessOfUser as empty string so string can be returned
        /// </summary>
        /// <param name="quiz">take the randomly selected quiz and show its contents</param>
        /// <returns>the user's guess once he has chosen an appropriate index</returns>        
        public static string GetUserAnswer(QuizCard quiz)
        {
            PrintContentsOfLoadedQuiz(quiz);

            bool inValidInput = true;

            string guessOfUser = "";

            while (inValidInput)
            {
                guessOfUser = Console.ReadLine();

                int indexGuessOfUser;

                bool valid = int.TryParse(guessOfUser, out indexGuessOfUser);

                if (!valid)
                {
                    Console.WriteLine("\nPlease enter an integer value!\n");
                }

                else if (indexGuessOfUser < Constants.MIN_ANSWERS || indexGuessOfUser > Constants.MAX_ANSWERS)
                {
                    Console.WriteLine($"\nPlease enter a valid integer from {Constants.MIN_ANSWERS} to {Constants.MAX_ANSWERS}!\n");
                }

                else
                {
                    guessOfUser = quiz.answers[indexGuessOfUser - 1];
                    inValidInput = false;
                }
            }
            return guessOfUser;
        }

        /// <summary>
        /// prints statements depending if user has the correct answer or not
        /// </summary>
        /// <param name="ifAnswerIsCorrect">bool variable to determine if user has the right answer</param>
        /// <param name="totalScore">get user's total score</param>
        /// <param name="quiz">get correct answer from random quiz</param>
        public static void PrintResultInformation(bool ifAnswerIsCorrect, int totalScore, QuizCard quiz)
        {
            if (ifAnswerIsCorrect)
            {
                Console.WriteLine("\nThat is the correct answer!\n");
            }
            else
            {
                Console.WriteLine("\nSorry, that is NOT the correct answer!\n");
                Console.WriteLine($"\nThe correct answer is {quiz.correctAnswer}.\n");
            }
            Console.WriteLine($"\nYour total score is {totalScore}.\n");
        }

        /// <summary>
        /// gives user to continue playing or quit the game
        /// </summary>
        /// <returns>true if user wishes to continue, false to quit the program</returns>
        public static bool AskUserToPlayAgain()
        {
            Console.WriteLine($"\nPress {Constants.CONTINUE_PLAYING} to continue playing or any key to quit!\n");
            char optionToContinue = Char.ToLower(Console.ReadKey().KeyChar);
            if (optionToContinue != Constants.CONTINUE_PLAYING)
            {
                Console.WriteLine("\nExiting the game!\n");
                return false;
            }
            return true;
        }
    }
}
