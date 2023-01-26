using System;

namespace NumberGuesser
{
    internal class Program
    {

        static bool DidPlayerWin(int play1, int play2)
        {
            if ((play1 == 1 && play2 == 3) || (play1 == 2 && play2 == 1) || (play1 == 3 && play2 == 2))
                return true;
            else
                return false;
        }

        static string GuessToRPS(int guess)
        {
            switch (guess)
            {
                case 1:
                    return "Rock";
                case 2:
                    return "Paper";
                case 3:
                    return "Scissor";
            }
            return null;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("lets play rock-paper-scissors!");

            Random rnd = new Random();

            Console.WriteLine("Enter \"1\" for rock, \"2\" for paper, and \"3\" for scissors!");
            Console.WriteLine("Enter \"0\" to quit");
            int playScore = 0;
            int computerScore = 0;

            while(true)
            {
                Console.WriteLine("Player: {0} Computer: {1}", playScore, computerScore);
                int guess = int.Parse(Console.ReadLine());
                int computerGuess = rnd.Next(1, 3);

                if (guess == 0)
                {
                    break;
                }
                if(guess > 3 || guess < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Please Enter \"1\" for Rock, \"2\" for Paper, and \"3\" for Scissors!");
                    Console.WriteLine("or Enter \"0\" to quit");
                    Console.ResetColor();
                } else
                {
                    if (guess != computerGuess)
                    {
                        if (DidPlayerWin(guess, computerGuess))
                        {
                            Console.WriteLine("Player Won!");
                            Console.WriteLine("Player chose {0}, Computer chose {1}", GuessToRPS(guess), GuessToRPS(computerGuess));
                            playScore++;
                        }
                        if (!DidPlayerWin(guess, computerGuess))
                        {
                            Console.WriteLine("Computer Won!");
                            Console.WriteLine("Player chose {0}, Computer chose {1}", GuessToRPS(guess), GuessToRPS(computerGuess));
                            computerScore++;
                        }
                    }
                    else if (guess == computerGuess)
                    {
                        Console.WriteLine("tie");
                        continue;
                    }

                }
            }
            if (playScore == computerScore) Console.WriteLine("It was a tie!");
            else
            {
                string winner = playScore > computerScore ? "Player" : "Computer";
                Console.WriteLine("Game ended, {0} won!", winner);
            }
        }
    }
}
