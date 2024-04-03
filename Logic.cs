﻿using System.IO;
using System.Xml.Serialization;

namespace quiz_maker
{
    internal class Logic
    {
        int totalScore = 0;
        //path to xml file
        const string PATH = @"C";

        public static void XMLSerialization(List<Quiz> questionsList)
        {
            //serialization
            XmlSerializer writer = new XmlSerializer(typeof(Quiz));

            using (FileStream file = File.Create(PATH))
            {
                writer.Serialize(file, new Quiz());
            }
        }
    }
}
