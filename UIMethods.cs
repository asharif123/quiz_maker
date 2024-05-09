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
        /// method that takes in string input from the user
        /// </summary>
        /// <returns>string output</returns>
        public static string GetUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }
        /// <summary>
        /// method that takes user input and uses tryparse to confirm user has entered an integer
        /// </summary>
        /// <param name="minValue">smallest value to start from</param>
        /// <param name="maxValue">largest value to end at</param>
        /// <returns>converted integer based off string input</returns>
        public static int ConvertUserInputToInteger(int minValue, int maxValue)
        {
            bool notValidInput = true;
            int convertToInteger = 0;

            while (notValidInput)
            {
                string userInput = UIMethods.GetUserInput();
                bool isValid = int.TryParse(userInput, out convertToInteger);

                if (!isValid)
                {
                    Console.WriteLine("\nPlease enter a valid integer!\n");
                }

                else if (convertToInteger < minValue || convertToInteger > maxValue)
                {
                    Console.WriteLine($"\nPlease enter a value between {minValue} and {maxValue}!\n");
                }

                else
                {
                    notValidInput = false;
                }
            }
            return convertToInteger;
        }

        /// <summary>
        /// asks user to input how many questions to enter, expects a positive integer
        /// use tryparse to force user to enter a value that can convert to an integer
        /// NOTE: need to initialize numberOfQuestions as an integer so method can return an integer
        /// </summary>
        /// <returns>returns the number of questions user has entered</returns>
        public static int AskNumberOfQuestions()
        {
            Console.WriteLine($"\nHow many questions would you like to enter? You can enter up to {Constants.MAX_QUESTIONS} questions at a time.\n");
            int numberOfQuestions = ConvertUserInputToInteger(Constants.MIN_QUESTIONS, Constants.MAX_QUESTIONS);
            return numberOfQuestions;
        }

        /// <summary>
        /// asks user to input a string question to be stored as a quiz
        /// </summary>
        /// <returns>returns the inputted question</returns>
        public static string InputQuestion()
        {
            Console.WriteLine("\nPlease input your question!\n");
            string inputQuestion = Console.ReadLine();
            return inputQuestion;
        }

        /// <summary>
        /// asks user to enter answers for each question
        /// </summary>
        /// <returns>answers in string format</returns>
        public static string InputAnswer()
        {
            string inputAnswer = Console.ReadLine();
            return inputAnswer;
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
        /// <returns>returns the index to use to assign as the correct answer</returns>
        public static int GetIndexOfCorrectAnswer()
        {
            PrintMessageAskingUserForIndices();
            int indexOfAssignedCorrectAnswer = ConvertUserInputToInteger(Constants.MIN_ANSWERS, Constants.MAX_ANSWERS);
            return indexOfAssignedCorrectAnswer;
        }

        /// <summary>
        /// method that takes answers inputted by user for each question
        /// </summary>
        /// <returns>a list of answers that gets stored in the quizcard class <returns>
        public static List<string> StoreAnswersInputtedByUserPerQuestion()
        {
            List<string> answers = new List<string>();

            Console.WriteLine($"\nPlease input your answers, you can enter up to {Constants.MAX_ANSWERS} answers!\n");

            for (int numberOfAnswers = 0; numberOfAnswers < Constants.MAX_ANSWERS; numberOfAnswers++)
            {
                string answersToAdd = InputAnswer();
                answers.Add(answersToAdd.ToLower());
            }
            return answers;
        }

        /// <summary>
        /// takes the answers inputted by the user and stores the answer the user decided to be the correct one
        /// user selects an index from one to four corresponding to each of the 4 answers.
        /// </summary>
        /// <param name="answers">list of answers inputted by the user per question</param>
        /// <returns>the correct answer chosen by the user</returns>
        public static string StoreCorrectAnswerChosenByUser(List<string> answers)
        {
            int indexOfCorrectAnswer = GetIndexOfCorrectAnswer();

            string storeCorrectAnswer = "";

            storeCorrectAnswer = answers[indexOfCorrectAnswer - 1];

            return storeCorrectAnswer;
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

            int maxQuestionsToInput = AskNumberOfQuestions();

            for (int numberOfQuestions = 0; numberOfQuestions < maxQuestionsToInput; numberOfQuestions++)
            {
                string questionToAdd = InputQuestion();

                List<string> answers = StoreAnswersInputtedByUserPerQuestion();

                string storeCorrectAnswer = StoreCorrectAnswerChosenByUser(answers);

                listOfQuizCards.Add(new QuizCard { question = questionToAdd, answers = answers, correctAnswer = storeCorrectAnswer});
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
        /// NOTE: need to initialize guessOfUser as empty string so string can be returnedd
        /// </summary>
        /// <param name="quiz">take the randomly selected quiz and show its contents</param>
        /// <returns>the user's guess once he has chosen an appropriate index</returns>        
        public static string GetUserAnswer(QuizCard quiz)
        {
            PrintContentsOfLoadedQuiz(quiz);
            int indexGuessOfUser = ConvertUserInputToInteger(Constants.MIN_ANSWERS, Constants.MAX_ANSWERS);
            return quiz.answers[indexGuessOfUser-1];
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
