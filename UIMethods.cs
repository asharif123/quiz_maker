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

        public static void QuizSavedMessage()
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

        //input answers
        public static string InputAnswers()
        {
            Console.WriteLine($"\nPlease input your answers, you can enter upto {MAX_ANSWERS} answers!\n");
            string inputAnswers = Console.ReadLine();
            return inputAnswers;
        }

        //create a list of questions based off what user has inputted
        //return as object type since list of questions will contain object of quizzes
        //NOTE: can call UIMethods directly WITHOUT using UIMethods. notation since in same UIMethods file
        public static List<QuizCard> CreateListOfQuestions()
        {
            //list of questions user has inputted
            //initialize it as a type List<Quiz>, where Quiz is the class name. 
            //Since each item stored is a Quiz you are creating
            List<QuizCard> listOfQuizzes = new List<QuizCard>();

            int maxQuestions = AskNumberOfQuestions();

            //take number of questions user wants to input and add to list
            for (int numberOfQuestions = 0; numberOfQuestions < maxQuestions; numberOfQuestions++)
            {
                //record question user is entering
                string questionToAdd = InputQuestion();

                //list of answers to add
                //initialize it in for loop to ensure you have empty answers for each NEW question!
                List<string> answers = new List<string>();

                //record answers user has inputted, input up to 4 answers
                for (int numberOfAnswers = 0; numberOfAnswers < MAX_ANSWERS; numberOfAnswers++)
                {
                    string answersToAdd = InputAnswers();
                    //add answers to listofAnswers to initialize to Quiz
                    answers.Add(answersToAdd.ToLower());
                }

                //show all the answers in the list
                //have user select the correct answer
                //store the correct answer in some variable

                bool assignCorrectAnswer = true;

                while (assignCorrectAnswer)
                {
                    Console.WriteLine("\nWhich answer do you want to be the correct one?\n");
                    string? selectCorrectAnswer = Console.ReadLine().ToLower();

                    //verify the answer users want to be correct is in the answers list
                    if (!(answers).Contains(selectCorrectAnswer))
                    {
                        Console.WriteLine("\nPlease enter an answer that exists!\n");
                    }

                    else
                    {
                        assignCorrectAnswer = false;

                        //exit loop and add each question to a list
                        listOfQuizzes.Add(new QuizCard { questions = questionToAdd, listOfAnswers = answers, correctAnswer = selectCorrectAnswer });
                    }
                }
            }
            return listOfQuizzes;
        }

        //show randomly selected question, pass argument of list of questions
        //pass random value as an argument
        public static QuizCard RandomlySelectedQuestion(List<QuizCard> questionsList, Random randomValue)
        {
            Console.WriteLine("\nRandomly selecting a question...\n");
            int randomNumber = randomValue.Next(0, questionsList.Count);
            return questionsList[randomNumber];
        }

        //code to generate the last quiz user has created
        public static QuizCard MostRecentQuestion(List<QuizCard> questionsList)
        {
            Console.WriteLine("\nGenerating most recent quiz created...\n");
            return questionsList.Last();
        }

        //ask user if ready to play after inputting all the quizzes
        public static char ReadyToPlay()
        {
            Console.WriteLine($"\nPress {CREATE_QUIZ} to create a quiz or any key to play a random quiz!\n");
            char startPlaying = char.ToLower(Console.ReadKey().KeyChar);
            return startPlaying;
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
