namespace Coding_Problems.Problems.LeetCode
{
    internal class DecodeWays_91 : IProblem, ILeetCodeProblem
    {
        public int Id { get; } = 91;
        public string Name { get; } = "Decode Ways Problem";
        public string Difficulty { get; } = "Medium";

        public void Solve()
        {
            Solve(exampleNum: 1, input: "12");
            Solve(exampleNum: 2, input: "226");
            Solve(exampleNum: 3, input: "06");
            Solve(exampleNum: 4, input: "10"); // Expected = 1
            Solve(exampleNum: 5, input: "2101"); // Expected = 1
        }

        private static void Solve(int exampleNum, string input)
        {
            int result = DecodeWaysSolution.NumDecodings(input);

            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Input: s = \"{input}\"");
            Console.WriteLine($"  Output: {result}");
            Console.WriteLine();
        }
    }

    internal class DecodeWaysSolution
    {
        // TODO: edge cases
        public static int NumDecodings(string s)
        {
            // According to example 3, leading zeros nullify the message
            if (s[..1] == "0") { return 0; }

            // at least one way to decode
            int count = 1;

            char[] input = s.ToCharArray();

            for (int i = 0; i < input.Length - 1; i++)
            {
                _ = int.TryParse($"{input[i]}{input[i+1]}", out int value);

                // if last iteration and number is 10 or 20 then do not count (s = "10" expected output = 1, not 2)

                if (value >= 10 
                    && value <= 26 
                    && !(i == input.Length - 2 && (value == 10 || value == 20)))
                { count++; }
            }

            return count;
        }
    }
}
