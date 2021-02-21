using System;
using System.Collections.Generic;
using System.Text;

using Volley.Classes.Abstract;
using Volley.Enumerations;
using Volley.Interfaces;

namespace Volley.Classes.Game
{
    public class Ball : Pixel, IMovable
    {
        public Ball() : base()
        {
        }

        public Ball(int x, int y, ConsoleColor color) : base(x, y, color)
        {
        }

        public Ball(int x, int y, ConsoleColor color, char symbol) : base(x, y, color, symbol)
        {
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.LeftUp:
                    this.X--;
                    this.Y--;
                    break;
                case Direction.RightUp:
                    this.X++;
                    this.Y--;
                    break;
                case Direction.LeftDown:
                    this.X--;
                    this.Y++;
                    break;
                case Direction.RightDown:
                    this.X++;
                    this.Y++;
                    break;
                default:
                    break;
            }
        }
    }
}
