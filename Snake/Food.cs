using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food : Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        const string FOOD_CHARACTER = "X";

        public override string ToString()
        {
            return FOOD_CHARACTER;
        }

        public Food(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        ~Food()
        {

        }
    }
}
