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
                    move.MoveCrate(crates);
                }
            }

            Console.Write("[Part 1]: ");
            foreach (var crate in crates)
            {
                Console.Write(crate.LastOrDefault());
            }
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
            From = list[1];
            To = list[2];
        }

        public int Count { get; set; }
        public int From { get; set; }
        public int To { get; set; }

        public void MoveCrate(List<List<string>> crates)
        {
            var from = crates[From - 1];
            var lastItem = from.Last();
            from.RemoveAt(from.Count - 1);

            var to = crates[To - 1];
            to.Add(lastItem);
        }
    }
}
