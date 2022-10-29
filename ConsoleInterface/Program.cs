using Microsoft.VisualBasic.FileIO;
using System;
using System.Drawing;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleInterface
{
    class MiniSquareSymbolFragment
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

    static class Draw
    {
        public static void drawSubtitle(string text, int startColumn, int startRow, int colorText=15, int colorBackground=0)
        {
            if (text == "title")
            {
                text = @"                                                          __                                                        __ 
              __                                         (__)                                                      (__)
 __  ___   __/ /_      __       __  ___   ______          __         __  ___  ______     ________  ____    ____  ________  ____    ____  __  ___ 
|  |/  /  /  __  \    |  |__   |  |/  /  /  __  \        |  |       |  |/  / |   _  \   |       /  \   \  /   / |       /  \   \  /   / |  |/  / 
|  '  /  |  |  |  |  _|   _/   |  '  /  |  |  |  |       |  |       |  '  /  |  |_)  |  `---/  /    \   \/   /  `---/  /    \   \/   /  |  '  /  
|    <   |  |  |  | /_   |     |    <   |  |  |  |       |  |       |    <   |      /      /  /      \_    _/      /  /      \_    _/   |    <   
|  .  \  |  `--'  |   |  `----.|  .  \  |  `--'  |       |  |       |  .  \  |  |\  \     /  /----.    |  |       /  /----.    |  |     |  .  \  
|__|\__\  \______/    |_______||__|\__\  \______/        |__|       |__|\__\ |__| \__\   /________|    |__|      /________|    |__|     |__|\__\ 
                                                                                                                                                  ";
            }
            if(text == "Nowa gra 3x3")
            {
                text = @" _   _                         _____                _____          _____ 
| \ | |                       |  __ \              |____ |        |____ |
|  \| |  ___ __      __ __ _  | |  \/ _ __  __ _       / / __  __     / /
| . ` | / _ \\ \ /\ / // _` | | | __ | '_/ / _` |      \ \ \ \/ /     \ \
| |\  || (_) |\ V  V /| (_| | | |_\ \| |  | (_| |  .___/ /  >  <  .___/ /
|_| \_| \___/  \_/\_/  \__,_|  \____/|_|   \__,_|  \____/  /_/\_\ \____/ ";
            }
            if(text == "Nowa gra 5x5")
            {
                text = @" _   _                         _____                _____          _____ 
| \ | |                       |  __ \              |  ___|        |  ___|
|  \| |  ___ __      __ __ _  | |  \/ _ __  __ _   |___ \  __  __ |___ \ 
| . ` | / _ \\ \ /\ / // _` | | | __ | '_/ / _` |      \ \ \ \/ /     \ \
| |\  || (_) |\ V  V /| (_| | | |_\ \| |  | (_| |  /\__/ /  >  <  /\__/ /
|_| \_| \___/  \_/\_/  \__,_|  \____/|_|   \__,_|  \____/  /_/\_\ \____/ ";
            }
            if(text == "Nowa gra 13x13")
            {
                text = @" _   _                         _____                __   _____          __   _____ 
| \ | |                       |  __ \              /  | |____ |        /  | |____ |
|  \| |  ___ __      __ __ _  | |  \/ _ __  __ _   `| |     / / __  __ `| |     / /
| . ` | / _ \\ \ /\ / // _` | | | __ | '_/ / _` |   | |     \ \ \ \/ /  | |     \ \
| |\  || (_) |\ V  V /| (_| | | |_\ \| |  | (_| |  _| |_.___/ /  >  <  _| |_.___/ /
|_| \_| \___/  \_/\_/  \__,_|  \____/|_|   \__,_|  \___/\____/  /_/\_\ \___/\____/ ";
            }
            if(text == "Wczytaj gre")
            {
                text = @" _    _                    _          _                    
| |  | |                  | |        (_)                   
| |  | |  ___  ____ _   _ | |_  __ _  _    __ _  _ __  ___ 
| |/\| | / __||_  /| | | || __|/ _` || |  / _` || '__|/ _ \
\  /\  /| (__  / / | |_| || |_| (_| || | | (_| || |  |  __/
 \/  \/  \___|/___| \__, | \__|\__,_|| |  \__, ||_|   \  _|
                     __/ |          _/ |   __/ |       \_\ 
                    |___/          |__/   |___/          ";
            }
            if(text == "Wyjdz z gry")
            {
                text = @" _    _           _      _                                   
| |  | |         (_)    | |   __                             
| |  | | _   _    _   __| | _/ /_   ____    __ _  _ __  _   _ 
| |/\| || | | |  | | / _` ||_   /  |_  /   / _` || '__|| | | |
\  /\  /| |_| |  | || (_| | /  /_   / /   | (_| || |   | |_| |
 \/  \/  \__, |  | | \__,_|/____/  /___|   \__, ||_|    \__, |
          __/ | _/ |                        __/ |        __/ |
         |___/ |__/                        |___/        |___/ ";
            }
            Console.SetCursorPosition(startColumn, startRow);
            Console.BackgroundColor = (ConsoleColor) colorBackground;
            Console.ForegroundColor = (ConsoleColor) colorText;
            int counter = 0;
            for(int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                if (text[i] == '\n')
                {
                    Console.SetCursorPosition(startColumn, startRow+(++counter));
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
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

    static class Check
    {
        public static bool checkHorizontal(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin)
        {
            int right = 0, left = 0, positionColumn = currentPositionColumn;
            while(positionColumn + 1 < chessSize && board2D[currentPositionRow, positionColumn] == board2D[currentPositionRow, positionColumn + 1])
            {
                right++;
                positionColumn++;
            }
            positionColumn = currentPositionColumn;
            while (positionColumn - 1 >= 0 && board2D[currentPositionRow, positionColumn] == board2D[currentPositionRow, positionColumn - 1])
            {
                left++;
                positionColumn--;
            }

            if (right + left + 1 >= howMuchToWin)
                return true;
            else
                return false;
        }

        public static bool checkVertical(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin)
        {
            int down = 0, up = 0, positionRow = currentPositionRow;
            while (positionRow + 1 < chessSize && board2D[positionRow, currentPositionColumn] == board2D[positionRow + 1, currentPositionColumn])
            {
                down++;
                positionRow++;
            }
            positionRow = currentPositionRow;
            while (positionRow - 1 >= 0 && board2D[positionRow, currentPositionColumn] == board2D[positionRow - 1, currentPositionColumn])
            {
                up++;
                positionRow--;
            }

            if (down + up + 1 >= howMuchToWin)
                return true;
            else
                return false;
        }

        public static bool checkDiagonalUpDown(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin)
        {
            int rightDown = 0, leftUp = 0;
            int positionRow = currentPositionRow, positionColumn = currentPositionColumn;
            while (positionRow + 1 < chessSize && positionColumn +1 < chessSize && board2D[positionRow, positionColumn] == board2D[positionRow+1, positionColumn+1])
            {
                rightDown++;
                positionRow++;
                positionColumn++;
            }
            positionRow = currentPositionRow;
            positionColumn = currentPositionColumn;
            while (positionRow - 1 >= 0 && positionColumn -1 >= 0 && board2D[positionRow, positionColumn] == board2D[positionRow - 1, positionColumn-1])
            {
                leftUp++;
                positionRow--;
                positionColumn--;
            }
            if (rightDown + leftUp + 1 >= howMuchToWin)
                return true;
            else
                return false;
        }

        public static bool checkDiagonalDownUp(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin)
        {
            int rightUp = 0, leftDown = 0;
            int positionRow = currentPositionRow, positionColumn = currentPositionColumn;
            while (positionRow -1 >= 0 && positionColumn + 1 < chessSize && board2D[positionRow, positionColumn] == board2D[positionRow - 1, positionColumn + 1])
            {
                rightUp++;
                positionRow--;
                positionColumn++;
            }
            positionRow = currentPositionRow;
            positionColumn = currentPositionColumn;
            while (positionRow + 1 < chessSize && positionColumn - 1 >= 0 && board2D[positionRow, positionColumn] == board2D[positionRow + 1, positionColumn - 1])
            {
                leftDown++;
                positionRow++;
                positionColumn--;
            }
            if (rightUp + leftDown + 1 >= howMuchToWin)
                return true;
            else
                return false;
        }

        public static int checkWin(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin)
        {
            if (checkHorizontal(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin))
                return 1; //zwycieztwo poziome
            else if (checkVertical(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin))
                return 2; //zwycieztwo pionowe
            else if (checkDiagonalUpDown(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin))
                return 3; //zwycieztwo \
            else if (checkDiagonalDownUp(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin))
                return 4; //zwycieztwo /
            return 0; //nie bylo wygranej
        }

        public static int checkIfEndGame(int[,] board2D, int moveCount, int chessSize, int currentPositionColumn, int currentPositionRow)
        {
            if (moveCount == board2D.Length)
                return -1; //remis

            int howMuchToWin = 0;
            if (chessSize == 3)
                howMuchToWin = 3;
            else if (chessSize == 5)
                howMuchToWin = 4;
            else if (chessSize == 13)
                howMuchToWin = 5;

            int indexBoard = (currentPositionRow - 1) * chessSize + currentPositionColumn - 1;
            int winner = checkWin(board2D, chessSize, currentPositionColumn - 1, currentPositionRow - 1, howMuchToWin);
            return winner;
        }

        public static bool availableDrawSymbol(int[,] board2D, int currentPositionColumn, int currentPositionRow, int chessSize, int symbolValue)
        {
            //Console.SetCursorPosition(0, 0);
            //Console.WriteLine("row: " +currentPositionRow + "  column: " + currentPositionColumn + "   :"+ board2D[currentPositionRow-1, currentPositionColumn-1]);

            /*int indexBoard = (currentPositionRow - 1) * chessSize + currentPositionColumn - 1;
            if (board[indexBoard] == -1)
            {
                board[indexBoard] = symbolValue;
                return true;
            }*/
            if (board2D[currentPositionRow - 1, currentPositionColumn - 1] == -1)
            {
                board2D[currentPositionRow - 1, currentPositionColumn - 1] = symbolValue;
                //Console.SetCursorPosition(0, 1);
                //Console.WriteLine("row: " + currentPositionRow + "  column: " + currentPositionColumn + "   :" + board2D[currentPositionRow, currentPositionColumn]);
                return true;
            }

            return false;
        }
        public static bool availableMove(ref int currentPositionRow, ref int currentPositionColumn, int chessSize, string key)
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
    }

    class CircleAndCross
    {
        private int option;
        private int startColumn;
        private int startRow;
        private int squareSize;
        private int symbolValue;
        private int colorValue;
        private int currentPositionRow;
        private int currentPositionColumn;
        private int chessSize;
        private int[,] board2D;
        private int moveCount;
        private int wayToWin;
        private int winner;
        private int startArenaRow;
        private int startArenaColumn;

        private void initializeParameters(int option, int startArenaRow, int startArenaColumn)
        {
            this.option = option;
            this.startArenaRow = startArenaRow;
            this.startArenaColumn = startArenaColumn;
            symbolValue = 1; //krzyz
            colorValue = 12; //czerwony
            switch (option)
            {
                case 1:
                    Draw.drawArena(13, startArenaColumn, startArenaRow);
                    startColumn = startArenaColumn + 18;//68;
                    startRow = startArenaRow + 18;//23;
                    squareSize = 3;
                    chessSize = 13;
                    currentPositionRow = 7;
                    currentPositionColumn = 7;
                    break;
                case 2:
                    Draw.drawArena(5, startArenaColumn, startArenaRow);
                    startColumn = startArenaColumn + 14;//64;
                    startRow = startArenaRow + 14;//19;
                    squareSize = 7;
                    chessSize = 5;
                    currentPositionRow = 3;
                    currentPositionColumn = 3;
                    break;
                case 3:
                    Draw.drawArena(3, startArenaColumn, startArenaRow);
                    startColumn = startArenaColumn + 12;//62;
                    startRow = startArenaRow + 12;//17;
                    squareSize = 12;
                    chessSize = 3;
                    currentPositionRow = 2;
                    currentPositionColumn = 2;
                    break;
            }
            board2D = new int[chessSize, chessSize];
            for (int i = 0; i < chessSize; i++)
                for (int j = 0; j < chessSize; j++)
                    board2D[i, j] = -1;
            moveCount = 0;
            wayToWin = 0;
            winner = 0;
        }

        public CircleAndCross(int option, int startArenaRow = 10, int startArenaColumn = 50)
        {
            initializeParameters(option, startArenaRow, startArenaColumn);
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
                    Draw.drawSquare(startColumn, startRow, squareSize, colorValue); //12 = red
                    System.Threading.Thread.Sleep(250);
                    Draw.drawSquare(startColumn, startRow, squareSize, 15); //15 = white
                    System.Threading.Thread.Sleep(250);
                }
                // Key is available - read it
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
                {
                    if(Check.availableDrawSymbol(board2D, currentPositionColumn, currentPositionRow, chessSize, symbolValue))
                    {
                        Draw.drawSymbol(option, startColumn + 1, startRow + 1, symbolValue, colorValue);
                        moveCount++;
                        wayToWin = Check.checkIfEndGame(board2D, moveCount, chessSize, currentPositionColumn, currentPositionRow);
                        if (wayToWin != 0)
                        {
                            if (wayToWin > 0)
                                winner = board2D[currentPositionRow-1, currentPositionColumn-1];
                            break;
                        }

                        if (symbolValue == 0) // 0 to kolko
                            colorValue = 12; //zmiana koloru na czerwony
                        else // 1 to krzyz
                            colorValue = 9; //zmiana koloru na niebieski
                        symbolValue = (symbolValue + 1) % 2; //zmiana symbolu
                    }
                }
                else if ((key == ConsoleKey.LeftArrow || key == ConsoleKey.A || key == ConsoleKey.NumPad4) && Check.availableMove(ref currentPositionRow, ref currentPositionColumn, chessSize, key.ToString()))
                {
                    startColumn -= squareSize;
                }
                else if ((key == ConsoleKey.RightArrow || key == ConsoleKey.D || key == ConsoleKey.NumPad6) && Check.availableMove(ref currentPositionRow, ref currentPositionColumn, chessSize, key.ToString()))
                {
                    startColumn += squareSize;
                }
                else if ((key == ConsoleKey.UpArrow || key == ConsoleKey.W || key == ConsoleKey.NumPad8) && Check.availableMove(ref currentPositionRow, ref currentPositionColumn, chessSize, key.ToString()))
                {
                    startRow -= squareSize;
                }
                else if ((key == ConsoleKey.DownArrow || key == ConsoleKey.S || key == ConsoleKey.NumPad2) && Check.availableMove(ref currentPositionRow, ref currentPositionColumn, chessSize, key.ToString()))
                {
                    startRow += squareSize;
                }
            } while (key != ConsoleKey.Escape);
            //After escape set cursor at 0,0 and print "leftArrow"
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(ConsoleKey.LeftArrow.ToString());

            /*Console.SetCursorPosition(0, 5);
            Console.WriteLine("zwyciezca: " + winner + " sposob zwycieztwa: " + wayToWin);
            Console.WriteLine("Tablica");
            for (int i = 0; i < chessSize; i++)
            {
                for (int j = 0; j < chessSize; j++)
                {
                    Console.Write(board2D[i, j]+" ");
                }
                Console.WriteLine();
            }*/
        }
    }

    class Program
    {
        static void setResolution()
        {
            try
            {
                Console.WindowHeight = 70; //70
                Console.WindowWidth = 150; //150
            }
            catch (System.ArgumentOutOfRangeException error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 7, Console.LargestWindowHeight / 2 - 2);
                Console.WriteLine("-- Warning --");
                Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 40, Console.LargestWindowHeight / 2 - 1);
                Console.WriteLine("Your screen isn't big enough to match the game's desired width and hight.");
                Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 45, Console.LargestWindowHeight / 2);
                Console.WriteLine("Things may not look quite right, unless you adjust the text size in your console window.");
                Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 10, Console.LargestWindowHeight / 2 + 1);
                waitForKey(ConsoleKey.Enter);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WindowHeight = Console.LargestWindowHeight;
                Console.WindowWidth = Console.LargestWindowWidth;
            }
        }
        static void waitForKey(ConsoleKey expectedKey = ConsoleKey.Home)
        {
            if (expectedKey != ConsoleKey.Home)
            {
                Console.WriteLine($"Press {expectedKey} key to continue.");
                while (Console.ReadKey().Key != expectedKey){}
            }
            else
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            Console.Clear();
        }

        static void drawOptionFirstMenu() 
        {
            //Main menu
            Draw.drawSubtitle("title", 5, 1, 12);
            Draw.drawRectangle(25, 10, 11, 100, 15);
            Draw.drawSubtitle("Nowa gra 3x3", 38, 12);
            Draw.drawRectangle(25, 21, 11, 100, 15);
            Draw.drawSubtitle("Nowa gra 5x5", 38, 23);
            Draw.drawRectangle(25, 32, 11, 100, 15);
            Draw.drawSubtitle("Nowa gra 13x13", 34, 34);
            Draw.drawRectangle(25, 43, 11, 100, 15);
            Draw.drawSubtitle("Wczytaj gre", 45, 44);
            Draw.drawRectangle(25, 54, 11, 100, 15);
            Draw.drawSubtitle("Wyjdz z gry", 45, 55);
            Console.SetCursorPosition(25, 67);
            Console.WriteLine("Zmieniaj opcje używając strzałek góra/dół lub W/S. Zatwierdź wybraną opcję klikając Enter lub Spację. Miłej gry :)");

            int startColumn=25, startRow=10 , startColumnSubtitle = 38, startRowSubtitle = 11;
            int option = 0;
            string text = "Nowa gra 3x3";

            ConsoleKey key;
            do
            {
                while (!Console.KeyAvailable)
                {
                    switch(option)
                    {
                        case 0:
                            startColumnSubtitle = 38;
                            startRowSubtitle = 12;
                            text = "Nowa gra 3x3";
                            break;
                        case 1:
                            startColumnSubtitle = 38;
                            startRowSubtitle = 23;
                            text = "Nowa gra 5x5";
                            break;
                        case 2:
                            startColumnSubtitle = 34;
                            startRowSubtitle = 34;
                            text = "Nowa gra 13x13";
                            break;
                        case 3:
                            startColumnSubtitle = 45;
                            startRowSubtitle = 44;
                            text = "Wczytaj gre";
                            break;
                        case 4:
                            startColumnSubtitle = 45;
                            startRowSubtitle = 55;
                            text = "Wyjdz z gry";
                            break;
                    }
                    startRow = 10 + 11 * option;
                    Draw.drawRectangle(startColumn, startRow, 11, 100, 12); //12 = red
                    Draw.drawSubtitle(text, startColumnSubtitle, startRowSubtitle, 12);
                    System.Threading.Thread.Sleep(500);
                    Draw.drawRectangle(startColumn, startRow, 11, 100, 15); //15 = white
                    Draw.drawSubtitle(text, startColumnSubtitle, startRowSubtitle, 15);
                    System.Threading.Thread.Sleep(500);
                }
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("SUPER DZIALA");
                }
                else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
                {
                    if (option > 0)
                        option--;
                    else
                        option = 4;

                }
                else if(key == ConsoleKey.DownArrow || key == ConsoleKey.S)
                {
                    if(option < 4)
                        option++;
                    else
                        option = 0;
                }
            } while (key != ConsoleKey.Escape);
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            setResolution();
            drawOptionFirstMenu();


            Console.SetCursorPosition(0, 0);
            /*CircleAndCross c = new CircleAndCross(2);
            c.gameplay();*/
            for (int i=0; i<10; i++)
                Console.WriteLine();
            Console.ReadKey();
        }
    }
}
