using System.Text.RegularExpressions;

namespace AdventOfCode
{
    internal class Day5
    {
        private readonly string _filename = $"{AppDomain.CurrentDomain.BaseDirectory}\\Inputs\\day5.txt";

        public Day5()
        {
            Console.WriteLine("--- Day 5 ---");

            Part1();
            Part2();
        }

        private void Part1()
        {
            var crates = LoadCrates();
            var lines = File.ReadLines(_filename).ToList();
            for (var i = 10; i < lines.Count; i++)
            {
                var line = lines[i];
                var move = new Move(line);

                for (var j = 0; j < move.Count; j++)
                {
                    move.MoveCratePart1(crates);
                }
            }

            Console.Write("[Part 1]: ");
            foreach (var crate in crates)
            {
                Console.Write(crate.LastOrDefault());
            }
            Console.WriteLine();
        }

        private void Part2()
        {
            var crates = LoadCrates();
            var lines = File.ReadLines(_filename).ToList();
            for (var i = 10; i < lines.Count; i++)
            {
                var line = lines[i];
                var move = new Move(line);

                move.MoveCratePart2(crates);
            }

            Console.Write("[Part 2]: ");
            foreach (var crate in crates)
            {
                Console.Write(crate.LastOrDefault());
            }
            Console.WriteLine();
        }

        private List<List<string>> LoadCrates()
        {
            var columns = new List<List<string>> { new(), new(), new(), new(), new(), new(), new(), new(), new() };

            var lines = File.ReadLines(_filename).ToList();
            for (var i = 7; i >= 0; i--)
            {
                var count = 0;
                var line = lines[i];

                for (var j = 1; j < line.Length; j += 4)
                {
                    var crate = line[j];
                    if (crate == ' ')
                    {
                        count++;
                        continue;
                    }

                    columns[count].Add(crate.ToString());
                    count++;
                }
            }

            return columns;
        }
    }

    public class Move
    {
        private readonly int _from;
        private readonly int _to;

        public Move(string str)
        {
            var list = new List<int>();
            var numbers = string.Join(string.Empty, Regex.Matches(str, @"\d+").Select(m => m.Value + " "));
            var splitted = numbers.Split(" ");

            foreach (var s in splitted)
            {
                if (int.TryParse(s, out var nr))
                {
                    list.Add(nr);
                }
            }

            Count = list[0];
            _from = list[1];
            _to = list[2];
        }

        public int Count { get; set; }

        public void MoveCratePart1(List<List<string>> crates)
        {
            var from = crates[_from - 1];
            var lastItem = from.Last();
            from.RemoveAt(from.Count - 1);

            var to = crates[_to - 1];
            to.Add(lastItem);
        }

        public void MoveCratePart2(List<List<string>> crates)
        {
            var from = crates[_from - 1];
            var lastItems = Enumerable.Reverse(from).Take(Count).Reverse().ToList();
            from.RemoveRange(from.Count - Count, Count);

            var to = crates[_to - 1];
            to.AddRange(lastItems);
        }
    }
}
