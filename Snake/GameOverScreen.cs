using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class GameOverScreen
    {
        int score;

        public GameOverScreen(GameBoard g)
        {
            score = g.GetScore();
        }

        public void PrintGameOver()
        {
            string filler = new string(' ', 28);
            Console.WriteLine(new string('-', 30));
            for(int i = 0; i < 15; ++i)
            {
                switch (i)
                {
                    case 6:
                        Console.WriteLine("|         Game Over          |");
                        break;
                    case 7:
                        Console.WriteLine($"|    Score: {score}" + new string(' ', 30 - 13 - score.ToString().Length) + "|");
                        break;

                    default:
                        Console.WriteLine("|" + filler + "|");
                        break;

                }
                
            }
            Console.WriteLine(new string('-', 30));
        }
    }
}
