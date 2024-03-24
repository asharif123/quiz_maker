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
            Console.WriteLine("How many questions would you like to answer?");
            int numberOfQuestions;
    //expect user to input integer value
            Console.ReadLine();
            numberOfQuestions = Convert.ToInt32(Console.ReadLine());
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
