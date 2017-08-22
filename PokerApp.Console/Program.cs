using PokerApp.Common.Enums;
using PokerApp.Common.Models;
using System;
using static System.Console;

namespace PokerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var rounds = GetIntValueFromUser("How many rounds would you like to play? (2 - 5)", "Invalid input, please try again!", 2, 5);
            WriteLine($"Amount of rounds: {rounds}");
            int players = GetIntValueFromUser("How many players would like to play? (2 - 6)", "Invalid input, please try again!", 2, 6);
            WriteLine($"Amount of rounds: {rounds}");

            WriteLine("Let the game begin!");

            var game = new Game(players, rounds);

            for (int round = 1; round <= rounds; round++)
            {
                Clear();
                Title = $"Poker - Round: {round} of {rounds} == {game.PlayerScores}";

                game.Deck.Shuffle();
                game.NewHand();
                game.DealCards();
                WriteLine(game.PlayerHands);

                WriteLine($"Round {round} over...");
                WriteLine($"Resolving close calls..");
                game.ResolveCloseHands();

                WriteLine($"Awarding points to players..");
                game.AwardingPoints();

                WriteLine($"Round {round} over, scores: {game.PlayerScores}");
                Title = $"Poker - Round: {round} of {rounds} == {game.PlayerScores}";
                WriteLine("Press any key to continue...");
                ReadKey();
            }

            Clear();
            WriteLine("Game over! And the winner is...");
            if(game.WinningPlayers.Length > 1)
            {
                WriteLine("We have a tie!");
                WriteLine($"Players{game.PrintWinningPlayers}");
            }
            else
            {
                WriteLine($"Player number: {game.WinningPlayers[0].Index} with a score of: {game.WinningPlayers[0].Score}!!");
            }
            WriteLine();
            WriteLine("Press any key to quit...");

            ReadKey();
        }
        
        private static int GetIntValueFromUser(string firstMessage, string errorMessage, int min, int max)
        {
            while (true)
            {
                WriteLine(firstMessage);
                var readLine = ReadLine();
                var getRounds = GetIntFromInputWithLimits(readLine, min, max);
                if (getRounds.Item1)
                {
                    return getRounds.Item2;
                }

                WriteLine(errorMessage);
                ReadKey();
                ClearLines(3);
            }
        }
        
        private static Tuple<bool, int> GetIntFromInputWithLimits(string v, int min, int max)
        {
            if (Int32.TryParse(v, out int output))
            {
                if (output >= min && output <= max)
                {
                    return new Tuple<bool, int>(true, output);
                }
            }

            return new Tuple<bool, int>(false, 2);
        }

        private static void ClearLines(int numberOfLinesToClear)
        {
            int currentLineCursor = CursorTop;
            SetCursorPosition(0, CursorTop);
            Write(new string(' ', BufferWidth));
            SetCursorPosition(0, currentLineCursor);

            for (int i = 0; i < numberOfLinesToClear; i++)
            {
                SetCursorPosition(0, CursorTop - 1);
                Write(new string(' ', BufferWidth));
                SetCursorPosition(0, CursorTop - 1);
            }
        }
    }
}
