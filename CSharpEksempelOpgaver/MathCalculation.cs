using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEksempelOpgaver
{
    class MathCalculation
    {
        public static void QuadraticEquation()
        {
            ConsoleKeyInfo answer = new ConsoleKeyInfo();
            while (answer.Key != ConsoleKey.N)
            {
                Console.WriteLine("2. Grads ligning.");
                double a = GetABC("Venligst indtast a: ");
                double b = GetABC("Venligst indtast b: ");
                double c = GetABC("Venligst indtast c: ");

                double d = (b * b) - (4 * a * c);

                if (d < 0)
                {
                    Console.WriteLine("Der er ingen løsning for denne andengrads ligning.");
                }
                else if (d == 0)
                {
                    double x = -b / (2 * a);

                    Console.WriteLine("Løsningen er: {0:F}", x);
                }
                else
                {
                    double squareRoot = Math.Sqrt(d);
                    double xPlus = (-b + squareRoot) / (2 * a);
                    double xMinus = (-b - squareRoot) / (2 * a);

                    Console.WriteLine("Der er 2 løsninger. 1) {0:F} 2) {1:F}", xPlus, xMinus);
                    //Console.WriteLine(a * ((xPlus) * xPlus) + b * xPlus + c);
                    //Console.WriteLine(a * ((xMinus) * xMinus) + b * xMinus + c);
                }

                Console.Write("Vil du fortsætte? (Y/n)");
                answer = Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine();
            }

        }

        private static double GetABC(string message)
        {
            Console.Write(message);
            string value = Console.ReadLine();

            return Convert.ToDouble(value);
        }

        public static void GetCircleData()
        {
            ConsoleKeyInfo answer = new ConsoleKeyInfo();
            while (answer.Key != ConsoleKey.N)
            {
                Console.Write("Venligst indtast radius på din cirkel: ");
                string radius = Console.ReadLine();
                double r = Convert.ToDouble(radius);

                Console.WriteLine("Du indtastede {0}", r);
                Console.WriteLine("Omkredsen af cirklen = {0:F4}", Perimeter(r));
                Console.WriteLine("Arealet på cirklen = {0:F4}", Areal(r));

                Console.Write("Vil du fortsætte? (Y/n)");
                answer = Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine();
            }
        }

        private static double Perimeter(double r)
        {
            double p = r * 2 * Math.PI;
            return p;
        }

        private static double Areal(double r)
        {
            double a = r * r * Math.PI;
            return a;
        }

        public static void SquareSum()
        {
            ulong number = GetInts();
            ulong n = number;

            while (number > 9)
            {
                ulong s = 0;

                while (number > 0)
                {
                    s += number % 10;
                    number /= 10;
                }
                number = s;
            }
            Console.WriteLine("The Squaresum of the digits: {0} is {1}", n, number);
        }

        private static ulong GetInts()
        {
            Console.Write("Please enter a bunch of psitive integers: ");
            string value = Console.ReadLine();

            return Convert.ToUInt64(value);
        }

        public static void SmallBigAverage()
        {
            List<int> values = new List<int>();
            int value;

            do
            {
                value = GetNumber();

                if (value != 0)
                {
                    values.Add(value);
                }
                else
                {
                    Console.WriteLine("Antal tal: {0}", values.Count);
                    Console.WriteLine("Summen: {0}", values.Sum());
                    Console.WriteLine("Det mindste tal: {0}", values.Min());
                    Console.WriteLine("Det største tal: {0}", values.Max());
                    Console.WriteLine("Gennemsnittet: {0}", values.Average());
                }
            }
            while (value != 0);
        }

        private static int GetNumber()
        {
            Console.Write("Indtast et tal (indtast 0 for at stoppe): ");
            string value = Console.ReadLine();

            return Convert.ToInt32(value);
        }

        public static void Palindrom()
        {
            string text = null;

            while (text != "")
            {
                Console.WriteLine("Indtast intet og tryk [ENTER] for at afslutte.");
                Console.Write("Venligst indtast en tekst og se om det er en Palindrom: ");
                text = Console.ReadLine();

                if (text != "")
                {
                    if (isPalindrom(text.ToLower()))
                    {
                        Console.WriteLine("Tillykke, det er en Palindrom!");
                    }
                    else
                    {
                        Console.WriteLine("ØV, det er ikke en Palindrom!");
                    }
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine();
                }
            }
        }

        private static bool isPalindrom(string text)
        {
            for (int firstChar = 0, lastChar = text.Length - 1; firstChar < lastChar;)
            {
                if (!isCharOK(text[firstChar]) && !isCharOK(text[lastChar]))
                {
                    firstChar++;
                    lastChar--;
                }
                else if (!isCharOK(text[firstChar]))
                {
                    firstChar++;
                }
                else if (!isCharOK(text[lastChar]))
                {
                    lastChar--;
                }
                else if (text[firstChar] != text[lastChar])
                {
                    return false;
                }
                else
                {
                    firstChar++;
                    lastChar--;
                }
            }

            return true;
        }

        private static bool isCharOK(char ch)
        {
            return (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9') || ch == 'æ' || ch == 'ø' || ch == 'å';
        }

        public void Yatzy()
        {
            ThrowDices();
        }

        private static int[] ThrowDices()
        {
            Random random = new Random();
            int counter = 0;
            int[] dices = new int[5];

            do
            {
                Console.Write("[");
                for (int i = 0; i < dices.Length; i++)
                {
                    dices[i] = random.Next(1, 7);
                    counter++;

                    if (i < dices.Length - 1)
                    {
                        Console.Write(dices[i] + ", ");
                    }
                    else
                    {
                        Console.Write(dices[i] + "]");
                    }
                }
                Console.WriteLine();
            }
            while (!IsYatzy(dices));

            Console.WriteLine("YATZY! It only took you " + counter + " attempts.");

            return dices;
        }

        private static bool IsYatzy(int[] dices)
        {
            for (int i = 0; i < dices.Length; i++)
            {
                if (dices[i] != dices[0])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
