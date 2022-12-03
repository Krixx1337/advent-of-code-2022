namespace AdventOfCode
{
    internal class Day3
    {
        private readonly string _filename = $"{AppDomain.CurrentDomain.BaseDirectory}\\Inputs\\day3.txt";

        private readonly char[] _alphabet =
        {
            '-',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        public Day3()
        {
            Console.WriteLine("--- Day 3 ---");

            Part1();
            Part2();
        }

        private void Part1()
        {
            var totalPriority = 0;
            var lines = File.ReadLines(_filename);
            foreach (var line in lines)
            {
                var first = line.Substring(0, line.Length / 2);
                var last = line.Substring(line.Length / 2, line.Length / 2);

                var common = first.Intersect(last);

                foreach (var c in common)
                {
                    var priority = Array.FindIndex(_alphabet, x => x == c);
                    totalPriority += priority;
                }
            }

            Console.WriteLine("[Part 1] Sum of the priorities: " + totalPriority);
        }

        private void Part2()
        {
            var totalPriority = 0;
            var lines = File.ReadLines(_filename).ToList();

            for (var i = 0; i < lines.Count; i += 3)
            {
                var first = lines[i];
                var second = lines[i + 1];
                var third = lines[i + 2];

                var common1 = first.Intersect(second).ToList();
                var common2 = second.Intersect(third).ToList();

                foreach (var c1 in common1)
                {
                    foreach (var c2 in common2)
                    {
                        if (c1 == c2)
                        {
                            var priority = Array.FindIndex(_alphabet, x => x == c1);
                            totalPriority += priority;
                        }
                    }
                }
            }

            Console.WriteLine("[Part 2] Sum of the priorities: " + totalPriority);
        }
    }
}
