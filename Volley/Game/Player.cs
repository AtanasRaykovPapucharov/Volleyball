using System;
using System.Collections.Generic;
using System.Text;

using Volley.Classes.Abstract;
using Volley.Classes.Static;
using Volley.Enumerations;
using Volley.Interfaces;

namespace Volley.Game
{
    public class Player : GameObject, IMovable, IPrintable
    {
        private const int SIZE = Constants.PLAYER_SIZE;
        private int points = 0;

        public Player() : base()
        {
        }

        public Player(int x, int y, ConsoleColor color) : base(x, y, color)
        {
        }

        public int Size
        {
            get
            {
                return SIZE;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }
        }

        public void GetPoint()
        {
            this.points++;
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left: 
                    this.X -= 2; 
                    break;
                case Direction.Right: 
                    this.X += 2; 
                    break;
                default: 
                    break;
            }
        }

        public void Print()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.ForegroundColor = this.Color;

            for (int i = 0; i < SIZE; i++)
            {
                Console.Write(Constants.PIXEL_BLOCK);
            }
        }
    }
}
