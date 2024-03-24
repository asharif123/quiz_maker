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
                var newQuiz = new Quiz();
                
                int maxQuestions = UIMethods.AskNumberOfQuestions();
                //record questions user is entering
                string questionToAdd = UIMethods.InputQuestions();

            //take number of questions user wants to input and add to list
            for (int numberOfQuestions = 0; numberOfQuestions < maxQuestions; numberOfQuestions++)
                {
                    newQuiz.listOfQuestions.Add(questionToAdd);
                }
            }
        }
    }
}
