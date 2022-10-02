using System.Linq.Expressions;
using System.Text;

namespace Hangman
{
    internal class Program
    {
        private static readonly string[] wordList =
        {
            "ROBOTICS", "APPLEPIE", "EXAMINATION", "CELLULAR", "PROGRAMMING", "SINGULAR", "BREAKFAST"
        };
        private static string TakeRandomWord()
        {
            Random random = new Random();
            int index = random.Next(0, wordList.Length);
            string word = wordList[index];

            return word;
        }
        static void Main(string[] args)
        {
            bool end = false;
            int chances = 10;

            string answer = TakeRandomWord();
            answer = answer.ToUpper();
            char[] charAnswer = answer.ToCharArray();
            StringBuilder answerAsStringBuilder = new StringBuilder(answer);

            char[] hiddenLineArray = answer.ToCharArray();
            StringBuilder hiddenLineAsStringBuilder = new StringBuilder(answer);

            for (int i = 0; i < hiddenLineArray.Length; i++)
            {
                hiddenLineArray[i] = '_';
                hiddenLineAsStringBuilder[i] = '_';
            }
            Console.WriteLine(hiddenLineArray);

            StringBuilder wrong = new StringBuilder();
            StringBuilder correct = new StringBuilder();

            while (end == false)
            {
                try
                {
                    Console.WriteLine("Enter your guess: ");
                    string? input = Console.ReadLine();
                    input = input.ToUpper();
                    char[] charInput = input.ToCharArray();
                    StringBuilder sbInput = new StringBuilder(input);

                    if (chances > 0)
                    {
                        for (int i = 0; i < charInput.Length; i++)
                        {
                            for (int j = 0; j < charAnswer.Length; j++)
                            {
                                if (answer.Contains(charInput[i]))
                                {
                                    if (charInput[i] == charAnswer[j])
                                    {
                                        hiddenLineAsStringBuilder[j] = charInput[i];
                                        correct.Insert(correct.Length, charInput[i]);
                                        if (hiddenLineAsStringBuilder.ToString() == answer)
                                        {
                                            Console.WriteLine("Winner!");
                                            end = true;
                                        }
                                    }
                                }
                                else if (!answer.Contains(charInput[i]))
                                {
                                    wrong.Insert(wrong.Length, charInput[i]);
                                    chances--;
                                    break;
                                }
                            }
                        }
                        Console.WriteLine("Correct : " + "[" + correct + "]");
                        Console.WriteLine("Wrong : " + "[" + wrong + "]");
                        Console.WriteLine("Guesses: " + chances);
                        Console.WriteLine("The word: " + hiddenLineAsStringBuilder);
                    }
                    else if (chances == 0)
                    {
                        Console.WriteLine("Game over.");
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
