using System;
using System.Collections.Generic;
using System.Text;

using Volley.Classes.Abstract;
using Volley.Interfaces;

namespace Volley.Game
{
    public class Pixel : GameObject, IPrintable
    {
        protected char _symbol;

        public Pixel() : base()
        {
        }

        public Pixel(int x, int y, ConsoleColor color) : base(x, y, color)
        {
        }

        public Pixel(int x, int y, ConsoleColor color, char symbol) : base(x, y, color)
        {
            this._symbol = symbol;
        }

        public char Symbol
        {
            get
            {
                return this._symbol;
            }

            set
            {
                this._symbol = value;
            }
        }

        public void Print()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.ForegroundColor = this.Color;
            Console.Write(this.Symbol);
        }
    }
}
