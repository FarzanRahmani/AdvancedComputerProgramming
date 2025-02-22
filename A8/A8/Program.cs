using System;

namespace A8.StatePattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunCalculator(() => Console.ReadKey().KeyChar, Console.Clear);
        }

        public static Calculator RunCalculator(Func<char> GetKey, Action clearScreen)
        {
            Calculator calc = new Calculator(clearScreen); // () => { }
            while (true)
            {
                calc.PrintDisplay(); 
                char key = GetKey(); // () => keys[i++]
                switch (key)
                {
                    case '.':
                        calc.EnterPoint();
                        break;
                    case '0':
                        calc.EnterZeroDigit();
                        break;
                    case '=':
                    case (char)ConsoleKey.Enter:
                        calc.EnterEqual();
                        break;
                    case (char)ConsoleKey.Escape:
                        calc.Clear();
                        break;
                    case var c when c != '0' && char.IsDigit(c): // 1,2,3,4,5,6,7,8,9
                        calc.EnterNonZeroDigit(c);
                        break;
                    case var c when Calculator.Operators.ContainsKey(c): // keys: +,-,*,/,^
                        calc.EnterOperator(c);
                        break;
                    case 'q':
                        return calc;
                }
            }
        }
    }
}
