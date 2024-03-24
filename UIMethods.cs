namespace quiz_maker
{
    internal class UIMethods
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("\nWelcome to Quiz Maker!\n");
        }

        public static int AskUserNumberOfQuestions()
        {
            Console.WriteLine("How many questions would you like to answer?");
            int numberOfQuestions;
    //expect user to input integer value
            numberOfQuestions = Convert.ToInt32(Console.ReadLine());
            return numberOfQuestions;
        }

        public static string EnterQuestions()
        {
            Console.WriteLine("Please enter a question!");
            string question = Console.ReadLine();
            return question;
        }
    }
}
