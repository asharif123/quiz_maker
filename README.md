What program has multiple choices, random questions and user scoring? 
A quiz maker program! 

This is a program where a user can input 3 questions, multiple answers for each question and the ability to choose the correct answer.

The program will then add those questions and answers to a list using 
serialisation.

The program then reads that file, randomly pick a question and load up its answers 
for the user to choose from. When the user chooses an answer the program will determine if the answer chosen is correct.
It should also keep score for the end.

rocket Tips: First we need to create our repository of questions and answers. 

A simple way to do this is to have your program open up and ask the user to enter questions and their answers. 
Each question and the answers they add will be stored in serialization.

An example might be “What color is the sky?” and list “red, blue, green” as the answers. 
The answer “Blue” is marked as the right answer (which you obviously don’t show the user taking the quiz).
When the user selects the answer it gets compared it to the correct one stored.

Each successful answer can be added to a counter variable. 
At the end of the quiz their score is this counter variable over the number of questions asked.

User is given the option to replay the game.

If yes, program restarts and user can re input 3 questions
