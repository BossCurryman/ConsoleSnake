using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static bool gameRunning = true;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Thread thread1 = new Thread(new ThreadStart(Main2));
            GameBoard g = new GameBoard();
            thread1.Start();
            while (gameRunning)
            {
                try
                {
                    g.PrintBoard();
                }
                catch (Exception)
                {
                    gameRunning = false;
                }
            }
            GameOverScreen gameOverScreen = new GameOverScreen(g);
            gameOverScreen.PrintGameOver();
        }

        static void Main2()
        {
            while (gameRunning)
            {
                Head.currentDir = (Head.Direction)Enum.ToObject(typeof(Head.Direction), Console.ReadKey().Key);
            }
        }
    }
}
