namespace AdventOfCode
{
    internal class Day2
    {
        private readonly string _filename = $"{AppDomain.CurrentDomain.BaseDirectory}\\Inputs\\day2.txt";
        private const int WinBonus = 6;
        private const int DrawBonus = 3;

        public Day2()
        {
            Console.WriteLine("--- Day 2 ---");

            Part1();
            Part2();
        }

        private enum Pick
        {
            Rock = 1,
            Paper,
            Scissors
        }

        private enum RoundEnd
        {
            Lose = 1,
            Draw,
            Win
        }

        private void Part1()
        {
            var totalScore = 0;

            var lines = File.ReadLines(_filename);
            foreach (var line in lines)
            {
                var picks = line.Split(" ");
                var oponent = StringToPick(picks[0]);
                var me = StringToPick(picks[1]);
                totalScore += CalcScorePart1(oponent, me);
            }

            Console.WriteLine("Part1: " + totalScore);
        }

        private void Part2()
        {
            var totalScore = 0;

            var lines = File.ReadLines(_filename);
            foreach (var line in lines)
            {
                var picks = line.Split(" ");
                var oponent = StringToPick(picks[0]);
                var roundEnd = (RoundEnd)StringToPick(picks[1]);
                totalScore += CalcScorePart2(oponent, roundEnd);
            }

            Console.WriteLine("Part2: " + totalScore);
        }

        private Pick StringToPick(string pick)
        {
            if (pick == "A" || pick == "X")
            {
                return Pick.Rock;
            }

            if (pick == "B" || pick == "Y")
            {
                return Pick.Paper;
            }

            return Pick.Scissors;
        }

        private int CalcScorePart1(Pick opponent, Pick me)
        {
            // draws
            if (opponent == Pick.Rock && me == Pick.Rock)
            {
                return (int)me + DrawBonus;
            }
            if (opponent == Pick.Paper && me == Pick.Paper)
            {
                return (int)me + DrawBonus;
            }
            if (opponent == Pick.Scissors && me == Pick.Scissors)
            {
                return (int)me + DrawBonus;
            }

            // wins
            if (opponent == Pick.Rock && me == Pick.Paper)
            {
                return (int)me + WinBonus;
            }
            if (opponent == Pick.Paper && me == Pick.Scissors)
            {
                return (int)me + WinBonus;
            }
            if (opponent == Pick.Scissors && me == Pick.Rock)
            {
                return (int)me + WinBonus;
            }

            // loses
            if (opponent == Pick.Rock && me == Pick.Scissors)
            {
                return (int)me;
            }
            if (opponent == Pick.Paper && me == Pick.Rock)
            {
                return (int)me;
            }
            if (opponent == Pick.Scissors && me == Pick.Paper)
            {
                return (int)me;
            }

            return 0;
        }

        private int CalcScorePart2(Pick opponent, RoundEnd roundEnd)
        {
            // draws
            if (opponent == Pick.Rock && roundEnd == RoundEnd.Draw)
            {
                return (int)opponent + DrawBonus;
            }
            if (opponent == Pick.Paper && roundEnd == RoundEnd.Draw)
            {
                return (int)opponent + DrawBonus;
            }
            if (opponent == Pick.Scissors && roundEnd == RoundEnd.Draw)
            {
                return (int)opponent + DrawBonus;
            }

            // wins
            if (opponent == Pick.Rock && roundEnd == RoundEnd.Win)
            {
                return (int)Pick.Paper + WinBonus;
            }
            if (opponent == Pick.Paper && roundEnd == RoundEnd.Win)
            {
                return (int)Pick.Scissors + WinBonus;
            }
            if (opponent == Pick.Scissors && roundEnd == RoundEnd.Win)
            {
                return (int)Pick.Rock + WinBonus;
            }

            // loses
            if (opponent == Pick.Rock && roundEnd == RoundEnd.Lose)
            {
                return (int)Pick.Scissors;
            }
            if (opponent == Pick.Paper && roundEnd == RoundEnd.Lose)
            {
                return (int)Pick.Rock;
            }
            if (opponent == Pick.Scissors && roundEnd == RoundEnd.Lose)
            {
                return (int)Pick.Paper;
            }

            return 0;
        }
    }
}
