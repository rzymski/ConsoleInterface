using System;

namespace ConsoleInterface
{
    class Program
    {
        static void drawSquare(int startColumn, int startRow, int sizeSquare, int colorNumber)
        {
            Console.ForegroundColor = (ConsoleColor)colorNumber;
            Console.SetCursorPosition(startColumn, startRow);
            Console.Write("╔");
            for (int i = 0; i < sizeSquare-2; i++)
                Console.Write("═");
            Console.Write("╗");
            Console.SetCursorPosition(startColumn, startRow+1);
            for (int i = 0; i < sizeSquare - 2; i++)
            {
                Console.SetCursorPosition(startColumn, startRow + i + 1);
                Console.Write("║");
                Console.SetCursorPosition(startColumn+sizeSquare-1, startRow+i+1);
                Console.Write("║");
            }
            Console.SetCursorPosition(startColumn, startRow + sizeSquare-1);
            Console.Write("╚");
            for (int i = 0; i < sizeSquare - 2; i++)
                Console.Write("═");
            Console.Write("╝");
        }

        static void errorOccurred(string communicat)
        {
            Console.Clear();
            Console.WriteLine("Wystapil blad:\n" + communicat);
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
                errorOccurred("Podano niewlasciwa wartosc arenaSize\nWcisnij dowolny przycisk zeby zakonczyc program.\n");
            }
        }

        static void drawArena(int arenaSize)
        {
            int squareSize = 10, startColumn = 50, startRow = 5;
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
                /*Console.SetCursorPosition(startColumn, startRow);
                Console.BackgroundColor = (ConsoleColor)colorNumber;
                Console.Write("\\   /");
                Console.SetCursorPosition(startColumn, startRow + 1);
                Console.Write(" \\ / ");
                Console.SetCursorPosition(startColumn, startRow + 2);
                Console.Write("  X  ");
                Console.SetCursorPosition(startColumn, startRow + 3);
                Console.Write(" / \\ ");
                Console.SetCursorPosition(startColumn, startRow + 4);
                Console.Write("/   \\");
                Console.BackgroundColor = ConsoleColor.Black;*/
                Console.SetCursorPosition(startColumn, startRow);
                Console.BackgroundColor = (ConsoleColor)colorNumber;
                Console.Write("\\");
                Console.SetCursorPosition(startColumn+1, startRow + 1);
                Console.Write("\\");
                Console.SetCursorPosition(startColumn+2, startRow + 2);
                Console.Write("X");
                Console.SetCursorPosition(startColumn+1, startRow + 3);
                Console.Write("/");
                Console.SetCursorPosition(startColumn, startRow + 4);
                Console.Write("/");
                Console.SetCursorPosition(startColumn+4, startRow);
                Console.Write("/");
                Console.SetCursorPosition(startColumn+3, startRow+1);
                Console.Write("/");
                Console.SetCursorPosition(startColumn+3, startRow + 3);
                Console.Write("\\");
                Console.SetCursorPosition(startColumn+4, startRow + 4);
                Console.Write("\\");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 150;

            //drawArena(12);
            drawSquare(3, 3, 3, 15); // 12, 7, 3 size square
            drawSymbolSize1(4, 4, 0, 12);
            drawSquare(10, 10, 7, 15);
            drawSymbolSize5(11, 11, 1, 12);
            drawSquare(30, 30, 12, 15);

            /*drawSquare(10, 0, 10, 1);
            drawSquare(20, 0, 10, 2);
            drawSquare(30, 0, 10, 3);
            drawSquare(10, 10, 10, 4);
            drawSquare(20, 10, 10, 5);
            drawSquare(30, 10, 10, 6);
            drawSquare(10, 20, 10, 7);
            drawSquare(20, 20, 10, 8);
            drawSquare(30, 20, 10, 9);*/

            //Console.SetCursorPosition(10, 10);
            //drawFrame();

            //Console.WriteLine("║ ═");
            //Console.Write("╔═╗ ╝ ╚");


            for (int i=0; i<10; i++)
                Console.WriteLine();
            Console.ReadKey();
        }
    }
}
