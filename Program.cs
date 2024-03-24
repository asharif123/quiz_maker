namespace quiz_maker
{
    public class Program
    {
        static void Main()
        {
            //user can enter 4 answers per question
            const int NUMBER_OF_ANSWERS = 4;

            //loop and give user option to replay
            bool replay = true;

            //print welcome message
            UIMethods.PrintWelcomeMessage();

            //used to randomly select a question
            Random rd = new Random();

            while (replay)
            {
                
            }
        }
    }
}
