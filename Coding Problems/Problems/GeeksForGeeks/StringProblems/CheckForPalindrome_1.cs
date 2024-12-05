namespace Coding_Problems.Problems.GeeksForGeeks.StringProblems
{
    internal class CheckForPalindrome_1 : IProblem, IGeeksForGeeksProblem
    {
        public int Id { get; } = 1;
        public string Name { get; } = "Check For Palindrome";
        public string Difficulty { get; } = "Easy";

        public void Solve()
        {
            Solve(1, "abba");
            Solve(2, "abc");
            Solve(3, "a");
            Solve(4, "acbca");
        }

        private static void Solve(int exampleNum, string input)
        {
            bool result = CheckForPalindromeSolution.IsPalindrome(input);
            Console.WriteLine($"Example {exampleNum} ({input}) is palindrome? {result}");
        }
    }

    internal class CheckForPalindromeSolution
    {
        public static bool IsPalindrome(string s)
        {
            if (s.Length <= 0) { return false; }

            if (s.Length == 1) { return true; }

            if (s.Length % 2 == 0)
            {
                // Even length
                string firstHalf = s[..(s.Length / 2)];
                string secondHalf = s[(s.Length / 2)..];

                return CompareParts(firstHalf, secondHalf);
            }
            else
            {
                // Odd length
                double mid = (double)s.Length / 2;

                string firstHalf = s[..Convert.ToInt32(Math.Floor(mid))];
                string secondHalf = s[Convert.ToInt32(Math.Ceiling(mid))..];

                return CompareParts(firstHalf, secondHalf);
            }
        }

        public static bool CompareParts(string firstHalf, string secondHalf)
        {
            char[] second = secondHalf.ToCharArray();
            Array.Reverse(second);
            return firstHalf == new string(second);
        }
    }
}
