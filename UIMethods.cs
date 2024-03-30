namespace quiz_maker
{
    internal class UIMethods
    {
        const char CONTINUE_PLAYING = 'y';
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
        public static string InputQuestions()
        {
            Console.WriteLine("\nPlease input your question!\n");
            string? inputQuestions = Console.ReadLine();
            return inputQuestions;
        }

        //input answers
        public static string InputAnswers()
        {
            Console.WriteLine("Please input your answers!\n");
            string? inputAnswers = Console.ReadLine();
            return inputAnswers;
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
