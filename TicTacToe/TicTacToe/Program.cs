using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int currentPlayer = 1;
        static int choice;
        static GameStatus gameStatus = GameStatus.InProgress;
        const char firstPlayerSymbol = 'X';
        const char secondPlayerSymbol = 'O';

        enum GameStatus
        {
            InProgress,
            PlayerWins,
            Draw    
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру Крестики-Нолики!");
            Console.WriteLine($"Игрок 1: {firstPlayerSymbol}, Игрок 2: {secondPlayerSymbol}\n");
            Console.WriteLine("Нажмите Enter, чтобы начать игру...");
            Console.ReadLine();

            do
            {
                Console.Clear();
                Console.WriteLine("Игрок {0}:", (currentPlayer % 2 == 0) ? $"2 ({secondPlayerSymbol})" : $"1 ({firstPlayerSymbol})");
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
                                board[choice - 1] != firstPlayerSymbol &&
                                board[choice - 1] != secondPlayerSymbol;

                    if (!validInput)
                    {
                        Console.WriteLine("Некорректный ввод, попробуйте еще раз.");
                    }
                }

                char mark = (currentPlayer % 2 == 0) ? secondPlayerSymbol : firstPlayerSymbol;
                board[choice - 1] = mark;

                gameStatus = CheckWin();

                if (gameStatus == GameStatus.PlayerWins)
                {
                    Console.Clear();
                    ShowBoard();
                    Console.WriteLine("\nИгрок {0} победил!", (currentPlayer % 2 == 0) ? $"2 ({secondPlayerSymbol})" : $"1 ({firstPlayerSymbol})");
                    break;
                }
                else if (gameStatus == GameStatus.Draw)
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
    if (cell == firstPlayerSymbol)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
    }
    else if (cell == secondPlayerSymbol)
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }
    Console.Write($"  {cell}  ");
    Console.ResetColor();
}

        private static GameStatus CheckWin()
        {

            if (board[0] == board[1] && board[1] == board[2])
            {
                return GameStatus.PlayerWins;
            }

            else if (board[3] == board[4] && board[4] == board[5])
            {
                return GameStatus.PlayerWins;
            }

            else if (board[6] == board[7] && board[7] == board[8])
            {
                return GameStatus.PlayerWins;
            }

            else if (board[0] == board[3] && board[3] == board[6])
            {
                return GameStatus.PlayerWins;
            }

            else if (board[1] == board[4] && board[4] == board[7])
            {
                return GameStatus.PlayerWins;
            }

            else if (board[2] == board[5] && board[5] == board[8])
            {
                return GameStatus.PlayerWins;
            }

            else if (board[0] == board[4] && board[4] == board[8])
            {
                return GameStatus.PlayerWins;
            }

            else if (board[2] == board[4] && board[4] == board[6])
            {
                return GameStatus.PlayerWins;
            }

            else if (board[0] != '1' && board[1] != '2' && board[2] != '3' &&
                     board[3] != '4' && board[4] != '5' && board[5] != '6' &&
                     board[6] != '7' && board[7] != '8' && board[8] != '9')
            {
                return GameStatus.Draw;
            }

            else
            {
                return GameStatus.InProgress;
            }
        }
    }
}