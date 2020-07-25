using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class GameBoard
    {
        Tile[][] gameBoard { get; set; }
        int lastX;
        int lastY;
        Random r;
        Food currentFood;
        List<BodyPart> Snake;

        public GameBoard()
        {
            r = new Random();
            gameBoard = new Tile[15][];
            for(int i = 0; i < gameBoard.Length; ++i)
            {
                gameBoard[i] = new Tile[30];
            }
            Snake = new List<BodyPart>() { new Head(15, 6), new BodyPart(15, 7), new BodyPart(15, 8), new BodyPart(15,9) };

            currentFood = new Food(r.Next(0, 30), r.Next(0, 15));
        }

        public int GetScore()
        {
            return Snake.Count - 4;
        }

        void MakeLists()
        {

            foreach(BodyPart snakeBit in Snake)
            {
                gameBoard[snakeBit.Y][snakeBit.X] = snakeBit;
                lastX = snakeBit.X;
                lastY = snakeBit.Y;
            }
            gameBoard[currentFood.Y][currentFood.X] = currentFood;

            gameBoard[lastY][lastX] = null;
        }

        void GenerateFood()
        {
            currentFood.X = r.Next(0, 30);
            currentFood.Y = r.Next(0, 15);
            
        }


        void UpdateGameState()
        {
            int xTemp = 0;
            int yTemp = 0;
            foreach(BodyPart part in Snake)
            {

                if (part.GetType() == typeof(Head))
                {
                    xTemp = part.X;
                    yTemp = part.Y;
                    switch (Head.currentDir)
                    {
                        case Head.Direction.down:
                            part.Y += 1;
                            break;
                        case Head.Direction.left:
                            part.X -= 1;
                            break;
                        case Head.Direction.right:
                            part.X += 1;
                            break;
                        case Head.Direction.up:
                            part.Y -= 1;
                            break;
                    }
                    
                    if(gameBoard[part.Y][part.X] != null)
                    {
                        if(gameBoard[part.Y][part.X].GetType() == typeof(BodyPart))
                        {
                            throw new Exception("Game Over");
                        }
                        
                    }
                    
                }
                else
                {
                    int xTemp2 = xTemp;
                    int yTemp2 = yTemp;
                    xTemp = part.X;
                    yTemp = part.Y;
                    part.X = xTemp2;
                    part.Y = yTemp2;

                }
            }
            lastX = xTemp;
            lastY = yTemp;
            if(Snake[0].X == currentFood.X && Snake[0].Y == currentFood.Y)
            {
                Snake.Add(new BodyPart(xTemp, yTemp));
                GenerateFood();
            }
        }

        public void PrintBoard()
        {
            Console.Clear();
            UpdateGameState();
            MakeLists();
            Console.WriteLine(new string('-', 30));
            foreach (Tile[] row in gameBoard)
            {
                Console.Write("|");
                foreach(Tile tile in row)
                {
                    if (tile == null)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(tile.ToString());
                    }
                }
                Console.Write("|");
                Console.Write("\n");
            }
            Console.WriteLine(new string('-', 30));
            Thread.Sleep(200);
        }
    }
}
