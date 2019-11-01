using System;

namespace Text
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the text");
            string text = Console.ReadLine();
            int symbolCount = 0;
            int wordCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    symbolCount++;
                }
                if ((text[i] == ' ' && text[i - 1] != '-') || i == text.Length - 1)
                {
                    wordCount++;
                }
            }
            Console.WriteLine("Words: {0}", wordCount);
            Console.WriteLine("Symbols without spaces: {0}", symbolCount);
            double f = Math.Round(Convert.ToDouble(symbolCount) / Convert.ToDouble(wordCount), 2);
            Console.WriteLine("Ratio: {0}", f);
            
            string separator = " ";
            String[] array = text.Split(separator);
            string word = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != "-")
                {
                    word += array[i][0];
                }
            }
            Console.WriteLine("Word which contains the first letters from each word: {0}", word);
        }
    }
}