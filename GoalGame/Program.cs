using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoalGame
{
    class Program
    {
        delegate void del(string input);

        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 60);
            Console.CursorVisible = false;
            int xConsolePosition = 12;
            int yConsolePosition = 30;
            int i = 0;
            Random random = new Random();
            int score = 0;
            int ballYPosition = 0;
            int ballXPosition = 0;

            while (true)
            {

                using (StreamReader sr = new StreamReader(@"C:\Goal\ypos.txt"))
                {
                    ballYPosition = Convert.ToInt32(sr.ReadLine());
                    sr.Dispose();
                }

                using (StreamReader sr = new StreamReader(@"C:\Goal\xpos.txt"))
                {
                    ballXPosition = Convert.ToInt32(sr.ReadLine());
                    sr.Dispose();
                }

                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Score: {0}", score);
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(xConsolePosition, yConsolePosition);
                Console.Write("*");
                Console.SetCursorPosition(xConsolePosition, yConsolePosition + 1);
                Console.Write("*");
                Console.SetCursorPosition(xConsolePosition, yConsolePosition + 2);
                Console.Write("*");
                Console.SetCursorPosition(xConsolePosition, yConsolePosition + 3);
                Console.Write("*");
                ConsoleKeyInfo input = Console.ReadKey();

                if (input.Key == ConsoleKey.UpArrow)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xConsolePosition, yConsolePosition);
                    Console.Write(" ");
                    Console.SetCursorPosition(xConsolePosition, yConsolePosition + 1);
                    Console.Write(" ");
                    Console.SetCursorPosition(xConsolePosition, yConsolePosition + 2);
                    Console.Write(" ");
                    Console.SetCursorPosition(xConsolePosition, yConsolePosition + 3);
                    Console.Write(" ");
                    Console.SetCursorPosition(xConsolePosition + 1, yConsolePosition);
                    Console.Write(" ");
                    Console.SetCursorPosition(xConsolePosition + 1, yConsolePosition + 1);
                    Console.Write(" ");
                    Console.SetCursorPosition(xConsolePosition + 1, yConsolePosition + 2);
                    Console.Write(" ");
                    Console.SetCursorPosition(xConsolePosition + 1, yConsolePosition + 3);
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.White;
                    yConsolePosition--;
                }

                if (input.Key == ConsoleKey.DownArrow)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xConsolePosition, yConsolePosition);
                    Console.Write(" ");
                    Console.SetCursorPosition(xConsolePosition, yConsolePosition - 1);
                    Console.Write(" ");
                    Console.SetCursorPosition(xConsolePosition, yConsolePosition - 2);
                    Console.Write(" ");
                    Console.SetCursorPosition(xConsolePosition, yConsolePosition - 3);
                    Console.Write(" ");
                    Console.SetCursorPosition(xConsolePosition + 1, yConsolePosition);
                    Console.Write(" ");
                    Console.SetCursorPosition(xConsolePosition + 1, yConsolePosition - 1);
                    Console.Write(" ");
                    Console.SetCursorPosition(xConsolePosition + 1, yConsolePosition - 2);
                    Console.Write(" ");
                    Console.SetCursorPosition(xConsolePosition + 1, yConsolePosition - 3);
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.White;
                    yConsolePosition++;
                }

                if (input.Key == ConsoleKey.C)
                {
                    Console.Clear();
                }

                if (input.Key == ConsoleKey.Enter)
                {
                    score++;
                }

                if (yConsolePosition <= 3)
                {
                    yConsolePosition = 3;
                }


                if (yConsolePosition >= 55)
                {
                    yConsolePosition = 55;
                }


                i++;

                Thread thread = new Thread(fireBall);
                if (i == 60)
                {
                    if (thread.IsAlive)
                    {
                        continue;
                    }
                    else
                    {
                        thread.Start();
                    }
                    
                    i = 1;
                }


                if (ballYPosition == yConsolePosition && ballXPosition == xConsolePosition
                    || ballYPosition == yConsolePosition + 1 && ballXPosition == xConsolePosition + 1
                    || ballYPosition == yConsolePosition + 2 && ballXPosition == xConsolePosition + 2
                    || ballYPosition == yConsolePosition + 3 && ballXPosition == xConsolePosition + 3)
                {
                    score++;
                }

            }
        }

        public static void xTextFileWriter(string input)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Goal\xpos.txt"))
            {
                sw.WriteLine(input);
                sw.Dispose();
            }
        }

        public static void yTextFileWriter(string input)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Goal\ypos.txt"))
            {
                sw.WriteLine(input);
                sw.Dispose();
            }
        }

        private static void fireBall(object obj)
        {
            del xWriter = xTextFileWriter;
            del yWriter = yTextFileWriter;

            Random random = new Random();
            int ballYPosition = random.Next(3, 59);
            int ballXPosition = 148;
            Console.SetCursorPosition(148, ballYPosition);
            Console.Write("*");

            int i = 1;

            while (true)
            {
                Thread.Sleep(180);
                Console.SetCursorPosition(ballXPosition, ballYPosition);
                Console.Write(" ");
                ballXPosition = ballXPosition - i;

                if (ballXPosition <= 0)
                {
                    break;
                }

                Console.SetCursorPosition(ballXPosition, ballYPosition);
                Console.Write("*");
                xWriter(ballXPosition.ToString());
                yWriter(ballYPosition.ToString());

                i++;
            }
        }



    }
}
