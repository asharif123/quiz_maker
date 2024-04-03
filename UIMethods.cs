namespace quiz_maker
{
    internal class UIMethods
    {
        const char CONTINUE_PLAYING = 'y';

        //user can enter 4 answers per question
        const int MAX_ANSWERS = 4;
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("\nWelcome to Quiz Maker!\n");
        }
        //method to return number of questions inputted by user
        public static int AskNumberOfQuestions()
        {
            //ensure user inputs correct value
            bool notValidInput = true;
            int numberOfQuestions = 0;

            while (notValidInput)
            {
                Console.WriteLine("\nHow many questions would you like to answer?\n");
                //expect user to input integer value
                string? questionsToInput = Console.ReadLine();
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

        //take questions user has answered and add them to list
        public static string InputQuestion()
        {
            Console.WriteLine("\nPlease input your question!\n");
            string? inputQuestions = Console.ReadLine();
            return inputQuestions;
        }

        //input answers
        public static string InputAnswers()
        {
            Console.WriteLine("\nPlease input your answers, you can enter upto 4 answers!\n");
            string? inputAnswers = Console.ReadLine();
            return inputAnswers;
        }

        //create a list of questions based off what user has inputted
        //return as object type since list of questions will contain object of quizzes
        public static List<Quiz> CreateListOfQuestions()
        {
            //list of questions user has inputted
            List<Quiz> listOfQuestions = new List<Quiz>();

            int maxQuestions = UIMethods.AskNumberOfQuestions();

            //take number of questions user wants to input and add to list
            for (int numberOfQuestions = 0; numberOfQuestions < maxQuestions; numberOfQuestions++)
            {
                //record question user is entering
                string questionToAdd = UIMethods.InputQuestion();

                //list of answers to add
                //initialize it in for loop to ensure you have empty answers for each NEW question!
                List<string> listOfAnswers = new List<string>();

                //record answers user has inputted
                for (int numberOfAnswers = 0; numberOfAnswers < MAX_ANSWERS; numberOfAnswers++)
                {
                    string answersToAdd = UIMethods.InputAnswers();
                    //add answers to listofAnswers to initialize to Quiz
                    listOfAnswers.Add(answersToAdd);
                }

                //add each question to a list
                listOfQuestions.Add(new Quiz { questions = questionToAdd, listOfAnswers = listOfAnswers });
            }
            return listOfQuestions;
        }

        //show randomly selected question, pass argument of list of questions
        public static Quiz RandomlySelectedQuestion(List<Quiz> questionsList)
        {
            Console.WriteLine("\nRandomly selecting a question...\n");          
            Random rd = new Random();
            int randomNumber = rd.Next(0,questionsList.Count);
            return questionsList[randomNumber];
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
