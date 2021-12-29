using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Task1361
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = String.Concat(Directory.GetCurrentDirectory(), @"\Text1.txt");
            string text = File.ReadAllText(path);
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            var timer = new Stopwatch();
            timer.Start();

            long n = 500, sum = 0;
            for (int i = 0; i < n; i++)
            {
                timer.Restart();

                var list = new List<string>();
                foreach (var word in words)
                {
                    list.Add(word);
                }

                timer.Stop();
                sum += timer.ElapsedMilliseconds;
            }
            var average = sum / n;
            Console.WriteLine($"Результат работы List: {average} мс");

            sum = 0;
            for (int i = 0; i < n; i++)
            {
                timer.Restart();

                var linkedList = new LinkedList<string>(words);
                foreach (var word in words)
                {
                    linkedList.AddLast(word);
                }

                timer.Stop();
                sum += timer.ElapsedMilliseconds;
            }
            average = sum / n;
            Console.WriteLine($"Результат работы LinkedList: {average} мс");

            Console.ReadKey();
        }
    }
}
