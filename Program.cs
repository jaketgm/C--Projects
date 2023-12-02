/******************************************************************************
 * @author Jake Brockbank
 * Dec 2nd, 2023 (Revitalized)
 * This is a simple Tic Tac Toe game.
******************************************************************************/

using System;
using System.Collections.Generic;

namespace TicTacToe 
{
    /******************************************************************************
     * Class: Program: 
     * 
     * - This class is the main class for the Tic Tac Toe game.
     *
     * Input: None.
     *
     * Output: The game.
     *
    ******************************************************************************/
    class Program 
    {
        static int[] board = new int[9];
        static Random rand = new Random();
        static Dictionary<string, int> positionMapping = new Dictionary<string, int> {
            {"top left", 0}, {"top middle", 1}, {"top right", 2},
            {"middle left", 3}, {"center", 4}, {"middle right", 5},
            {"bottom left", 6}, {"bottom middle", 7}, {"bottom right", 8}
        };

        /******************************************************************************
         * Method: Main: 
         * 
         * - This method is the main method for the Tic Tac Toe game.
         *
         * Input: string[] args.
         *
         * Output: The game.
         *
        ******************************************************************************/
        static void Main(string[] args) 
        {
            InitializeBoard();
            PlayGame();
        }

        /******************************************************************************
         * Method: InitializeBoard: 
         * 
         * - This method initializes the board.
         *
         * Input: None.
         *
         * Output: Initialized board.
         *
        ******************************************************************************/
        private static void InitializeBoard() 
        {
            for (int i = 0; i < board.Length; i++) 
            {
                board[i] = 0; // 0 indicates empty spot
            }
        }

        /******************************************************************************
         * Method: PlayGame: 
         * 
         * - Repeatedly alternates between the player's and computer's turns until 
         the game reaches a conclusive state, at which point it announces the outcome.
         *
         * Input: None.
         *
         * Output: Initialized board.
         *
        ******************************************************************************/
        private static void PlayGame() 
        {
            int winner;
            while (!IsGameOver(out winner)) 
            {
                PlayerTurn();
                if (IsGameOver(out winner)) break;
                ComputerTurn();
                PrintBoard();
            }
            Console.WriteLine(winner == 0 ? "It's a draw!" : $"Player {winner} won the game!");
        }

        /******************************************************************************
         * Method: PlayerTurn: 
         * 
         * - Handles the interaction with the human player for making a move and 
         updating the game state accordingly. The IsValidMove method is responsible 
         for ensuring the inputted move is not only in a correct format but also 
         corresponds to an unoccupied spot on the board.
         *
         * Input: None.
         *
         * Output: None.
         *
        ******************************************************************************/
        private static void PlayerTurn() 
        {
            string input;
            do 
            {
                Console.WriteLine("Enter a position (e.g., 'top left', 'center'):");
                input = Console.ReadLine().ToLower();
            } while (!IsValidMove(input));

            board[positionMapping[input]] = 1; // 1 for player
        }

        /******************************************************************************
         * Method: IsValidMove: 
         * 
         * - Responsible for ensuring the inputted move is not only in a correct format 
         * but also corresponds to an unoccupied spot on the board.
         *
         * Input: string input.
         *
         * Output: True or false depending on conditions.
         *
        ******************************************************************************/
        private static bool IsValidMove(string input) 
        {
            if (!positionMapping.ContainsKey(input)) 
            {
                Console.WriteLine("Invalid position. Please try again.");
                return false;
            }
            if (board[positionMapping[input]] != 0) 
            {
                Console.WriteLine("Position already taken. Please try another.");
                return false;
            }
            return true;
        }

        /******************************************************************************
         * Method: ComputerTurn: 
         * 
         * - Determines where the computer will place its mark 
         * ('O' in most cases, represented by the number 2 in the array), ensures 
         * that the position is not already taken, converts that index to a 
         * human-readable format, announces it, and updates the game board.
         *
         * Input: None.
         *
         * Output: None.
         *
        ******************************************************************************/
        private static void ComputerTurn() 
        {
            int computerTurn;
            do 
            {
                computerTurn = rand.Next(0, 9);
            } while (board[computerTurn] != 0);

            string computerPosition = "";
            foreach (var entry in positionMapping) 
            {
                if (entry.Value == computerTurn) 
                {
                    computerPosition = entry.Key;
                    break;
                }
            }
            Console.WriteLine($"Computer chooses {computerPosition}");
            board[computerTurn] = 2; // 2 for computer
        }

        /******************************************************************************
         * Method: IsGameOver: 
         * 
         * - Checks whether a winning condition has been met or the board is full 
         * (a draw) and then returns a boolean value indicating whether the game has 
         * ended. The winner parameter is updated to reflect the outcome of the game 
         * (which player won or if it's a draw).
         *
         * Input: out int winner.
         *
         * Output: True or false depending on conditions.
         *
        ******************************************************************************/
        private static bool IsGameOver(out int winner) 
        {
            winner = CheckForWinner();
            if (winner != 0 || Array.IndexOf(board, 0) == -1) 
            {
                return true; // Winner found or board is full
            }
            return false;
        }

        /******************************************************************************
         * Method: CheckForWinner: 
         * 
         * - Loops through all possible winning line combinations to see if any 
         * player has achieved one of them. If so, it returns the player number that 
         * won; otherwise, it returns 0 to indicate the game continues or is a draw 
         * if the board is full.
         *
         * Input: None.
         *
         * Output: The winner.
         *
        ******************************************************************************/
        private static int CheckForWinner() 
        {
            int[,] winningConditions = {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // Rows
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // Columns
                {0, 4, 8}, {2, 4, 6}             // Diagonals
            };

            for (int i = 0; i < winningConditions.GetLength(0); i++) 
            {
                if (board[winningConditions[i, 0]] != 0 &&
                    board[winningConditions[i, 0]] == board[winningConditions[i, 1]] &&
                    board[winningConditions[i, 1]] == board[winningConditions[i, 2]]) 
                {
                    return board[winningConditions[i, 0]];
                }
            }
            return 0; // No winner
        }

        /******************************************************************************
         * Method: PrintBoard: 
         * 
         * - Prints the current state of the board.
         *
         * Input: None.
         *
         * Output: The printed board.
         *
        ******************************************************************************/
        private static void PrintBoard() 
        {
            Console.WriteLine("Current Board:");
            for (int i = 0; i < board.Length; i++) 
            {
                Console.Write(board[i] == 0 ? ". " : (board[i] == 1 ? "X " : "O "));
                if ((i + 1) % 3 == 0) Console.WriteLine();
            }
        }
    }
}