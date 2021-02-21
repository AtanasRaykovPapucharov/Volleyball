using System;
using System.Collections.Generic;
using System.Text;

namespace Volley.Classes.Static
{
    public static class Validator
    {
        public static bool IsNotNegative(int number)
        {
            if(number >= 0)
            {
                return true;
            }

            return false;
        }
        public static bool IsSmallerThanWidth(int number)
        {
            if (number < Console.WindowWidth)
            {
                return true;
            }

            return false;
        }
        public static bool IsSmallerThanHeight(int number)
        {
            if (number < Console.WindowHeight)
            {
                return true;
            }

            return false;
        }

        public static bool IsBiggerThanMiddle(int number)
        {
            if (number > Console.WindowWidth / 2 + 1)
            {
                return true;
            }

            return false;
        }
        public static bool IsSmallerThanMiddle(int number)
        {
            if (number < Console.WindowWidth / 2 - Constants.PLAYER_SIZE)
            {
                return true;
            }

            return false;
        }
        public static bool IsSmallerThanEnd(int number)
        {
            if (number < Console.WindowWidth - Constants.PLAYER_SIZE)
            {
                return true;
            }

            return false;
        }
    }
}
