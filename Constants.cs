

namespace quiz_maker
{
    internal static class Constants
    {
        public const char NEW_QUIZ = 'c';
        public const char CREATE_QUIZ = 'r';
        public const char CONTINUE_PLAYING = 'y';
       //user can enter 4 answers per question
        public const int MIN_ANSWERS = 1;
        public const int MAX_ANSWERS = 4;
        //score to increase user's score
        public const int INCREMENT_SCORE = 5;
        //relative path to xml file
        public const string PATH = @"myFile.xml";
    }
}
