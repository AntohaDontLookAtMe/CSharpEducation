using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int currentPlayer = 1;
        static int choice;
        static int gameStatus = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру Крестики-Нолики!");
            Console.WriteLine("Игрок 1: X, Игрок 2: O\n");
            Console.WriteLine("Нажмите Enter, чтобы начать игру...");
            Console.ReadLine();

            do
            {
                Console.Clear();
                Console.WriteLine("Игрок {0}:", (currentPlayer % 2 == 0) ? "2 (O)" : "1 (X)");
                Console.WriteLine("\n");
                ShowBoard();

                bool validInput = false;
                while (!validInput)
                {
                    Console.WriteLine("\nВведите номер клетки (1-9):");
                    string input = Console.ReadLine();
                    validInput = int.TryParse(input, out choice) &&
                                choice >= 1 &&
                                choice <= 9 &&
                                board[choice - 1] != 'X' &&
                                board[choice - 1] != 'O';

                    if (!validInput)
                    {
                        Console.WriteLine("Некорректный ввод, попробуйте еще раз.");
                    }
                }

                char mark = (currentPlayer % 2 == 0) ? 'O' : 'X';
                board[choice - 1] = mark;

                gameStatus = CheckWin();

                if (gameStatus == 1)
                {
                    Console.Clear();
                    ShowBoard();
                    Console.WriteLine("\nИгрок {0} победил!", (currentPlayer % 2 == 0) ? "2 (O)" : "1 (X)");
                    break;
                }
                else if (gameStatus == -1)
                {
                    Console.Clear();
                    ShowBoard();
                    Console.WriteLine("\nНичья!");
                    break;
                }

                currentPlayer++;

            } while (gameStatus == 0);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

private static void ShowBoard()
{
    Console.WriteLine("     |     |     ");
    GetColorToCell(0); Console.Write("|"); GetColorToCell(1); Console.Write("|"); GetColorToCell(2);
    Console.WriteLine("\n_____|_____|_____");
    Console.WriteLine("     |     |     ");
    GetColorToCell(3); Console.Write("|"); GetColorToCell(4); Console.Write("|"); GetColorToCell(5);
    Console.WriteLine("\n_____|_____|_____");
    Console.WriteLine("     |     |     ");
    GetColorToCell(6); Console.Write("|"); GetColorToCell(7); Console.Write("|"); GetColorToCell(8);
    Console.WriteLine("\n     |     |     ");
}

private static void GetColorToCell(int index)
{
    char cell = board[index];
    if (cell == 'X')
    {
        Console.ForegroundColor = ConsoleColor.Blue;
    }
    else if (cell == 'O')
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }
    Console.Write($"  {cell}  ");
    Console.ResetColor();
}

        private static int CheckWin()
        {

            if (board[0] == board[1] && board[1] == board[2])
            {
                return 1;
            }

            else if (board[3] == board[4] && board[4] == board[5])
            {
                return 1;
            }

            else if (board[6] == board[7] && board[7] == board[8])
            {
                return 1;
            }

            else if (board[0] == board[3] && board[3] == board[6])
            {
                return 1;
            }

            else if (board[1] == board[4] && board[4] == board[7])
            {
                return 1;
            }

            else if (board[2] == board[5] && board[5] == board[8])
            {
                return 1;
            }

            else if (board[0] == board[4] && board[4] == board[8])
            {
                return 1;
            }

            else if (board[2] == board[4] && board[4] == board[6])
            {
                return 1;
            }

            else if (board[0] != '1' && board[1] != '2' && board[2] != '3' &&
                     board[3] != '4' && board[4] != '5' && board[5] != '6' &&
                     board[6] != '7' && board[7] != '8' && board[8] != '9')
            {
                return -1;
            }

            else
            {
                return 0;
            }
        }
    }
}