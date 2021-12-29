using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Task1361
{
    class Program
    {
        static string[] words = File.ReadAllText(
            String.Concat(Directory.GetCurrentDirectory(), @"\Text1.txt")
            ).Split(
                    new char[] { ' ', '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries
                   );
        static List<string> list = new List<string>();
        static LinkedList<string> linkedList = new LinkedList<string>();

        static void Main(string[] args)
        {

            var timer = new Stopwatch();
            timer.Start();

            long n = 10, sum = 0;
            for (int i = 0; i < n; i++)
            {
                timer.Restart();

                AddToLastOfList();

                timer.Stop();
                sum += timer.ElapsedMilliseconds;
            }
            var average = sum / n;
            Console.WriteLine($"Результат вставки в конец List: {average} мс");

            sum = 0;
            for (int i = 0; i < n; i++)
            {
                timer.Restart();

                AddToLastOfLinkedList();

                timer.Stop();
                sum += timer.ElapsedMilliseconds;
            }
            average = sum / n;
            Console.WriteLine($"Результат вставки в конец LinkedList: {average} мс");

            sum = 0;
            for (int i = 0; i < n; i++)
            {
                timer.Restart();

                AddToMiddleOfList();

                timer.Stop();
                sum += timer.ElapsedMilliseconds;
            }
            average = sum / n;
            Console.WriteLine($"Результат вставки в середину List: {average} мс");

            sum = 0;
            for (int i = 0; i < n; i++)
            {
                timer.Restart();

                AddToMiddleOfLinkedList();

                timer.Stop();
                sum += timer.ElapsedMilliseconds;
            }
            average = sum / n;
            Console.WriteLine($"Результат вставки в середину LinkedList: {average} мс");

            Console.ReadKey();
        }

        static void AddToLastOfList()
        {
            foreach (var word in words)
            {
                list.Add(word);
            }
            list.Clear();
        }

        static void AddToLastOfLinkedList()
        {
            foreach (var word in words)
            {
                linkedList.AddLast(word);
            }
            linkedList.Clear();
        }

        static void AddToMiddleOfList()
        {
            list.AddRange(new string[2] { words[0], words[words.Length - 1]});
            for (int i = 1; i < words.Length - 1; i++)
            {
                AddToSecondPositionOfList(words[i]);
            }
            list.Clear();
        }

        static void AddToSecondPositionOfList(string word)
        {
            var newList = new List<string>();
            newList.Add(list[0]);
            newList.Add(word);
            for (int j = 1; j < list.Count; j++)
            {
                newList.Add(list[j]);
            }
            list = newList;
        }

        static void AddToMiddleOfLinkedList()
        {
            linkedList.AddFirst(words[0]);
            linkedList.AddLast(words[words.Length - 1]);
            for (int i = 1; i < words.Length - 1; i++)
            {
                linkedList.AddAfter(linkedList.First, words[i]);
            }
            linkedList.Clear();
        }
    }
}
