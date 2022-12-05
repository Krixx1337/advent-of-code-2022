namespace AdventOfCode
{
    internal class Day4
    {
        private readonly string _filename = $"{AppDomain.CurrentDomain.BaseDirectory}\\Inputs\\day4.txt";

        public Day4()
        {
            Console.WriteLine("--- Day 4 ---");

            Part1();
            Part2();
        }

        private void Part1()
        {
            var totalOverlaps = 0;
            var lines = File.ReadLines(_filename);
            foreach (var line in lines)
            {
                var pairs = line.Split(",");

                var section1 = new Section(pairs[0].Split("-"));
                var section2 = new Section(pairs[1].Split("-"));

                var smallerCount = section1.Range.Count < section2.Range.Count
                    ? section1.Range.Count
                    : section2.Range.Count;

                var overlaps = section1.Range.Intersect(section2.Range).Count() == smallerCount;
                if (overlaps)
                    totalOverlaps++;
            }

            Console.WriteLine("[Part 1] " + totalOverlaps);
        }

        private void Part2()
        {
            var totalOverlaps = 0;
            var lines = File.ReadLines(_filename);
            foreach (var line in lines)
            {
                var pairs = line.Split(",");

                var section1 = new Section(pairs[0].Split("-"));
                var section2 = new Section(pairs[1].Split("-"));

                var overlaps = section1.Range.Intersect(section2.Range).Any();
                if (overlaps)
                    totalOverlaps++;
            }

            Console.WriteLine("[Part 2] " + totalOverlaps);
        }
    }

    public class Section
    {
        public Section(string[] section)
        {
            var start = int.Parse(section[0]);
            var finish = int.Parse(section[1]);

            Range = new List<int>();
            for (var i = start; i <= finish; i++)
            {
                Range.Add(i);
            }
        }

        public List<int> Range { get; set; }
    }
}
