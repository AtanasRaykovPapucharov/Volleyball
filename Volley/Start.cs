using System;
using System.Threading;
using System.Text;

using Volley.Classes.Game;
using Volley.Classes.Static;
using Volley.Enumerations;

namespace Volley
{
    class Start
    {
        static bool off = true;

        static Random random = new Random();

        static int firstPlayerX = Console.WindowWidth / 8;
        static int secondPlayerX = 7 * Console.WindowWidth / 8;
        static int playerY = Console.WindowHeight - 1;             // Y coordinate is the same for both players

        static int ballX = Console.WindowWidth / 8 + 3;
        static int ballY = playerY - 1;

        static Direction ballDirection = Direction.RightUp; // enum

        static int netX = Console.WindowWidth / 2;
        static int netY = Console.WindowHeight / 2;

        static int initialMessageX = Console.WindowWidth / 2 - 6;
        static int initialMessageY = Console.WindowHeight / 2 - 6;

        static Player player1 = new Player(firstPlayerX, playerY, ConsoleColor.Red);
        static Player player2 = new Player(secondPlayerX, playerY, ConsoleColor.Blue);

        static Ball ball = new Ball(ballX, ballY, ConsoleColor.Black, Constants.BALL_BLOCK1.ToCharArray()[0]);

        static Net net = new Net(netX, netY, ConsoleColor.DarkGray);

        static void Main()
        {
            Console.WriteLine("Player1 / Enter your name:");

            player1.Name = Console.ReadLine();

            Console.WriteLine("Player2 / Enter your name:");

            player2.Name = Console.ReadLine();

            Console.Clear();

            SetConsole();

            PrintAll(player1, player2, ball, net);

            PrintMessageAt(initialMessageX, initialMessageY, "Press Spacebar ...");

            Console.ReadKey();

            while (true) // game loop
            {
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
                        if ((ball.X == 0 && ball.Y < Console.WindowHeight - 1) ||                                              // reflect from the wall
                            (ball.X == Console.WindowWidth / 2 + 1 && ball.Y >= net.Y && ball.Y < Console.WindowHeight - 2))   // reflect from the net
                        {
                            ballDirection = Direction.RightDown;
                        }

                        // reflect from the player
                        if (ball.Y == Console.WindowHeight - 2)
                        {
                            if (ball.X < Console.WindowWidth / 2 - 1)
                            {
                                if (ball.X >= player1.X - 1 && ball.X <= player1.X + Constants.PLAYER_SIZE)
                                {
                                    if (ball.X < Console.WindowWidth / 4)
                                    {
                                        ball.X += random.Next(0, 5);
                                    }
                                    else
                                    {
                                        ball.X -= random.Next(0, 5);
                                    }

                                    ballDirection = Direction.RightUp;
                                }
                            }
                            else if (ball.X > Console.WindowWidth / 2 + 1)
                            {
                                if (ball.X >= player2.X - 1 && ball.X <= player2.X + Constants.PLAYER_SIZE)
                                {
                                    if (ball.X < 3 * Console.WindowWidth / 4)
                                    {
                                        ball.X += random.Next(0, 5);
                                    }
                                    else
                                    {
                                        ball.X -= random.Next(0, 5);
                                    }

                                    ballDirection = Direction.LeftUp;
                                }
                            }
                        }

                        // point and reflect
                        if (ball.Y == Console.WindowHeight - 1)
                        {
                            if (ball.X < Console.WindowWidth / 2 - 1)
                            {
                                if (ball.X < player1.X - 1 || ball.X > player1.X + Constants.PLAYER_SIZE)
                                {
                                    player2.GetPoint();
                                }

                                ballDirection = Direction.LeftUp;
                            }
                            else if (ball.X > Console.WindowWidth / 2 + 1)
                            {
                                if (ball.X < player2.X - 1 || ball.X > player2.X + Constants.PLAYER_SIZE)
                                {
                                    player1.GetPoint();
                                }

                                ballDirection = Direction.LeftUp;
                            }

                            // in the corners
                            if (ball.X == 0)
                            {
                                ballDirection = Direction.RightUp;
                                player2.GetPoint();
                            }
                            else if (ball.X == Console.WindowWidth / 2 + 1)
                            {
                                ballDirection = Direction.RightUp;
                                player1.GetPoint();
                            }
                        }

                        break;

                    case Direction.RightDown:
                        if ((ball.X == Console.WindowWidth - 1 && ball.Y < Console.WindowHeight - 1) ||                        // reflect from the wall
                            (ball.X == Console.WindowWidth / 2 - 1 && ball.Y >= net.Y && ball.Y < Console.WindowHeight - 2))   // reflect from the net
                        {
                            ballDirection = Direction.LeftDown;
                        }

                        // reflect from the player
                        if (ball.Y == Console.WindowHeight - 2)
                        {
                            if (ball.X < Console.WindowWidth / 2 - 1)
                            {
                                if (ball.X >= player1.X - 1 && ball.X <= player1.X + Constants.PLAYER_SIZE)
                                {
                                    if (ball.X < Console.WindowWidth / 4)
                                    {
                                        ball.X += random.Next(0, 5);
                                    }
                                    else
                                    {
                                        ball.X -= random.Next(0, 5);
                                    }

                                    ballDirection = Direction.RightUp;
                                }
                            }
                            else if (ball.X > Console.WindowWidth / 2 + 1)
                            {
                                if (ball.X >= player2.X - 1 && ball.X <= player2.X + Constants.PLAYER_SIZE)
                                {
                                    if (ball.X < 3 * Console.WindowWidth / 4)
                                    {
                                        ball.X += random.Next(0, 5);
                                    }
                                    else
                                    {
                                        ball.X -= random.Next(0, 5);
                                    }
                                    ballDirection = Direction.LeftUp;
                                }
                            }
                        }

                        // point and reflect
                        if (ball.Y == Console.WindowHeight - 1)
                        {
                            if (ball.X < Console.WindowWidth / 2 - 1)
                            {
                                if (ball.X < player1.X - 1 || ball.X > player1.X + Constants.PLAYER_SIZE + 1)
                                {
                                    player2.GetPoint();
                                }

                                ballDirection = Direction.RightUp;
                            }
                            else if (ball.X > Console.WindowWidth / 2 + 1)
                            {
                                if (ball.X < player2.X - 1 || ball.X > player2.X + Constants.PLAYER_SIZE + 1)
                                {
                                    player1.GetPoint();
                                }

                                ballDirection = Direction.RightUp;
                            }

                            // in the corners
                            if (ball.X == Console.WindowWidth / 2 + 1)
                            {
                                ballDirection = Direction.LeftUp;
                                player2.GetPoint();
                            }
                            else if (ball.X == Console.WindowWidth - 1)
                            {
                                ballDirection = Direction.LeftUp;
                                player1.GetPoint();
                            }
                        }
                        break;
                    default:
                        break;
                }

                // catch user's key pushed
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Spacebar:
                            off = !off;
                            if (off)
                            {
                                PrintAll(player1, player2, ball, net);
                                Console.ReadKey();
                            }
                            break;
                        case ConsoleKey.A:
                            if (Validator.IsNotNegative(player1.X))
                            {
                                player1.Move(Direction.Left);
                            }
                            break;
                        case ConsoleKey.D:
                            if (Validator.IsSmallerThanMiddle(player1.X))
                            {
                                player1.Move(Direction.Right);
                            }
                            break;
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

                // new frame
                Console.Clear();
                ball.Move(ballDirection);
                PrintAll(player1, player2, ball, net);

                Thread.Sleep(Constants.VELOCITY);
            }
        }

        static void SetConsole()
        {
            Console.Title = Constants.GAME_NAME;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
        }

        static void PrintAll(Player player1, Player player2, Ball ball, Net net)
        {
            player1.Print();
            player2.Print();
            ball.Print();
            net.Print();
            PrintNames(player1.Name, player2.Name);
            PrintScore(player1.Points, player2.Points);
        }

        static void PrintScore(int p1, int p2) // points
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 2, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{p1} - {p2}");
        }

        static void PrintMessageAt(int x, int y, string msg)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(msg);
        }

        static void PrintNames(string name1, string name2)
        {
            Console.SetCursorPosition(2, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(name1);
            Console.SetCursorPosition(Console.WindowWidth - name2.Length - 2, 1);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(name2);
        }
    }
}
