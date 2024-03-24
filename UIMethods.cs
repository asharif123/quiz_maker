namespace quiz_maker
{
    internal class UIMethods
    {
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
                Console.WriteLine("How many questions would you like to answer?");
                //expect user to input integer value
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

        //take questions user has answered and add them to list
        public static string InputQuestions()
        {
            Console.WriteLine("Please input your question!\n");
            string inputQuestions = Console.ReadLine();
            return inputQuestions;
        }
    }
}
