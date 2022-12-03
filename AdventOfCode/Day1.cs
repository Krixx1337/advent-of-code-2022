namespace AdventOfCode
{
    internal class Day1
    {
        private readonly string _filename = $"{AppDomain.CurrentDomain.BaseDirectory}\\Inputs\\day1.txt";

        public Day1()
        {
            Console.WriteLine("--- Day 1 ---");

            var totalCaloriesList = new List<int>();
            var totalCalories = 0;

            var lines = File.ReadLines(_filename);
            foreach (var line in lines)
            {
                if (int.TryParse(line, out var calories))
                {
                    totalCalories += calories;
                }
                else
                {
                    totalCaloriesList.Add(totalCalories);
                    totalCalories = 0;
                }
            }

            var max = totalCaloriesList.Max(t => t);
            Console.WriteLine("max: " + max);

            // part 2
            var orderedList = totalCaloriesList.OrderByDescending(x => x).ToList();
            var sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += orderedList[i];
            }

            Console.WriteLine("sum: " + sum);
        }
    }
}
