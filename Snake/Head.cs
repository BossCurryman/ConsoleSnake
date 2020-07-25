using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Head : BodyPart
    {
        public enum Direction
        {
            up = ConsoleKey.UpArrow,
            down = ConsoleKey.DownArrow,
            left = ConsoleKey.LeftArrow,
            right = ConsoleKey.RightArrow
        }
        static public Direction currentDir;

        public Head(int X, int Y) : base(X,Y)
        {
            currentDir = Direction.up;
        }
    }
}
