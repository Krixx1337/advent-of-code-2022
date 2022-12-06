namespace AdventOfCode
{
    internal class Day6
    {
        private readonly string _filename = $"{AppDomain.CurrentDomain.BaseDirectory}\\Inputs\\day6.txt";

        public Day6()
        {
            Console.WriteLine("--- Day 6 ---");

            var characters = File.ReadAllText(_filename);

            var part1 = GetMarker(characters, 4);
            Console.WriteLine("[Part 1] " + part1);

            var part2 = GetMarker(characters, 14);
            Console.WriteLine("[Part 2] " + part2);
        }

        private int GetMarker(string characters, int messageLength)
        {
            var buffer = new char[messageLength];
            var bufferCount = 0;

            for (var i = 0; i < characters.Length; i++)
            {
                buffer[bufferCount] = characters[i];
                bufferCount++;

                if (bufferCount <= messageLength - 1)
                    continue;

                if (buffer.Distinct().Count() != buffer.Length)
                {
                    // duplicate found
                    buffer = new char[messageLength];
                    bufferCount = 0;
                    i -= messageLength - 1;
                }
                else
                {
                    return i + 1;
                }
            }

            return 0;
        }
    }
}
