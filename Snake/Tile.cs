﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public interface Tile
    {
        int X { get; set; }
        int Y { get; set; }
        //char
        string ToString();
    }
}
