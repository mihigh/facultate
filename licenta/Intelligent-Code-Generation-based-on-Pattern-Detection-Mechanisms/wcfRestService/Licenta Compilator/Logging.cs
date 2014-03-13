﻿using System;
using System.IO;

namespace ICSharpCode.NRefactory.Demo.Logging
{
    class Logging
    {
        public enum Type
        {
            Test, File
        }
        public static readonly Logging Instance;
        
        static Logging()
        {
            if (Common.Common.LoggingType == Type.Test)
                Instance = new Logging(Console.Out);
            else
            {
                var ostrm = new FileStream("./LoggingFile.txt", FileMode.OpenOrCreate, FileAccess.Write);
                var writer = new StreamWriter(ostrm);
                Instance = new Logging(writer);
            }
        }

        private Logging(TextWriter loggingFile)
        {
            Console.SetOut(loggingFile);
        }

        public void Log(String line)
        {
            Console.WriteLine(line);
        }
    }
}
