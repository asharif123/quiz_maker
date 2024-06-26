﻿

namespace quiz_maker
{
    public static class Constants
    {
        public const char NEW_QUIZ = 'c';
        public const char CONTINUE_PLAYING = 'y';
        //user needs to enter a question having at least 10 characters in it
        public const int MIN_QUESTION_LENGTH = 10;
        public const int MIN_QUESTIONS = 1;
        public const int MAX_QUESTIONS = 1000;
        public const int MIN_ANSWER_LENGTH = 1;
        //user needs to enter a question having at least 1 character
        public const int MIN_ANSWERS = 1;
        //user can enter 4 answers per question
        public const int MAX_ANSWERS = 4;
        public const int INCREMENT_SCORE = 5;
        //relative path to xml file
        public const string PATH = @"myFile.xml";
    }
}
