using System;
using System.Drawing;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleInterface
{
    public class MiniSquareSymbolFragment
    {
        public int column { get; set; }
        public int row { get; set; }
        public MiniSquareSymbolFragment()
        {
            column = 0;
            row = 0;
        }
        public MiniSquareSymbolFragment(int column, int row)
        {
            this.column = column;
            this.row = row;
        }
    }

    class Draw
    {
        public static void drawRectangle(int startColumn, int startRow, int height, int width, int colorNumber)
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
        public static void drawSquare(int startColumn, int startRow, int sizeSquare, int colorNumber)
        {
            drawRectangle(startColumn, startRow, sizeSquare, sizeSquare, colorNumber);
        }
        public static void errorOccurred(string communicat)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.SetCursorPosition(40, 25);
            Console.WriteLine("Wystapil blad:");
            Console.SetCursorPosition(40, 26);
            Console.WriteLine(communicat);
            Console.ReadKey();
            Environment.Exit(-1);
        }
        public static void uploadParametrs(int arenaSize, ref int squareSize)
        {
            if (arenaSize == 3)
                squareSize = 12;
            else if (arenaSize == 5)
                squareSize = 7;
            else if (arenaSize == 13)
                squareSize = 3;
            else
            {
                errorOccurred("Podano niewlasciwa wartosc arenaSize. Wcisnij dowolny przycisk zeby zakonczyc program.\n");
            }
        }
        public static void drawArena(int arenaSize, int startColumn = 50, int startRow = 5)
        {
            int squareSize = 10;
            uploadParametrs(arenaSize, ref squareSize);
            for (int i = 0; i < arenaSize; i++)
            {
                for (int j = 0; j < arenaSize; j++)
                    drawSquare(startColumn + i * squareSize, startRow + j * squareSize, squareSize, 15);
            }
        }

        public static void drawSymbol(int option, int startColumn, int startRow, int symbolValue, int colorNumber)
        {
            switch (option)
            {
                case 1:
                    drawSymbolSize1(startColumn, startRow, symbolValue, colorNumber);
                    break;
                case 2:
                    drawSymbolSize5(startColumn, startRow, symbolValue, colorNumber);
                    break;
                case 3:
                    drawSymbolSize10(startColumn, startRow, symbolValue, colorNumber);
                    break;
            }
        }

        public static void drawSymbolSize1(int startColumn, int startRow, int symbolValue, int colorNumber)
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
        public static void drawSymbolSize5(int startColumn, int startRow, int symbolValue, int colorNumber)
        {
            Console.ForegroundColor = (ConsoleColor)colorNumber;
            if (symbolValue == 1)
            {
                Console.BackgroundColor = (ConsoleColor)colorNumber;
                Console.SetCursorPosition(startColumn, startRow);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn + 1, startRow + 1);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn + 2, startRow + 2);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn + 1, startRow + 3);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn, startRow + 4);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn + 4, startRow);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn + 3, startRow + 1);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn + 3, startRow + 3);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn + 4, startRow + 4);
                Console.Write(" ");
            }
            else if (symbolValue == 0)
            {
                Console.BackgroundColor = (ConsoleColor)colorNumber;
                Console.SetCursorPosition(startColumn, startRow + 1);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn, startRow + 2);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn, startRow + 3);
                Console.Write(" ");

                Console.SetCursorPosition(startColumn + 4, startRow + 1);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn + 4, startRow + 2);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn + 4, startRow + 3);
                Console.Write(" ");


                Console.SetCursorPosition(startColumn + 1, startRow);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn + 2, startRow);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn + 3, startRow);
                Console.Write(" ");

                Console.SetCursorPosition(startColumn + 1, startRow + 4);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn + 2, startRow + 4);
                Console.Write(" ");
                Console.SetCursorPosition(startColumn + 3, startRow + 4);
                Console.Write(" ");

            }
            else
            {
                errorOccurred("Podano zla wartosc symbolu. Wcisnij dowolny przycisk zeby zakonczyc program.\n");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void drawSymbolSize10(int startColumn, int startRow, int symbolValue, int colorNumber)
        {
            MiniSquareSymbolFragment[] points = new MiniSquareSymbolFragment[100];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    points[i * 10 + j] = new MiniSquareSymbolFragment(startColumn + j, startRow + i);

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
            else if (symbolValue == 0)
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
    }

    class CircleAndCross
    {
        private int option;
        private int startRow;
        private int startColumn;
        private int squareSize;
        private int symbolValue;
        private int colorValue;

        private int currentPositionRow;
        private int currentPositionColumn;
        private int chessSize;
        private int[] board;
        private int moveCount;

        private void initializeParameters(int option)
        {
            this.option = option;
            symbolValue = 1; //krzyz
            colorValue = 12; //czerwony
            switch (option)
            {
                case 1:
                    Draw.drawArena(13);
                    startRow = 68;
                    startColumn = 23;
                    squareSize = 3;
                    chessSize = 13;
                    currentPositionRow = 7;
                    currentPositionColumn = 7;
                    break;
                case 2:
                    Draw.drawArena(5);
                    startRow = 64;
                    startColumn = 19;
                    squareSize = 7;
                    chessSize = 5;
                    currentPositionRow = 3;
                    currentPositionColumn = 3;
                    break;
                case 3:
                    Draw.drawArena(3);
                    startRow = 62;
                    startColumn = 17;
                    squareSize = 12;
                    chessSize = 3;
                    currentPositionRow = 2;
                    currentPositionColumn = 2;
                    break;
            }
            board = new int[chessSize*chessSize];
            for(int i=0; i<board.Length; i++)
                board[i] = 0; //0 to pustka, 1 krzyzyk 2 kolko
            moveCount = 0;
        }

        public CircleAndCross(int option)
        {
            initializeParameters(option);
        }

        private int checkNeighborhood(int[] board, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin ,int currentInRow)
        {
            //if(cur) //rekurencyjne sprawddzanie na wszystkie strony
            return 0;
        }
        private int checkIfEndGame(int[] board, int moveCount, int chessSize, int currentPositionColumn, int currentPositionRow)
        {
            if(moveCount == board.Length)
                return -1; //remis

            int howMuchToWin = 0;
            if (chessSize == 3)
                howMuchToWin = 3;
            else if (chessSize == 5)
                howMuchToWin = 4;
            else if (chessSize == 13)
                howMuchToWin = 5;

            int indexBoard = (currentPositionRow - 1) * chessSize + currentPositionColumn - 1;
            int winner = checkNeighborhood(board, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin, 1);
            return winner;
        }

        private bool availableDrawSymbol(int currentPositionColumn, int currentPositionRow, int chessSize, int symbolValue)
        {
            int indexBoard = (currentPositionRow-1)*chessSize + currentPositionColumn - 1;
            if (board[indexBoard] == 0)
            {
                board[indexBoard] = symbolValue;
                return true;
            }
            return false;
        }
        private bool availableMove(ref int currentPositionRow, ref int currentPositionColumn, int chessSize, string key)
        {
            if ((key == "A" || key == "LeftArrow" || key == "NumPad4") && currentPositionColumn > 1)
            {
                currentPositionColumn -= 1;
            }
            else if ((key == "W" || key == "UpArrow" || key == "NumPad8") && currentPositionRow > 1)
            {
                currentPositionRow -= 1;
            }
            else if ((key == "S" || key == "DownArrow" || key == "NumPad2") && currentPositionRow < chessSize)
            {
                currentPositionRow += 1;
            }
            else if ((key == "D" || key == "RightArrow" || key == "NumPad6") && currentPositionColumn < chessSize)
            {
                currentPositionColumn += 1;
            }
            else
                return false;
            return true;
        }
        public void gameplay()
        {
            ConsoleKey key;
            do
            {
                //Console.SetCursorPosition(0, 0);
                //Console.WriteLine("row: " +currentPositionRow + "  column: " + currentPositionColumn);
                while (!Console.KeyAvailable)
                {
                    Draw.drawSquare(startRow, startColumn, squareSize, colorValue); //12 = red
                    System.Threading.Thread.Sleep(250);
                    Draw.drawSquare(startRow, startColumn, squareSize, 15); //15 = white
                    System.Threading.Thread.Sleep(250);
                }
                // Key is available - read it
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
                {
                    if(availableDrawSymbol(currentPositionColumn, currentPositionRow, chessSize, symbolValue))
                    {
                        Draw.drawSymbol(option, startRow + 1, startColumn + 1, symbolValue, colorValue);
                        moveCount++;
                        checkIfEndGame(board, moveCount, chessSize, currentPositionColumn, currentPositionRow);
                        if (symbolValue == 0)
                            colorValue = 12; //zmiana koloru na czerwony
                        else
                            colorValue = 9; //zmiana koloru na niebieski
                        symbolValue = (symbolValue + 1) % 2; //zmiana symbolu
                    }
                }
                else if ((key == ConsoleKey.LeftArrow || key == ConsoleKey.A || key == ConsoleKey.NumPad4) && availableMove(ref currentPositionRow, ref currentPositionColumn, chessSize, key.ToString()))
                {
                    startRow -= squareSize;
                }
                else if ((key == ConsoleKey.RightArrow || key == ConsoleKey.D || key == ConsoleKey.NumPad6) && availableMove(ref currentPositionRow, ref currentPositionColumn, chessSize, key.ToString()))
                {
                    startRow += squareSize;
                }
                else if ((key == ConsoleKey.UpArrow || key == ConsoleKey.W || key == ConsoleKey.NumPad8) && availableMove(ref currentPositionRow, ref currentPositionColumn, chessSize, key.ToString()))
                {
                    startColumn -= squareSize;
                }
                else if ((key == ConsoleKey.DownArrow || key == ConsoleKey.S || key == ConsoleKey.NumPad2) && availableMove(ref currentPositionRow, ref currentPositionColumn, chessSize, key.ToString()))
                {
                    startColumn += squareSize;
                }
            } while (key != ConsoleKey.Escape);
            //After escape set cursor at 0,0 and print "leftArrow"
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(ConsoleKey.LeftArrow.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WindowHeight = 50;
            Console.WindowWidth = 100;

            CircleAndCross c = new CircleAndCross(2);
            c.gameplay();

            for (int i=0; i<10; i++)
                Console.WriteLine();
            Console.ReadKey();
        }
    }
}
