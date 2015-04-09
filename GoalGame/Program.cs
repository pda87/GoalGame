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
            if (!Directory.Exists(@"C:\Goal"))
            {
                Directory.CreateDirectory(@"C:\Goal");
            }

            File.WriteAllText("C:\\Goal\\xpos.txt", "");
            File.WriteAllText("C:\\Goal\\ypos.txt", "");

            Console.Title = "GOAL GAME - PRESS H FOR HELP";
            Console.SetWindowSize(150, 60);
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("******************************************************************************************************************************************************");
            Console.SetCursorPosition(40, 6);
            Console.WriteLine("  GGGG   OOOOO    AAA   LL           GGGG    AAA   MM    MM EEEEEEE ");
            Console.SetCursorPosition(40, 7);
            Console.WriteLine(" GG  GG OO   OO  AAAAA  LL          GG  GG  AAAAA  MMM  MMM EE      ");
            Console.SetCursorPosition(40, 8);
            Console.WriteLine("GG      OO   OO AA   AA LL         GG      AA   AA MM MM MM EEEEE   ");
            Console.SetCursorPosition(40, 9);
            Console.WriteLine("GG   GG OO   OO AAAAAAA LL         GG   GG AAAAAAA MM    MM EE      ");
            Console.SetCursorPosition(40, 10);
            Console.WriteLine(" GGGGGG  OOOO0  AA   AA LLLLLLL     GGGGGG AA   AA MM    MM EEEEEEE ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("************************************************************WRITTEN BY PETER ARDEN********************************************************************");

            helpMessage();
            Console.ReadLine();
            Console.Clear();

            int xConsolePosition = 12;
            int yConsolePosition = 30;
            int i = 0;
            int score = 0;
            int ballYPosition = 0;
            int ballXPosition = 0;

            Thread thread = new Thread(fireBall);
            thread.Start();

            while (true)
            {
                if (yConsolePosition == ballYPosition || yConsolePosition + 1 == ballYPosition || yConsolePosition + 2 == ballYPosition || yConsolePosition + 3 == ballYPosition)
                {
                    score++;
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Score: {0}", score);
                    Console.ForegroundColor = ConsoleColor.White;
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

                if (input.Key == ConsoleKey.Q)
                {
                    thread.Abort();
                    quitMessage();
                    return;
                }

                if (input.Key == ConsoleKey.H)
                {
                    thread.Abort();
                    helpMessage();
                    Main(args);
                }

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

                if (yConsolePosition <= 3)
                {
                    yConsolePosition = 3;
                }


                if (yConsolePosition >= 55)
                {
                    yConsolePosition = 55;
                }

                i++;

                try
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
                }
                catch (Exception)
                {
                    continue;
                }

                if (i == 1)
                {
                    Console.Clear();
                }
            }
        }

        private static void helpMessage()
        {
            Console.SetCursorPosition(40, 24);
            Console.WriteLine("                    Press up arrow to move up");
            Console.SetCursorPosition(40, 25);
            Console.WriteLine("                  Press down arrow to move down");
            Console.SetCursorPosition(40, 26);
            Console.WriteLine("      Press up, down, left or right arrow to 'catch' the ball");
            Console.SetCursorPosition(40, 27);
            Console.WriteLine("                (Your score won't count otherwise)");
            Console.SetCursorPosition(40, 28);
            Console.WriteLine("            Press C to clear the screen (it gets clogged up)");
            Console.SetCursorPosition(40, 29);
            Console.WriteLine("                 Press H to display this help message");
            Console.SetCursorPosition(40, 30);
            Console.WriteLine("                          Press Q to quit");
            Console.SetCursorPosition(40, 35);
            Console.WriteLine("                       Press enter to start");
        }

        public static void xTextFileWriter(string input)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Goal\xpos.txt"))
                {
                    sw.WriteLine(input);
                    sw.Dispose();
                }

            }
            catch (Exception)
            {

                xTextFileWriter(input);
            }
        }

        public static void yTextFileWriter(string input)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Goal\ypos.txt"))
                {
                    sw.WriteLine(input);
                    sw.Dispose();
                }
            }
            catch (Exception)
            {

                yTextFileWriter(input);
            }


        }

        private static void fireBall(object obj)
        {
            while (true)
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

                    if (ballXPosition <= 12)
                    {
                        break;
                    }

                    Console.SetCursorPosition(ballXPosition, ballYPosition);
                    Console.Write("*");
                    if (ballXPosition < 30 && ballXPosition > 8)
                    {
                        xWriter(ballXPosition.ToString());
                        yWriter(ballYPosition.ToString());
                    }

                    i++;
                }
                Thread.Sleep(10);
                xWriter(0.ToString());
                yWriter(0.ToString());
            }

        }

        private static void quitMessage()
        {
            for (int i = 0; i < 150; i++)
            {
                for (int j = 60; j > 0; j--)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write("*");
                }
            }
            return;
        }
    }
}
