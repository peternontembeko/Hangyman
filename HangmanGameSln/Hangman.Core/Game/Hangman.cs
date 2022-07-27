using System;
using System.Collections.Generic;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        int select;
        List<string> words;
        string currentWord;
        string _displayGuess;

        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
            words = new List<string> { "play", "swim", "people", "run", "relax", "donkey", "cat", "thanks", "talk", "Beaty", "sun", "planet", "river", "spoon", "Dog", "whale", "cloud", "cheese", "Apple", "Banana" };
            Random random = new Random();
            int range = words.Count;
            select = random.Next(0, range);
            currentWord = words[select].ToLower();
        }

        public void PlayHangman()
        {
            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Your current guess: ");


            for (int i = 0; i < currentWord.Length; i++)
            {
                _displayGuess += "*";
            }

            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(0, 14);
            Console.WriteLine(_displayGuess);
        }

        public void Run()
        {
            int wrong = 0;
            _renderer.Render(5, 5, 6);// lives on maximum

            PlayHangman();
            // setted guess word
            char nextGuess;


            while (wrong < 6)
            {
                char[] displayToPlayer = _displayGuess.ToCharArray();
                Console.SetCursorPosition(0, 16);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("What is your next guess: ");

                Console.SetCursorPosition(25, 16);
                nextGuess = char.Parse(Console.ReadLine());

                for (int i = 0; i < currentWord.Length; i++)
                {
                    if (nextGuess == currentWord[i])
                    {
                        displayToPlayer[i] = nextGuess;
                    }
                }

                _displayGuess = new string(displayToPlayer);
                Console.SetCursorPosition(0, 14);
                Console.WriteLine(_displayGuess);
                if (!currentWord.Contains(nextGuess))
                {
                    //lives decreasing man get hanged slow


                    wrong++;
                    if (wrong == 1)
                        _renderer.Render(5, 5, 5);
                    if (wrong == 2)
                        _renderer.Render(5, 5, 4);
                    if (wrong == 3)
                        _renderer.Render(5, 5, 3);
                    if (wrong == 4)
                        _renderer.Render(5, 5, 2);
                    if (wrong == 5)
                        _renderer.Render(5, 5, 1);
                    if (wrong == 5)
                        _renderer.Render(5, 5, 0);
                    if (wrong == 6)// if lives ends
                    {
                        Console.SetCursorPosition(0, 16);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Game over!.....  Word is {currentWord} )                                                                 ");
                        break;
                    }
                }
                //if word guessed correctly
                if (_displayGuess == currentWord)
                {
                    Console.SetCursorPosition(0, 16);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Congradulations you got correct word:  {currentWord})                                                    ");
                    break;
                }
            }
        }

    }
}