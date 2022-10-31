﻿using System;
using System.Collections.Generic;
using System.IO;
/*using System.Text;
using System.Threading;
using System.Threading.Tasks;*/
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

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
        public static int adjustToCenterText(int startRow, int endColumn, int length)
        {
            return (endColumn + startRow - length) / 2;
        }
        public static void drawSubtitle(string text, int startColumn, int startRow, int colorText=15, int colorBackground=0)
        {
            text = text.ToLower();
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
            if (text == "kolko")
            {
                text = @"              __    
 __  ___   __/ /_      __       __  ___   ______ 
|  |/  /  /  __  \    |  |__   |  |/  /  /  __  \ 
|  '  /  |  |  |  |  _|   _/   |  '  /  |  |  |  |
|    <   |  |  |  | /_   |     |    <   |  |  |  | 
|  .  \  |  `--'  |   |  `----.|  .  \  |  `--'  | 
|__|\__\  \______/    |_______||__|\__\  \______/ ";
            }
            if (text == "i")
            {
                text = @" __
(__)
 __ 
|  |
|  |
|  |
|  |
|__|";
            }
            if (text == "krzyzyk")
            {
                text = @"                                                __ 
                                               (__)
 __  ___  ______     ________  ____    ____  ________  ____    ____  __  ___
|  |/  / |   _  \   |       /  \   \  /   / |       /  \   \  /   / |  |/  /
|  '  /  |  |_)  |  `---/  /    \   \/   /  `---/  /    \   \/   /  |  '  / 
|    <   |      /      /  /      \_    _/      /  /      \_    _/   |    <  
|  .  \  |  |\  \     /  /----.    |  |       /  /----.    |  |     |  .  \ 
|__|\__\ |__| \__\   /________|    |__|      /________|    |__|     |__|\__\
                                                                                                                                                ";
            }
            if (text == "nowa gra 3x3")
            {
                text = @" _   _                         _____                _____          _____ 
| \ | |                       |  __ \              |____ |        |____ |
|  \| |  ___ __      __ __ _  | |  \/ _ __  __ _       / / __  __     / /
| . ` | / _ \\ \ /\ / // _` | | | __ | '_/ / _` |      \ \ \ \/ /     \ \
| |\  || (_) |\ V  V /| (_| | | |_\ \| |  | (_| |  .___/ /  >  <  .___/ /
|_| \_| \___/  \_/\_/  \__,_|  \____/|_|   \__,_|  \____/  /_/\_\ \____/ ";
            }
            if(text == "nowa gra 5x5")
            {
                text = @" _   _                         _____                _____          _____ 
| \ | |                       |  __ \              |  ___|        |  ___|
|  \| |  ___ __      __ __ _  | |  \/ _ __  __ _   |___ \  __  __ |___ \ 
| . ` | / _ \\ \ /\ / // _` | | | __ | '_/ / _` |      \ \ \ \/ /     \ \
| |\  || (_) |\ V  V /| (_| | | |_\ \| |  | (_| |  /\__/ /  >  <  /\__/ /
|_| \_| \___/  \_/\_/  \__,_|  \____/|_|   \__,_|  \____/  /_/\_\ \____/ ";
            }
            if(text == "nowa gra 13x13")
            {
                text = @" _   _                         _____                __   ______         __   ______ 
| \ | |                       |  __ \              /  | |____  |       /  | |____  |
|  \| |  ___ __      __ __ _  | |  \/ _ __  __ _   `| |     / / __  __ `| |     / /
| . ` | / _ \\ \ /\ / // _` | | | __ | '_/ / _` |   | |     \ \ \ \/ /  | |     \ \
| |\  || (_) |\ V  V /| (_| | | |_\ \| |  | (_| |   | | .___/ /  >  <  _| |_.___/ /
|_| \_| \___/  \_/\_/  \__,_|  \____/|_|   \__,_|   |_| \____/  /_/\_\ \___/\____/ ";
            }
            if(text == "wczytaj gre")
            {
                text = @" _    _                    _          _                    
| |  | |                  | |        (_)                   
| |  | |  ___  ____ _   _ | |_  __ _  _    __ _  _ __  ___ 
| |/\| | / __||_  /| | | || __|/ _` || |  / _` || '__|/ _ \
\  /\  /| (__  / / | |_| || |_| (_| || | | (_| || |  |  __/
 \/  \/  \___|/___| \__, | \__|\__,_|| |  \__, ||_|   \  _|
                     __/ |          _/ |   __/ |       (_( 
                    |___/          |__/   |___/          ";
            }
            if(text == "wyjdz z gry")
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
            if(text == "ruch")
            {
                text = @"  ____                   _         
 |  _ \   _   _    ___  | |__    _ 
 | |_) | | | | |  / __| | '_ \  (_)
 |  _ <  | |_| | | (__  | | | |  _ 
 |_| \_\  \__,_|  \___| |_| |_| (_)";
            }
            if (text == "1")
            {
                text = @" __  __ 
 \ \/ / 
  \  /  
  /  \  
 /_/\_\ ";
            }
            if (text == "0")
            {
                text = @"   ___  
  / _ \ 
 | | | |
 | |_| |
  \___/ ";
            }
            if (text == "wygrały")
            {
                text = @" __        __                                _             
 \ \      / /  _   _    __ _   _ __   __ _  | |  _   _   _ 
  \ \ /\ / /  | | | |  / _` | | '__| / _` | |// | | | | (_)
   \ V  V /   | |_| | | (_| | | |   | (_| | //| | |_| |  _ 
    \_/\_/     \__, |  \__, | |_|    \__,_| |_|  \__, | (_)
               |___/   |___/                      |___/     ";
            }
            if (text == "remis")
            {
                text = @"  ____                       _       
 |  _ \    ___   _ __ ___   (_)  ___ 
 | |_) |  / _ \ | '_ ` _ \  | | / __|
 |  _ <  |  __/ | | | | | | | | \__ \
 |_| \_\  \___| |_| |_| |_| |_| |___/";
            }
            /*if (text == "O")
            {
                text = @"";
            }*/
            if(text == "czysc")
            {
                text = "";
                for(int i=0; i< 10; i++)
                {
                    for (int j = 0; j < 150; j++)
                        text += " ";
                    text += "\n";
                }
            }
            if (text == "nowa gra - wcisnij enter")
            {
                text = @"  _   _                                                                    _    __        _    _    _____         _              
 | \ | |  ___ __      __ __ _    __ _  _ __  __ _          __      __ ___ (_) _/_/ _ __  (_)  (_)  | ____| _ __  | |_   ___  _ __ 
 |  \| | / _ \\ \ /\ / // _` |  / _` || '__|/ _` |  _____  \ \ /\ / // __|| |/ __|| '_ \ | |  | |  |  _|  | '_ \ | __| / _ \| '__|
 | |\  || (_) |\ V  V /| (_| | | (_| || |  | (_| | |_____|  \ V  V /| (__ | |\__ \| | | || |  | |  | |___ | | | || |_ |  __/| |   
 |_| \_| \___/  \_/\_/  \__,_|  \__, ||_|   \__,_|           \_/\_/  \___||_||___/|_| |_||_| _/ |  |_____||_| |_| \__| \___||_|   
                                |___/                                                       |__/                                ";
            }
            if (text == "menu - wcisnij escape")
            {
                text = @"  __  __                                              _    __        _    _    _____                               
 |  \/  |  ___  _ __   _   _          __      __ ___ (_) _/_/ _ __  (_)  (_)  | ____| ___   ___  __ _  _ __    ___ 
 | |\/| | / _ \| '_ \ | | | |  _____  \ \ /\ / // __|| |/ __|| '_ \ | |  | |  |  _|  / __| / __|/ _` || '_ \  / _ \
 | |  | ||  __/| | | || |_| | |_____|  \ V  V /| (__ | |\__ \| | | || |  | |  | |___ \__ \| (__| (_| || |_) ||  __/
 |_|  |_| \___||_| |_| \__,_|           \_/\_/  \___||_||___/|_| |_||_| _/ |  |_____||___/ \___|\__,_|| .__/  \___|
                                                                       |__/                           |_|          ";
            }
            if (text == "trzy")
            {
                text = @" 333333333333333   
3:::::::::::::::33 
3::::::33333::::::3
3333333     3:::::3
            3:::::3
            3:::::3
    33333333:::::3 
    3:::::::::::3  
    33333333:::::3 
            3:::::3
            3:::::3
            3:::::3
3333333     3:::::3
3::::::33333::::::3
3:::::::::::::::33 
 333333333333333   ";
            }
            if (text == "dwa")
            {
                text = @" 222222222222222    
2:::::::::::::::22  
2::::::222222:::::2 
2222222     2:::::2 
            2:::::2 
            2:::::2 
         2222::::2  
    22222::::::22   
  22::::::::222     
 2:::::22222        
2:::::2             
2:::::2             
2:::::2       222222
2::::::2222222:::::2
2::::::::::::::::::2
22222222222222222222";
            }
            if (text == "jeden")
            {
                text = @"  1111111   
 1::::::1   
1:::::::1   
111:::::1   
   1::::1   
   1::::1   
   1::::1   
   1::::l   
   1::::l   
   1::::l   
   1::::l   
   1::::l   
111::::::111
1::::::::::1
1::::::::::1
111111111111";
            }
            if (text == "start")
            {
                text = @"   SSSSSSSSSSSSSSS TTTTTTTTTTTTTTTTTTTTTTT               AAA               RRRRRRRRRRRRRRRRR   TTTTTTTTTTTTTTTTTTTTTTT
 SS:::::::::::::::ST:::::::::::::::::::::T              A:::A              R::::::::::::::::R  T:::::::::::::::::::::T
S:::::SSSSSS::::::ST:::::::::::::::::::::T             A:::::A             R::::::RRRRRR:::::R T:::::::::::::::::::::T
S:::::S     SSSSSSST:::::TT:::::::TT:::::T            A:::::::A            RR:::::R     R:::::RT:::::TT:::::::TT:::::T
S:::::S            TTTTTT  T:::::T  TTTTTT           A:::::::::A             R::::R     R:::::RTTTTTT  T:::::T  TTTTTT
S:::::S                    T:::::T                  A:::::A:::::A            R::::R     R:::::R        T:::::T        
 S::::SSSS                 T:::::T                 A:::::A A:::::A           R::::RRRRRR:::::R         T:::::T        
  SS::::::SSSSS            T:::::T                A:::::A   A:::::A          R:::::::::::::RR          T:::::T        
    SSS::::::::SS          T:::::T               A:::::A     A:::::A         R::::RRRRRR:::::R         T:::::T        
       SSSSSS::::S         T:::::T              A:::::AAAAAAAAA:::::A        R::::R     R:::::R        T:::::T        
            S:::::S        T:::::T             A:::::::::::::::::::::A       R::::R     R:::::R        T:::::T        
            S:::::S        T:::::T            A:::::AAAAAAAAAAAAA:::::A      R::::R     R:::::R        T:::::T        
SSSSSSS     S:::::S      TT:::::::TT         A:::::A             A:::::A   RR:::::R     R:::::R      TT:::::::TT      
S::::::SSSSSS:::::S      T:::::::::T        A:::::A               A:::::A  R::::::R     R:::::R      T:::::::::T      
S:::::::::::::::SS       T:::::::::T       A:::::A                 A:::::A R::::::R     R:::::R      T:::::::::T      
 SSSSSSSSSSSSSSS         TTTTTTTTTTT      AAAAAAA                   AAAAAAARRRRRRRR     RRRRRRR      TTTTTTTTTTT      ";
            }
            if (text == "kontynuuj gre")
            {
                text = @"  _  __              _                                  _                    
 | |/ / ___   _ __  | |_  _   _  _ __   _   _  _   _   (_)    __ _  _ __  ___ 
 | ' / / _ \ | '_ \ | __|| | | || '_ \ | | | || | | |  | |   / _` || '__|/ _ \
 | . \| (_) || | | || |_ | |_| || | | || |_| || |_| |  | |  | (_| || |  |  __/
 |_|\_\\___/ |_| |_| \__| \__, ||_| |_| \__,_| \__,_| _/ |   \__, ||_|   \___|
                          |___/                      |__/    |___/         (_(";
            }
            if (text == "zapisz gre")
            {
                text = @"  _____              _                              
 |__  / __ _  _ __  (_) ___  ____   __ _  _ __  ___ 
   / / / _` || '_ \ | |/ __||_  /  / _` || '__|/ _ \
  / /_| (_| || |_) || |\__ \ / /  | (_| || |  |  __/
 /____|\__,_|| .__/ |_||___//___|  \__, ||_|   \___|
             |_|                   |___/         (_(";
            }
            if (text == "wyjdz do menu")
            {
                text = @" __        __        _      _    _       _                                        
 \ \      / /_   _  (_)  __| | _/_/   __| |  ___    _ __ ___    ___  _ __   _   _ 
  \ \ /\ / /| | | | | | / _` ||_  /  / _` | / _ \  | '_ ` _ \  / _ \| '_ \ | | | |
   \ V  V / | |_| | | || (_| | / /  | (_| || (_) | | | | | | ||  __/| | | || |_| |
    \_/\_/   \__, |_/ | \__,_|/___|  \__,_| \___/  |_| |_| |_| \___||_| |_| \__,_|
             |___/|__/                                                            ";
            }
            if (text == "")
                return;

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
        public static void drawArena(int arenaSize, int startColumn = 50, int startRow = 56)
        {
            int squareSize = 10;
            uploadParametrs(arenaSize, ref squareSize);
            for (int i = 0; i < arenaSize; i++)
            {
                for (int j = 0; j < arenaSize; j++)
                    drawSquare(startColumn + i * squareSize, startRow + j * squareSize, squareSize, 15);
            }
        }

        public static void printInstructionInGame(int howMuchToWin, int column, int row)
        {
            Console.SetCursorPosition(column, row);//25 53
            string infix = (howMuchToWin == 5) ? "i" : "e";
            Console.WriteLine($"Cel gry: Ułożyć {howMuchToWin} symbol" + infix + " w jednej linii poziomo, pionowo lub ukośnie zanim zrobi to twój przeciwnik.");
            Console.SetCursorPosition(25, 56);
            Console.WriteLine("Sterowanie:");
            Console.SetCursorPosition(25, 57);
            Console.WriteLine("Do zmiany aktualnej pozycji używaj strzałek, WASD lub strzałek z klawiatury numerycznej (2,4,6,8)");
            Console.SetCursorPosition(25, 59);
            Console.WriteLine("Stawiaj symbol klikając Enter lub Spację.");
            Console.SetCursorPosition(25, 61);
            Console.WriteLine("Kliknij ESCAPE żeby otworzyć menu opcji. (możliwość zapisania, zakończenia lub wybrania innej gry)");
        }

        public static void drawSymbol(int option, int startColumn, int startRow, int symbolValue, int colorNumber)
        {
            switch (option)
            {
                case 0:
                    drawSymbolSize1(startColumn, startRow, symbolValue, colorNumber);
                    break;
                case 1:
                    drawSymbolSize5(startColumn, startRow, symbolValue, colorNumber);
                    break;
                case 2:
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
        public static void drawWinningSquares(List<int> squares, int startColumn, int startRow, int squareSize, int option, int symbolValue, int colorSymbolValue = 6, int colorSquareValue=6)
        {
            for(int i=0; i<squares.Count; i+=2)
            {
                drawSquare(startColumn + squares[i+1]*squareSize, startRow + squares[i] * squareSize, squareSize, colorSquareValue);
                drawSymbol(option, startColumn + squares[i + 1] * squareSize + 1, startRow + squares[i] * squareSize + 1, symbolValue, colorSymbolValue);
            }
        }
        public static void drawFirstMenu(int startRow = 0)
        {
            int littleHight = 10, actualRow = startRow;
            //Main menu
            Draw.drawSubtitle("kolko", 2, actualRow + 1, 1);
            Draw.drawSubtitle("i", 59, actualRow, 6);
            Draw.drawSubtitle("krzyzyk", 70, actualRow, 4);
            actualRow += 10;
            Draw.drawRectangle(25, actualRow, littleHight, 100, 15);
            Draw.drawSubtitle("Nowa gra 3x3", Draw.adjustToCenterText(25, 125, 74), actualRow + 2);
            actualRow += littleHight;
            Draw.drawRectangle(25, actualRow, littleHight, 100, 15);
            Draw.drawSubtitle("Nowa gra 5x5", Draw.adjustToCenterText(25, 125, 74), actualRow + 2);
            actualRow += littleHight;
            Draw.drawRectangle(25, actualRow, littleHight, 100, 15);
            Draw.drawSubtitle("Nowa gra 13x13", Draw.adjustToCenterText(25, 125, 84), actualRow + 2);
            actualRow += littleHight;
            Draw.drawRectangle(25, actualRow, 10, 100, 15);
            Draw.drawSubtitle("Wczytaj gre", Draw.adjustToCenterText(25, 125, 60), actualRow + 1);
            actualRow += littleHight;
            Draw.drawRectangle(25, actualRow, 10, 100, 15);
            Draw.drawSubtitle("Wyjdz z gry", Draw.adjustToCenterText(25, 125, 63), actualRow + 1);
            Console.SetCursorPosition(17, actualRow + 12);
            Console.WriteLine("Zmieniaj opcje używając strzałek góra/dół lub W/S. Zatwierdź wybraną opcję klikając Enter lub Spację. Miłej gry :)");
            Console.SetCursorPosition(0, 0);
        }

        public static void drawContinuedMenu(int startRow = 0)
        {
            Console.Clear();
            int littleHight = 10, actualRow = startRow;
            //Continued menu
            Draw.drawSubtitle("kolko", 2, actualRow + 1, 1);
            Draw.drawSubtitle("i", 59, actualRow, 6);
            Draw.drawSubtitle("krzyzyk", 70, actualRow, 4);
            actualRow += 10;
            Draw.drawRectangle(25, actualRow, littleHight, 100, 15);
            Draw.drawSubtitle("kontynuuj gre", Draw.adjustToCenterText(25, 125, 79), actualRow + 2);
            actualRow += littleHight;
            Draw.drawRectangle(25, actualRow, littleHight, 100, 15);
            Draw.drawSubtitle("zapisz gre", Draw.adjustToCenterText(25, 125, 53), actualRow + 2);
            actualRow += littleHight;
            Draw.drawRectangle(25, actualRow, littleHight, 100, 15);
            Draw.drawSubtitle("wyjdz do menu", Draw.adjustToCenterText(25, 125, 83), actualRow + 2);
            actualRow += littleHight;
            Draw.drawRectangle(25, actualRow, 10, 100, 15);
            Draw.drawSubtitle("wyjdz z gry", Draw.adjustToCenterText(25, 125, 63), actualRow + 1);
            Console.SetCursorPosition(17, actualRow + 12);
            Console.WriteLine("Zmieniaj opcje używając strzałek góra/dół lub W/S. Zatwierdź wybraną opcję klikając Enter lub Spację. Miłej gry :)");
            Console.SetCursorPosition(0, 0);
        }

        public static int chooseOptionContinuedMenu(int startColumn = 25, int option = 0)
        {
            int startRow = 0, startColumnSubtitle = 0, startRowSubtitle = 0;
            string text = "";
            ConsoleKey key;
            do
            {
                while (!Console.KeyAvailable)
                {
                    switch (option)
                    {
                        case 0:
                            startColumnSubtitle = Draw.adjustToCenterText(25, 125, 79);//38;
                            startRowSubtitle = 12;
                            startRow = startRowSubtitle - 2;
                            text = "kontynuuj gre";
                            break;
                        case 1:
                            startColumnSubtitle = Draw.adjustToCenterText(25, 125, 53);
                            startRowSubtitle = 22;
                            startRow = startRowSubtitle - 2;
                            text = "zapisz gre";
                            break;
                        case 2:
                            startColumnSubtitle = Draw.adjustToCenterText(25, 125, 83);
                            startRowSubtitle = 32;
                            startRow = startRowSubtitle - 2;
                            text = "wyjdz do menu";
                            break;
                        case 3:
                            startColumnSubtitle = Draw.adjustToCenterText(25, 125, 63);
                            startRowSubtitle = 41;
                            startRow = startRowSubtitle - 1;
                            text = "wyjdz z gry";
                            break;
                    }
                    Draw.drawRectangle(startColumn, startRow, 10, 100, 4); //4 = red
                    Draw.drawSubtitle(text, startColumnSubtitle, startRowSubtitle, 4);
                    System.Threading.Thread.Sleep(500);
                    Draw.drawRectangle(startColumn, startRow, 10, 100, 15); //15 = white
                    Draw.drawSubtitle(text, startColumnSubtitle, startRowSubtitle, 15);
                    System.Threading.Thread.Sleep(500);
                }
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    return ++option;
                }
                else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
                {
                    if (option > 0)
                        option--;
                    else
                        option = 3;
                }
                else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
                {
                    option = (option + 1) % 4;
                }
            } while (true);
        }
        public static void redrawBoardWithSymbols(int[,] board2D, int option, int chessSize, int squareSize, int startArenaColumn, int startArenaRow, int startColumn, int startRow)
        {
            drawArena(chessSize, startArenaColumn, startArenaRow);
            int tempStartColumn = startColumn, tempStartRow = startRow;
            for (int i = 0; i < chessSize; i++)
            {
                for (int j = 0; j < chessSize; j++)
                {
                    if (board2D[i, j] == 1)
                        drawSymbol(option, tempStartColumn, tempStartRow, board2D[i, j], 4);
                    if (board2D[i, j] == 0)
                        drawSymbol(option, tempStartColumn, tempStartRow, board2D[i, j], 1);
                    tempStartColumn += squareSize;
                }
                tempStartColumn = startColumn;
                tempStartRow += squareSize;
            }
        }
    }

    static class Check
    {
        public static List<int> checkHorizontal(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin)
        {
            List<int> result = new List<int>();
            int right = 0, left = 0, positionColumn = currentPositionColumn;
            while(positionColumn + 1 < chessSize && board2D[currentPositionRow, positionColumn] == board2D[currentPositionRow, positionColumn + 1])
            {
                right++;
                positionColumn++;
                result.Add(currentPositionRow);
                result.Add(positionColumn);
            }
            positionColumn = currentPositionColumn;
            while (positionColumn - 1 >= 0 && board2D[currentPositionRow, positionColumn] == board2D[currentPositionRow, positionColumn - 1])
            {
                left++;
                positionColumn--;
                result.Add(currentPositionRow);
                result.Add(positionColumn);
            }

            if (right + left + 1 >= howMuchToWin)
            {
                result.Add(currentPositionRow);
                result.Add(currentPositionColumn);
                return result;
            }
            else
                return null;
        }

        public static List<int> checkVertical(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin)
        {
            List<int> result = new List<int>();
            int down = 0, up = 0, positionRow = currentPositionRow;
            while (positionRow + 1 < chessSize && board2D[positionRow, currentPositionColumn] == board2D[positionRow + 1, currentPositionColumn])
            {
                down++;
                positionRow++;
                result.Add(positionRow);
                result.Add(currentPositionColumn);
            }
            positionRow = currentPositionRow;
            while (positionRow - 1 >= 0 && board2D[positionRow, currentPositionColumn] == board2D[positionRow - 1, currentPositionColumn])
            {
                up++;
                positionRow--;
                result.Add(positionRow);
                result.Add(currentPositionColumn);
            }

            if (down + up + 1 >= howMuchToWin)
            {
                result.Add(currentPositionRow);
                result.Add(currentPositionColumn);
                return result;
            }
            else
                return null;
        }

        public static List<int> checkDiagonalUpDown(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin)
        {
            List<int> result = new List<int>();
            int rightDown = 0, leftUp = 0;
            int positionRow = currentPositionRow, positionColumn = currentPositionColumn;
            while (positionRow + 1 < chessSize && positionColumn + 1 < chessSize && board2D[positionRow, positionColumn] == board2D[positionRow + 1, positionColumn + 1])
            {
                rightDown++;
                positionRow++;
                positionColumn++;
                result.Add(positionRow);
                result.Add(positionColumn);
            }
            positionRow = currentPositionRow;
            positionColumn = currentPositionColumn;
            while (positionRow - 1 >= 0 && positionColumn - 1 >= 0 && board2D[positionRow, positionColumn] == board2D[positionRow - 1, positionColumn - 1])
            {
                leftUp++;
                positionRow--;
                positionColumn--;
                result.Add(positionRow);
                result.Add(positionColumn);
            }
            if (rightDown + leftUp + 1 >= howMuchToWin)
            {
                result.Add(currentPositionRow);
                result.Add(currentPositionColumn);
                return result;
            }
            else
                return null;
        }

        public static List<int> checkDiagonalDownUp(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin)
        {
            List<int> result = new List<int>();
            int rightUp = 0, leftDown = 0;
            int positionRow = currentPositionRow, positionColumn = currentPositionColumn;
            while (positionRow - 1 >= 0 && positionColumn + 1 < chessSize && board2D[positionRow, positionColumn] == board2D[positionRow - 1, positionColumn + 1])
            {
                rightUp++;
                positionRow--;
                positionColumn++;
                result.Add(positionRow);
                result.Add(positionColumn);
            }
            positionRow = currentPositionRow;
            positionColumn = currentPositionColumn;
            while (positionRow + 1 < chessSize && positionColumn - 1 >= 0 && board2D[positionRow, positionColumn] == board2D[positionRow + 1, positionColumn - 1])
            {
                leftDown++;
                positionRow++;
                positionColumn--;
                result.Add(positionRow);
                result.Add(positionColumn);
            }
            if (rightUp + leftDown + 1 >= howMuchToWin)
            {
                result.Add(currentPositionRow);
                result.Add(currentPositionColumn);
                return result;
            }
            else
                return null;
        }

        public static int checkWin(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin, ref List<int> listWinnerPositions)
        {
            if (checkHorizontal(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin) != null)
            {
                listWinnerPositions = checkHorizontal(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin);
                return 1; //zwycieztwo poziome
            }
            else if (checkVertical(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin) != null)
            {
                listWinnerPositions = checkVertical(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin);
                return 2; //zwycieztwo pionowe
            }
            else if (checkDiagonalUpDown(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin) != null)
            {
                listWinnerPositions = checkDiagonalUpDown(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin);
                return 3; //zwycieztwo \
            }
            else if (checkDiagonalDownUp(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin) != null)
            {
                listWinnerPositions = checkDiagonalDownUp(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin);
                return 4; //zwycieztwo /
            }
            return 0; //nie bylo wygranej
        }

        public static int checkIfEndGame(int[,] board2D, int moveCount, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin, ref List<int> listWinnerPositions)
        {
            int indexBoard = (currentPositionRow - 1) * chessSize + currentPositionColumn - 1;
            int winner = checkWin(board2D, chessSize, currentPositionColumn - 1, currentPositionRow - 1, howMuchToWin, ref listWinnerPositions);
            if (moveCount == board2D.Length && winner == 0)
                return -1; //remis
            return winner;
        }

        public static bool availableDrawSymbol(int[,] board2D, int currentPositionColumn, int currentPositionRow, int chessSize, int symbolValue)
        {
            if (board2D[currentPositionRow - 1, currentPositionColumn - 1] == -1)
            {
                board2D[currentPositionRow - 1, currentPositionColumn - 1] = symbolValue;
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

    static class FileWithData
    {
        public static void Save<T>(string path, T objectToSave) //Binarna serializacja obiektu
        {
            FileStream stream = null;
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                stream = File.Create(path);
                formatter.Serialize(stream, objectToSave);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }
        public static T Load<T>(string path) //Binarna deserializacja obiektu
        {
            FileStream stream = null;
            BinaryFormatter formatter = new BinaryFormatter();
            T obj;
            try
            {
                stream = new FileStream(path, FileMode.Open);
                obj = (T)formatter.Deserialize(stream);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return obj;
        }
    }

    [Serializable]
    public class NecessaryData
    {
        public int[,] board { get; set; }
        public int poption { get; set; }
        public int pstartArenaColumn { get; set; }
        public int pstartArenaRow { get; set; }
        public int psymbolValue { get; set; }
        public int pcolorValue { get; set; }
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
        private int howMuchToWin;
        private int startArenaColumn;
        private int startArenaRow;
        private List<int> listWinnerPositions;

        private void saveGame()
        {
            Console.Clear();



            string workingDirectory = Environment.CurrentDirectory;
            Console.WriteLine(workingDirectory);

            string path = "D:\\Zapisy_programow_C#\\ConsoleInterface\\zapis3";
            NecessaryData save = new NecessaryData
            {
                board = board2D,
                poption = option,
                pstartArenaColumn = startArenaColumn,
                pstartArenaRow = startArenaRow,
                psymbolValue = symbolValue,
                pcolorValue = colorValue,
            };

            FileWithData.Save(path, save);


            Console.ReadKey();
        }

        private void initializeParameters(int option, int startArenaRow, int startArenaColumn)
        {
            this.option = option;
            symbolValue = 1; //0-kolko 1-krzyz
            colorValue = 4; //1-niebieski 4-czerwony
            this.startArenaColumn = startArenaColumn;
            this.startArenaRow = startArenaRow;
            switch (option)
            {
                case 0:
                    howMuchToWin = 5;
                    startColumn = startArenaColumn + 18;//68;
                    startRow = startArenaRow + 18;//23;
                    squareSize = 3;
                    chessSize = 13;
                    currentPositionRow = 7;
                    currentPositionColumn = 7;
                    break;
                case 1:
                    howMuchToWin = 4;
                    startColumn = startArenaColumn + 14;//64;
                    startRow = startArenaRow + 14;//19;
                    squareSize = 7;
                    chessSize = 5;
                    currentPositionRow = 3;
                    currentPositionColumn = 3;
                    break;
                case 2:
                    howMuchToWin = 3;
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
            listWinnerPositions = new List<int>();
        }

        public CircleAndCross(int option, int startArenaRow = 10, int startArenaColumn = 56)
        {
            initializeParameters(option, startArenaRow, startArenaColumn);
        }

        public CircleAndCross(int[,] board, int poption, int pstartArenaColumn, int pstartArenaRow, int psymbolValue, int pcolorValue)
        {
            initializeParameters(poption, pstartArenaRow, pstartArenaColumn);
            board2D = board;
            symbolValue = psymbolValue;
            colorValue = pcolorValue;
        }

        private int endOfGame(int winner, int color=15)
        {
            Draw.drawSubtitle("czysc", 0, 0);
            //Console.Clear();
            if (winner == 0)
            {
                Draw.drawSubtitle("Wygrały",40,3, color);
                Draw.drawSubtitle("0", 100, 3, color);
            }
            else if(winner == 1)
            {
                Draw.drawSubtitle("Wygrały", 40, 3, color);
                Draw.drawSubtitle("1", 100, 3, color);
            }
            else
            {
                Draw.drawSubtitle("Remis", 50, 3);
            }
            System.Threading.Thread.Sleep(1500);
            Draw.drawSubtitle("czysc", 25, 53);
            int changeColor = 0;
            ConsoleKey key;
            do
            {
                while (!Console.KeyAvailable)
                {
                    Draw.drawSubtitle("nowa gra - wcisnij Enter", Draw.adjustToCenterText(0, 150, 131), 50, 5 + changeColor);
                    Draw.drawSubtitle("menu - wcisnij Escape", Draw.adjustToCenterText(0, 150, 116), 58, 7 + changeColor);
                    Console.SetCursorPosition(0, 0);
                    changeColor = (changeColor + 1) % 2;
                    System.Threading.Thread.Sleep(250);
                }
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Draw.drawSubtitle("trzy", Draw.adjustToCenterText(0, 150, 20), Draw.adjustToCenterText(0, 65, 16), 5);
                    System.Threading.Thread.Sleep(300);
                    Console.Clear();
                    Draw.drawSubtitle("dwa", Draw.adjustToCenterText(0, 150, 20), Draw.adjustToCenterText(0, 65, 16), 6);
                    System.Threading.Thread.Sleep(300);
                    Console.Clear();
                    Draw.drawSubtitle("jeden", Draw.adjustToCenterText(0, 150, 13), Draw.adjustToCenterText(0, 65, 16), 2);
                    System.Threading.Thread.Sleep(300);
                    Console.Clear();
                    Draw.drawSubtitle("start", Draw.adjustToCenterText(0, 150, 119), Draw.adjustToCenterText(0, 65, 16), 1);
                    System.Threading.Thread.Sleep(300);
                    Console.Clear();
                    return 100+option;
                }
            } while (key != ConsoleKey.Escape);
            Console.Clear();
            return 3;
        }

        public int gameplay()
        {
            Draw.redrawBoardWithSymbols(board2D, option, chessSize, squareSize, startArenaColumn, startArenaRow, startArenaColumn + 1, startArenaRow + 1);
            Draw.drawSubtitle("Ruch", 40, 3, 6);
            Draw.drawSubtitle(symbolValue.ToString(), 77, 3, colorValue);
            Draw.printInstructionInGame(howMuchToWin, 25, 53);
            int gameplayResult = 0;
            ConsoleKey key;
            do
            {
                while (!Console.KeyAvailable)
                {
                    Draw.drawSquare(startColumn, startRow, squareSize, colorValue); //4 = red
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
                        wayToWin = Check.checkIfEndGame(board2D, moveCount, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin, ref listWinnerPositions);
                        if (wayToWin != 0)
                        {
                            if (wayToWin > 0)
                            {
                                winner = board2D[currentPositionRow - 1, currentPositionColumn - 1];
                                Draw.drawWinningSquares(listWinnerPositions, startArenaColumn, startArenaRow, squareSize, option, winner);
                                gameplayResult = endOfGame(winner, colorValue);
                            }
                            else
                                gameplayResult = endOfGame(-1, 15);
                            return gameplayResult;
                        }
                        symbolValue = (symbolValue + 1) % 2; //zmiana symbolu
                        if (symbolValue == 0)
                            colorValue = 1; //zmiana koloru na niebieski
                        else
                            colorValue = 4; //zmiana koloru na czerwony
                        Draw.drawSubtitle(symbolValue.ToString(), 77, 3, colorValue);
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
            } while (key != ConsoleKey.Escape); //escpae klikniety w trakcie gry
            do
            {
                Draw.drawContinuedMenu();
                gameplayResult = Draw.chooseOptionContinuedMenu();
                if(gameplayResult == 2)
                {
                    saveGame();
                }
            } while (gameplayResult == 2); //zapisz gre
            return gameplayResult;
        }
    }

    class Program
    {
        static void setResolution()
        {
            try
            {
                Console.WindowHeight = 65; //65
                Console.WindowWidth = 160;//150; //150
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 7, Console.LargestWindowHeight / 2 - 2);
                Console.WriteLine("-- Warning --");
                Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 40, Console.LargestWindowHeight / 2 - 1);
                Console.WriteLine("Your screen isn't big enough to match the game's desired width and hight.");
                Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 45, Console.LargestWindowHeight / 2);
                Console.WriteLine("Things may not look quite right, unless you adjust the text size in your console window.");
                Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 33, Console.LargestWindowHeight / 2 + 1);
                Console.WriteLine("Required min. resolution 150x65, your actual resolution is "+Console.LargestWindowWidth+"x"+Console.LargestWindowHeight);
                Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 10, Console.LargestWindowHeight / 2 + 2);
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
        static int chooseOptionFirstMenu(int startColumn = 25, int option = 0)
        {
            int startRow = 0, startColumnSubtitle = 0, startRowSubtitle = 0;
            string text = "";
            ConsoleKey key;
            do
            {
                while (!Console.KeyAvailable)
                {
                    switch (option)
                    {
                        case 0:
                            startColumnSubtitle = Draw.adjustToCenterText(25, 125, 74);//38;
                            startRowSubtitle = 12;
                            startRow = startRowSubtitle - 2;
                            text = "Nowa gra 3x3";
                            break;
                        case 1:
                            startColumnSubtitle = Draw.adjustToCenterText(25, 125, 74);
                            startRowSubtitle = 22;
                            startRow = startRowSubtitle - 2;
                            text = "Nowa gra 5x5";
                            break;
                        case 2:
                            startColumnSubtitle = Draw.adjustToCenterText(25, 125, 84);
                            startRowSubtitle = 32;
                            startRow = startRowSubtitle - 2;
                            text = "Nowa gra 13x13";
                            break;
                        case 3:
                            startColumnSubtitle = Draw.adjustToCenterText(25, 125, 60);
                            startRowSubtitle = 41;
                            startRow = startRowSubtitle - 1;
                            text = "Wczytaj gre";
                            break;
                        case 4:
                            startColumnSubtitle = Draw.adjustToCenterText(25, 125, 63);
                            startRowSubtitle = 51;
                            startRow = startRowSubtitle - 1;
                            text = "Wyjdz z gry";
                            break;
                    }
                    Draw.drawRectangle(startColumn, startRow, 10, 100, 4); //4 = red
                    Draw.drawSubtitle(text, startColumnSubtitle, startRowSubtitle, 4);
                    System.Threading.Thread.Sleep(500);
                    Draw.drawRectangle(startColumn, startRow, 10, 100, 15); //15 = white
                    Draw.drawSubtitle(text, startColumnSubtitle, startRowSubtitle, 15);
                    System.Threading.Thread.Sleep(500);
                }
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    return option;
                }
                else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
                {
                    if (option > 0)
                        option--;
                    else
                        option = 4;
                }
                else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
                {
                    option = (option+1)%5;
                }
            } while (true);
        }

        private static CircleAndCross loadCircleAndCross()
        {
            Console.Clear();

            string path = "D:\\Zapisy_programow_C#\\ConsoleInterface\\zapis3";
            NecessaryData fileData = FileWithData.Load<NecessaryData>(path);
            CircleAndCross c = new CircleAndCross(fileData.board, fileData.poption, fileData.pstartArenaColumn, fileData.pstartArenaRow, fileData.psymbolValue, fileData.pcolorValue);

            Console.ReadKey();

            return c;
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            setResolution();
            Draw.drawFirstMenu();
            int chosenOption = chooseOptionFirstMenu();
            int optionGame = 1;
            do
            {
                switch (chosenOption)
                {
                    case 0:
                        optionGame = 2;
                        break;
                    case 1:
                        optionGame = 1;
                        break;
                    case 2:
                        optionGame = 0;
                        break;
                    case 3:
                        //Console.WriteLine("Wczytales gre");
                        //return;
                        break;
                    case 4:
                        Console.Clear();
                        Console.SetCursorPosition(Draw.adjustToCenterText(0, 150, 67), Draw.adjustToCenterText(0, 65, 0));
                        Console.WriteLine("Wyszedłeś/aś z gry, ale mam nadzieję, że jeszcze zagrasz kiedyś :D\n\n\n\n\n\n\n\n\n\n");
                        Environment.Exit(0);
                        return;
                }
                CircleAndCross c = (chosenOption != 3)? new CircleAndCross(optionGame) : c = loadCircleAndCross();
                chosenOption = c.gameplay();
                while (chosenOption == 1)
                {
                    chosenOption = c.gameplay();
                }
                if (chosenOption == 3)
                {
                    Draw.drawFirstMenu();
                    chosenOption = chooseOptionFirstMenu();
                }
                if (chosenOption == 100)
                    chosenOption = 2;
                if (chosenOption == 101)
                    chosenOption = 1;
                if (chosenOption == 102)
                    chosenOption = 0;
            } while(true);
        }
    }
}
