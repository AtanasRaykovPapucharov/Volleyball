using System;
using System.Collections.Generic;
using System.Text;

using Volley.Classes.Abstract;
using Volley.Classes.Static;
using Volley.Interfaces;

namespace Volley.Game
{
    public class Net : GameObject, IPrintable
    {
        public Net() : base()
        {
        }

        public Net(int x, int y, ConsoleColor color) : base(x, y, color)
        {
            this._x = x;
            this._y = y;
            this._color = color;
        }

        public void Print()
        {
            Pixel pixel = new Pixel(this.X, this.Y, this.Color, Constants.NET_BLOCK);
            pixel.Print();

            for (int i = Console.WindowHeight / 2 - 1; i < Console.WindowHeight - 2; i++)
            {
                pixel.Y++;
                pixel.Print();
            }
        }
    }
}
