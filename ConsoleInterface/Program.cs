using System;
using System.Drawing;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleInterface
{
    public class MiniSquare
    {
        public int column { get; set; }
        public int row { get; set; }
        public MiniSquare()
        {
            column = 0;
            row = 0;
        }
        public MiniSquare(int column, int row)
        {
            this.column = column;
            this.row = row;
        }
    }

    class Program
    {
        static void drawRectangle(int startColumn, int startRow, int height, int width, int colorNumber)
        {
            Console.ForegroundColor = (ConsoleColor)colorNumber;
            Console.SetCursorPosition(startColumn, startRow);
            Console.Write("╔");
            for (int i = 0; i < width - 2; i++)
                Console.Write("═");
            Console.Write("╗");
            Console.SetCursorPosition(startColumn, startRow + 1);
            for (int i = 0; i < height - 2; i++)
            {
                Console.SetCursorPosition(startColumn, startRow + i + 1);
                Console.Write("║");
                Console.SetCursorPosition(startColumn + width - 1, startRow + i + 1);
                Console.Write("║");
            }
            Console.SetCursorPosition(startColumn, startRow + height - 1);
            Console.Write("╚");
            for (int i = 0; i < width - 2; i++)
                Console.Write("═");
            Console.Write("╝");
        }

        static void drawSquare(int startColumn, int startRow, int sizeSquare, int colorNumber)
        {
            drawRectangle(startColumn, startRow, sizeSquare, sizeSquare, colorNumber);
        }

        static void errorOccurred(string communicat)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.SetCursorPosition(40,25);
            Console.WriteLine("Wystapil blad:");
            Console.SetCursorPosition(40, 26);
            Console.WriteLine(communicat);
            Console.ReadKey();
            Environment.Exit(-1);
        }

        static void uploadParametrs(int arenaSize, ref int squareSize)
        {
            if (arenaSize == 3)
                squareSize = 12;
            else if (arenaSize == 5)
                squareSize = 7;
            else if (arenaSize == 12)
                squareSize = 3;
            else
            {
                errorOccurred("Podano niewlasciwa wartosc arenaSize. Wcisnij dowolny przycisk zeby zakonczyc program.\n");
            }
        }

        static void drawArena(int arenaSize, int startColumn=50, int startRow=5)
        {
            int squareSize = 10;
            uploadParametrs(arenaSize, ref squareSize);
            for(int i=0; i<arenaSize; i++)
            {
                for (int j = 0; j < arenaSize; j++)
                    drawSquare(startColumn+i*squareSize, startRow+j*squareSize ,squareSize, 15);
            }
        }

        static void drawSymbolSize1(int startColumn, int startRow, int symbolValue, int colorNumber)
        {
            Console.ForegroundColor = (ConsoleColor)colorNumber;
            char symbol = ' ';
            if (symbolValue == 0)
                symbol = 'O';
            else
                symbol = 'X';
            Console.SetCursorPosition(startColumn, startRow);
            Console.Write(symbol);
        }
        static void drawSymbolSize5(int startColumn, int startRow, int symbolValue, int colorNumber)
        {
            Console.ForegroundColor = (ConsoleColor)colorNumber;
            if (symbolValue == 1)
            {
                Console.BackgroundColor = (ConsoleColor)colorNumber;
                Console.SetCursorPosition(startColumn, startRow);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn+1, startRow+1);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn+2, startRow+2);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn+1, startRow+3);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn, startRow+4);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn+4, startRow);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn+3, startRow+1);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn+3, startRow+3);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn+4, startRow+4);
                Console.Write(" ");
            }
            else if(symbolValue == 0)
            {
                Console.BackgroundColor = (ConsoleColor)colorNumber;
                Console.SetCursorPosition(startColumn, startRow+1);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn, startRow+2);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn, startRow+3);
                Console.Write(" ");

                Console.SetCursorPosition(startColumn+4, startRow + 1);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn+4, startRow + 2);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn+4, startRow + 3);
                Console.Write(" ");


                Console.SetCursorPosition(startColumn+1, startRow);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn+2, startRow);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn+3, startRow);
                Console.Write(" ");

                Console.SetCursorPosition(startColumn+1, startRow+4);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn+2, startRow+4);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn+3, startRow+4);
                Console.Write(" ");

            }
            else
            {
                errorOccurred("Podano zla wartosc symbolu. Wcisnij dowolny przycisk zeby zakonczyc program.\n");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        static void drawSymbolSize10(int startColumn, int startRow, int symbolValue, int colorNumber)
        {
            MiniSquare[] points = new MiniSquare[100];
            for(int i=0; i<10; i++)
                for(int j=0; j<10; j++)
                    points[i*10+j] = new MiniSquare(startColumn+j, startRow+i);

            Console.BackgroundColor = (ConsoleColor)colorNumber;
            if (symbolValue == 1)
            {
                int[] tabCross = { 0, 11, 22, 33, 44, 55, 66, 77, 88, 99, 90, 81, 72, 63, 54, 45, 36, 27, 18, 9 };
                for (int i = 0; i < tabCross.Length; i++)
                {
                    Console.SetCursorPosition(points[tabCross[i]].column, points[tabCross[i]].row);
                    Console.Write(" ");
                }
            }
            else if(symbolValue == 0)
            {
                int[] tabCircle = { 1, 2, 3, 4, 5, 6, 7, 8, 10, 20, 30, 40, 50, 60, 70, 80, 91, 92, 93, 94, 95, 96, 97, 98, 19, 29, 39, 49, 59, 69, 79, 89 };
                for (int i = 0; i < tabCircle.Length; i++)
                {
                    Console.SetCursorPosition(points[tabCircle[i]].column, points[tabCircle[i]].row);
                    Console.Write(" ");
                }
            }
            else
            {
                errorOccurred("Podano zla wartosc symbolu. Wcisnij dowolny przycisk zeby zakonczyc program.\n");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WindowHeight = 50;
            Console.WindowWidth = 100;

            drawArena(3); //12, 5, 3

            int w = 62, k = 17, ss = 12;
            int v = 0, cv = 15;

            ConsoleKey key;
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something, but don't read key here
                    drawSquare(w, k, 12, 12);
                    System.Threading.Thread.Sleep(250);
                    drawSquare(w, k, 12, 15);
                    System.Threading.Thread.Sleep(250);
                }
                // Key is available - read it
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
                {
                    v = (v + 1) % 2;
                    if (v == 1)
                        cv = 12;
                    else
                        cv = 9;
                    drawSymbolSize10(w+1, k+1, v, cv);
                }
                else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A || key == ConsoleKey.NumPad4)
                {
                    w -= ss;
                }
                else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D || key == ConsoleKey.NumPad6)
                {
                    w += ss;
                }
                else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W || key == ConsoleKey.NumPad8)
                {
                    k -= ss;
                }
                else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S || key == ConsoleKey.NumPad2)
                {
                    k += ss;
                }

            } while (key != ConsoleKey.Escape);

            Console.SetCursorPosition(0, 0);
            Console.WriteLine(ConsoleKey.LeftArrow.ToString());

            for (int i=0; i<10; i++)
                Console.WriteLine();
            Console.ReadKey();
        }
    }
}
