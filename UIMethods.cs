namespace quiz_maker
{
    internal class UIMethods
    {
        const char CREATE_QUIZ = 'c';
        const char CONTINUE_PLAYING = 'y';

        //user can enter 4 answers per question
        const int MAX_ANSWERS = 4;

        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("\nWelcome to Quiz Maker!\n");
        }

        public static void PrintQuizSavedMessage()
        {
            Console.WriteLine("Your quiz has been saved!\n");
        }

        //method to return number of questions inputted by user
        public static int AskNumberOfQuestions()
        {
            //ensure user inputs correct value
            bool notValidInput = true;

            //initialized numberofQuestions as an integer to ensure we return an integer having
            //number of questions user has entered
            int numberOfQuestions = 0;

            while (notValidInput)
            {
                Console.WriteLine("\nHow many questions would you like to create?\n");

                //expect user to input integer value
                string questionsToInput = Console.ReadLine();

                //confirm user has entered a valid integer
                //convert string input to int output
                bool isValid = int.TryParse(questionsToInput, out numberOfQuestions);

                if (!isValid)
                {
                    Console.WriteLine("Please enter a valid integer!\n");
                }
                //if user enters a valid integer, break out of loop and return it!
                else
                {
                    notValidInput = false;
                }
            }
            return numberOfQuestions;
        }

        //take questions user has answered and add them to list
        public static string InputQuestion()
        {
            Console.WriteLine("\nPlease input your question!\n");
            string inputQuestions = Console.ReadLine();
            return inputQuestions;
        }

        //print answers statement
        public static void PrintInputAnswers()
        {
            Console.WriteLine($"\nPlease input your answers, you can enter up to {MAX_ANSWERS} answers!\n");
        }

        //input answers
        public static string InputAnswers()
        {
            string inputAnswers = Console.ReadLine();
            return inputAnswers;
        }

        public static void PrintMessageAskingUserForIndices()
        {
            Console.WriteLine($"\nWhich answer would you like to make as the correct answer? Enter 1 to" +
            $" mark first answer as correct, 2 to mark second answer as correct, " +
            $"3 to mark the third answer as the correct answer, etc..\n");
        }

        //method asking user to select an answer to be assigned as the correct one
        //takes in a list of answers
        //return the index of the answer user wants to be the correct one
        public static int GetIndexFromUser(List<string> answers)
        {
            bool inValidInput = true;

            //create integer so GetIndexFromUser can return an integer
            int indexOfAssignedCorrectAnswer = 1;

            //while loop to ensure user enters a valid index that can be found within the answers list
            while (inValidInput)
            {
                PrintMessageAskingUserForIndices();

                //put statement here so if user writes anything incorrect, it will loop back to this
                string assignCorrectAnswer = Console.ReadLine();

                //verify user enters a valid integer to parse from the list
                bool isValid = int.TryParse(assignCorrectAnswer, out indexOfAssignedCorrectAnswer);
                if (!isValid)
                {
                    Console.WriteLine("\nPlease enter a valid integer!\n");
                }

                //if user enters a value out of range
                else if (indexOfAssignedCorrectAnswer < 1 || indexOfAssignedCorrectAnswer > answers.Count())
                {
                    Console.WriteLine($"\nPlease enter a valid range from 1 to {answers.Count()}!\n");
                }

                //if user inputs a value having the correct answer
                else
                {
                    //exit the loop once user has assigned the correct answer
                    inValidInput = false;
                }
            }
            return indexOfAssignedCorrectAnswer;
        }

        //create a list of questions based off what user has inputted
        //return as object type since list of questions will contain object of quizzes
        //NOTE: can call UIMethods directly WITHOUT using UIMethods. notation since in same UIMethods file
        public static List<QuizCard> CreateListOfQuizCards()
        {
            //list of questions user has inputted
            //initialize it as a type List<Quiz>, where Quiz is the class name. 
            //Since each item stored is a Quiz you are creating
            List<QuizCard> listOfQuizCards = new List<QuizCard>();

            int maxQuestions = AskNumberOfQuestions();

            //take number of questions user wants to input and add to list
            for (int numberOfQuestions = 0; numberOfQuestions < maxQuestions; numberOfQuestions++)
            {
                //record question user is entering
                string questionToAdd = InputQuestion();

                //list of answers to add
                //initialize it in for loop to ensure you have empty answers for each NEW question!
                List<string> answers = new List<string>();

                //statement asking user to print answers
                PrintInputAnswers();

                //record answers user has inputted, input up to 4 answers
                for (int numberOfAnswers = 0; numberOfAnswers < MAX_ANSWERS; numberOfAnswers++)
                {
                    string answersToAdd = InputAnswers();
                    //add answers to listofAnswers to initialize to Quiz
                    answers.Add(answersToAdd.ToLower());
                }

                //call method getting the correct answer
                int indexOfCorrectAnswer = GetIndexFromUser(answers);

                //variable to store the correct answer that the user wishes to be the correct one
                string storeCorrectAnswer = "";

                storeCorrectAnswer = answers[indexOfCorrectAnswer];

                //store the questions, answers and chosen correct answer in a listOfQuizCards
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

        //ask user to play again
        public static bool AskUserToPlayAgain()
        {
            Console.WriteLine($"\nPress {CONTINUE_PLAYING} to continue playing or any key to quit!\n");
            char optionToContinue = Char.ToLower(Console.ReadKey().KeyChar);
            //exit the game if user enters any key besides 'y'
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
