﻿

namespace quiz_maker
{
    internal static class Constants
    {
        public const char NEW_QUIZ = 'c';
        public const char CONTINUE_PLAYING = 'y';
        public const int MIN_QUESTIONS = 1;
        public const int MIN_ANSWERS = 1;
        //user can enter 4 answers per question
        public const int MAX_ANSWERS = 4;
        //user can enter up to 100 questions at max
        public const int MAX_QUESTIONS = 100;
        public const int INCREMENT_SCORE = 5;
        //check if there are any available quizzes in the database
        public const int NO_QUIZ_IN_DATABASE = 0;
        //relative path to xml file
        public const string PATH = @"myFile.xml";
    }
}
