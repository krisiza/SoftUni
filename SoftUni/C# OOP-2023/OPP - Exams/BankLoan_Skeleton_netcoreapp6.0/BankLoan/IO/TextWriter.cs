using BankLoan.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.IO
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
            using (StreamWriter writer = new(path, true))
                writer.Write(text);
        }


        public void WriteLine(string text)
        {
            using (StreamWriter writer = new(path, true))
                writer.WriteLine(text);

        }
    }
}


