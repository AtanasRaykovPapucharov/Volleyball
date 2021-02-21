using System;
using System.Threading;

using Volley.Classes.Static;
using Volley.Enumerations;
using Volley.Game;

namespace Volley
{
    class Start
    {
        static void Main()
        {
            Player player1 = new Player(Console.BufferWidth / 8, Console.BufferHeight - 1, ConsoleColor.Red);
            Player player2 = new Player(7 * Console.BufferWidth / 8, Console.BufferHeight - 1, ConsoleColor.Blue);
            Ball ball = new Ball(Console.BufferWidth / 8 + 3, Console.BufferHeight - 2, ConsoleColor.Black, Constants.BALL_BLOCK);
            Net net = new Net(Console.BufferWidth / 2, Console.BufferHeight / 2, ConsoleColor.DarkGray);

            SetConsole();

            PrintAll(player1, player2, ball, net);

            Direction ballDirection = Direction.RightUp;

            while (true)
            {
                Console.Clear();

                switch (ballDirection)
                {
                    case Direction.LeftUp:
                        if (ball.Y == 0 && ball.X > 0)
                        {
                            ballDirection = Direction.LeftDown;
                        }
                        else if (ball.X == 0 && ball.Y > 0)
                        {
                            ballDirection = Direction.RightUp;
                        }
                        else if (ball.X == 0 && ball.Y == 0)
                        {
                            ballDirection = Direction.RightDown;
                        }
                        break;
                    case Direction.RightUp:
                        if (ball.Y == 0 && ball.X < Console.WindowWidth - 1)
                        {
                            ballDirection = Direction.RightDown;
                        } 
                        else if (ball.X == Console.WindowWidth - 1 && ball.Y > 0)
                        {
                            ballDirection = Direction.LeftUp;
                        }
                        else if (ball.Y == 0 && ball.X == Console.WindowWidth - 1)
                        {
                            ballDirection = Direction.LeftDown;
                        }
                        break;

                    case Direction.LeftDown:
                        if (ball.X == 0 && ball.Y < Console.WindowHeight - 1)
                        {
                            ballDirection = Direction.RightDown;
                        }

                        if (ball.Y == Console.WindowHeight - 2)
                        {
                            if (ball.X < Console.WindowWidth / 2)
                            {
                                player1.Move(Direction.Left);

                                if (player1.X <= ball.X && ball.X <= player1.X + Constants.PLAYER_SIZE)
                                {
                                    ballDirection = Direction.LeftUp;
                                }
                                else
                                {
                                    ballDirection = Direction.LeftUp;
                                    player2.GetPoint();
                                }
                            }
                            else if (ball.X > Console.WindowWidth / 2)
                            {
                                if (player2.X <= ball.X && ball.X <= player2.X + Constants.PLAYER_SIZE)
                                {
                                    ballDirection = Direction.LeftUp;
                                }
                                else
                                {
                                    ballDirection = Direction.LeftUp;
                                    player1.GetPoint();
                                }
                            }
                        }

                        break;

                    case Direction.RightDown:
                        if (ball.X == Console.WindowWidth - 1 && ball.Y < Console.WindowHeight - 1)
                        {
                            ballDirection = Direction.LeftDown;
                        }

                        if (ball.Y == Console.WindowHeight - 2)
                        {
                            if (ball.X < Console.WindowWidth / 2)
                            {
                                player1.Move(Direction.Right);

                                if (player1.X <= ball.X && ball.X <= player1.X + Constants.PLAYER_SIZE)
                                {
                                    ballDirection = Direction.RightUp;
                                }
                                else
                                {
                                    ballDirection = Direction.RightUp;
                                    player2.GetPoint();
                                }
                            } else if (ball.X > Console.WindowWidth / 2)
                            {
                                if (player2.X <= ball.X && ball.X <= player2.X + Constants.PLAYER_SIZE)
                                {
                                    ballDirection = Direction.RightUp;
                                } 
                                else
                                {
                                    ballDirection = Direction.RightUp;
                                    player1.GetPoint();
                                }
                            }
                        }

                        break;
                    default:
                        break;
                }

                ball.Move(ballDirection);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (Validator.IsBiggerThanMiddle(player2.X))
                            {
                                player2.Move(Direction.Left);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (Validator.IsSmallerThanEnd(player2.X))
                            {
                                player2.Move(Direction.Right);
                            }
                            break;
                        default:
                            break;
                    }
                }

                PrintAll(player1, player2, ball, net);

                Thread.Sleep(100);
            }
        }

        static void SetConsole()
        {
            Console.Title = Constants.GAME_NAME;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            Console.CursorVisible = false;
        }

        static void PrintAll(Player player1, Player player2, Ball ball, Net net)
        {
            player1.Print();
            player2.Print();
            ball.Print();
            net.Print();
            Score(player1.Points, player2.Points);
        }

        static void Score(int p1, int p2) // points
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 2, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{p1} - {p2}");
        }
    }
}
