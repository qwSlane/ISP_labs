using System;


namespace MineSwapper
{
    class Mainclass
    {
        public const int SIZE = 11;
        public const int FIELD = 9;

        static int [,] Board = new int[11,11];
        static int[,] UsedBoard = new int[11, 11];
        static int Flags = 10;
        static int OpenCells = 0;
        static int GameScore = 0;


        static int[] row = new int[] {-1, -1, -1, 0, 1, 1, 1, 0};
        static int[] col = new int[] { -1, 0,  1, 1, 1, 0, -1, -1 };

        static int PointX = 1;
        static int PointY = 1;

        static bool GameOver = true;

        static void FoolField() 
        {
            Random Rand = new Random();
            int Mines = 0;

              for (int i = 0; i < SIZE; i++)  //border
              {
                Board[0, i] = -1;
                Board[i, 0] = -1;
                Board[10, i] = -1;
                Board[i, 10] = -1;
              }

                while (Mines < 10)     //mines generating
                {
                    int x = Rand.Next(1, 10);
                    int y = Rand.Next(1, 10);

                        if (Board[x, y] != 9 && Board[x, y] != -1) 
                        {
                          Board[x, y] = 9;
                                     for (int i = 0; i < 8; i++)    //mine counter around the point
                                     {
                                          if (Board[x + row[i], y + col[i]] != -1 && Board[x + row[i], y + col[i]] != 9)
                                          {
                                            Board[x + row[i], y + col[i]]++;
                                          }
                                     }
                          Mines++;
                        }
                }              
        }
    

        static void PrintField() //digit field
        {
            for (int i = 1; i < SIZE-1; i++) 
            {
                Console.Write("  ");
                for (int j = 1; j < SIZE-1; j++)
                {
                    Console.Write(Board[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }


        static void PlayingField() 
        {
            Console.Clear();
            for (int i = 0; i < SIZE; i++)
            {
                Console.Write("  ");

                for (int j = 0; j < SIZE; j++)
                {
                    if (i == PointY && j == PointX) //point painter
                    { Console.Write("*" + " "); }


                    else
                    {
                        if (UsedBoard[i, j] == 2)  //flag
                        { Console.Write("¶" + " "); }

                        else
                        {

                            if (UsedBoard[i, j] == 1)   //digit
                            { Console.Write($"{Board[i, j]}" + " "); }

                            else
                            {

                                if (i == 0 || i == 10 || j == 0 || j == 10) //border painter
                                {
                                    Console.Write("##");
                                }

                                else Console.Write("■" + " ");
                            }
                        }
                    }
                    
                }
                Console.WriteLine("");
               
                
            }
            Minesweeper();
            Console.WriteLine($"Flags={ Flags}");
            Console.WriteLine($"Open cells={ OpenCells}");
        }


       static void SwiftOpen()  //opening multiple cells
        {

            if (Board[PointY, PointX] == 0)
            {

                for (int k = 0; k < 8; k++)
                {     
                    if ( Board[PointY + row[k], PointX + col[k]] == 0)
                    {
                            if (UsedBoard[PointY + row[k], PointX + col[k]] == 0)
                            {
                                OpenCells++; 
                              
                            }    
                        UsedBoard[PointY + row[k], PointX + col[k]]=1;
                        PlayingField();
                    }
                }
                          
            }

            
       }




        static void Pointer() 
        {
            var input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.RightArrow : //movement
                    
                    if (PointX == 9) 
                    {
                        PointX =1;
                        PlayingField();

                    }
                        else
                        {
                            PointX++;  
                            PlayingField();
                        }
                        break;

                case ConsoleKey.LeftArrow:

                    if (PointX == 1)
                    {
                        PointX = 9;
                        PlayingField();
                    }
                    else
                    {
                        PointX--;
                        PlayingField();
                    }
                    break;

                case ConsoleKey.UpArrow:

                    if (PointY == 1)
                    {
                        PointY = 9;
                        PlayingField();
                    }
                    else
                    {
                        PointY--;
                        PlayingField();
                    }
                    break;

                case ConsoleKey.DownArrow:

                    if (PointY == 9)
                    {
                        PointY = 1;
                        PlayingField();
                    }
                    else
                    {
                        PointY++;
                        PlayingField();
                    }
                    break;

                case ConsoleKey.Enter: //open cell
                    if (Board[PointY, PointX] != 9 || UsedBoard[PointY, PointX] == 2)
                    {
                        if (UsedBoard[PointY, PointX] == 2)
                        { UsedBoard[PointY, PointX] = 0; }
                            else 
                            {
                            if (UsedBoard[PointY, PointX] == 0) { OpenCells++; }
                                UsedBoard[PointY, PointX] = 1;
                                
                                PlayingField();
                                SwiftOpen();
                            }
                    }
                    else { GameOver = false; }

                    break;

                case ConsoleKey.F: //flag
                    if (Flags > 0)
                    {
                        UsedBoard[PointY, PointX] = 2;
                        Flags--;
                    }
                    break;

            }
        
        
        }

        static void FuncScore()  
        {
            for (int i = 1; i < SIZE - 1;i++)
            {
                for (int j = 1; j < SIZE - 1; j++)
                {
                    if (UsedBoard[i, j] == 2 && Board[i, j] == 9)
                    { GameScore += 10; }
                }
            }


        }

        static void Minesweeper() //logo
        {
            Console.WriteLine("        _                                                   ");
            Console.WriteLine("  /\\/\\ (_)_ __   ___  _____      _____  ___ _ __   ___ _ __ ");
            Console.WriteLine(" /    \\| | '_ \\ / _ \\/ __\\ \\ /\\ / / _ \\/ _ \\ '_ \\ / _ \\ '__|");
            Console.WriteLine("/ /\\/\\ \\ | | | |  __/\\__ \\  V  V /  __/  __/ |_) |  __/ |   ");
            Console.WriteLine("\\/    \\/_|_| |_|\\___||___/ \\_/\\_/ \\___|\\___| .__/ \\___|_|   ");
            Console.WriteLine("                                           |_|              ");
            Console.WriteLine("");
           
        }


        static void Main()
        {  
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            FoolField();
            PlayingField();
            

            while (GameOver)
            {     
                Pointer();
                //PrintField();
                if (OpenCells == 71) 
                { 
                    GameOver = false;
                    FuncScore();
                    Console.WriteLine("Congratulations!");
                    Console.WriteLine($"Score={ GameScore}");
                }

            }
            Console.WriteLine("GameOver");
            
        }
    }
}
