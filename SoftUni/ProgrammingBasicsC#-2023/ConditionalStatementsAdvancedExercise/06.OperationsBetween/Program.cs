using System;

namespace _06.OperationsBetween
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            char op = char.Parse(Console.ReadLine());
            double result = 0;
            string numbertype = "";
            bool resultOk = true;
            bool div = false;
            bool mod = false;

            switch (op)
            {
                case '+':
                    result = n1 + n2;
                    break;
                case '-':
                    result = n1 - n2;
                    break;
                case '*':
                    result = n1 * n2;
                    break;
                case '/':
                    if (n2 == 0)
                        resultOk = false;
                    else
                    {
                        result = n1 / n2;
                        div = true;
                    }
                    break;
                case '%':
                    if (n2 == 0)
                        resultOk = false;
                    else
                        result = n1 % n2;
                    mod = true;
                    break;
            }
            if (result % 2 == 0)
                numbertype = "even";
            else
                numbertype = "odd";

            if (resultOk && !div && !mod)
            {
                Console.WriteLine($"{n1} {op} {n2} = {result} - {numbertype}");
            }
            else if (div && resultOk)
            {
                Console.WriteLine($"{n1} {op} {n2} = {result:F2}");
            }
            else if (mod && resultOk)
            {
                Console.WriteLine($"{n1} {op} {n2} = {result}");
            }
            else
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
            }

        }
    }
}
