namespace Coding_Problems.Problems.GeeksForGeeks.StringProblems
{
    internal class CheckForAnagram_2 : IProblem, IGeeksForGeeksProblem
    {
        public int Id { get; } = 2;
        public string Name { get; } = "Check For Anagram";
        public string Difficulty { get; } = "Easy";

        public void Solve()
        {
            Solve(1, "geeks", "kseeg");
            Solve(2, "allergy", "allergic");
            Solve(3, "g", "g");
        }

        private static void Solve(int exampleNum, string s1, string s2)
        {
            bool result = CheckForAnagramSolution.AreAnagrams(s1, s2);
            Console.WriteLine($"Example {exampleNum} ({s1}) and ({s2}) are anagrams? {result}");
        }
    }

    internal class CheckForAnagramSolution
    {
        public static bool AreAnagrams(string s1, string s2)
        {
            // Constraints state givens strings have at least one character
            if (s1.Length == 1 && s2.Length == 1)
            {
                // example 3 states single is anagram of itself, Lookup online says word can't be anagram of itself though
                return true;
            }

            if (s1.Length != s2.Length) { return false; }

            char[] input1 = s1.ToCharArray();
            Array.Sort(input1);
            char[] input2 = s2.ToCharArray();
            Array.Sort(input2);

            return input1.SequenceEqual(input2);
        }
    }
}
