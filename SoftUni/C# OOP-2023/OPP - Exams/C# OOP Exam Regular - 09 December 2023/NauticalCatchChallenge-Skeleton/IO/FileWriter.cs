﻿using NauticalCatchChallenge.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.IO
{
    public class TextWriter : IWriter
    {
        public TextWriter()
        {
            File.Delete(path);
        }

        private string path = "../../../output.txt";

        public void Write(string text)
        {
            using (StreamWriter writer = new(path, false))
                writer.Write(text);
        }


        public void WriteLine(string text)
        {
            using (StreamWriter writer = new(path, true))
                writer.WriteLine(text);

        }
    }
}
