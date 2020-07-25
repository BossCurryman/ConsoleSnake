using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class BodyPart : Tile
    {
        public int X { get; set; }
        public int Y { get; set; }

        const string BODY_CHARACTER = "O";

        public BodyPart(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public override string ToString()
        {
            return BODY_CHARACTER;
        }

        void UpdateCoords(int X,int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
