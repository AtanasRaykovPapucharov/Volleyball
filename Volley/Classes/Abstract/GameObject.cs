using System;
using System.Collections.Generic;
using System.Text;

using Volley.Classes.Static;
using Volley.Interfaces;

namespace Volley.Classes.Abstract
{
    public abstract class GameObject
    {
        private int _x;
        private int _y;
        private ConsoleColor _color;

        protected GameObject()
        {
        }

        protected GameObject(int x, int y, ConsoleColor color)
        {
            this._x = x;
            this._y = y;
            this._color = color;
        }

        public int X
        {
            get
            {
                return this._x;
            }

            set
            {
                if (!Validator.IsNotNegative(value))
                {
                    value = 0;
                }

                if (!Validator.IsSmallerThanWidth(value))
                {
                    value = Console.WindowWidth;
                }

                this._x = value;
            }
        }

        public int Y
        {
            get
            {
                return this._y;
            }

            set
            {
                if (!Validator.IsNotNegative(value))
                {
                    value = 0;
                }

                if (!Validator.IsSmallerThanHeight(value))
                {
                    value = Console.WindowHeight;
                }

                this._y = value;
            }
        }
        public ConsoleColor Color
        {
            get { return this._color; }

            set { this._color = value; }
        }
    }
}
