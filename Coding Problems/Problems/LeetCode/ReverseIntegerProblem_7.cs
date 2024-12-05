namespace Coding_Problems.Problems.LeetCode
{
    internal class ReverseIntegerProblem_7 : IProblem, ILeetCodeProblem
    {
        public int Id { get; } = 7;
        public string Name { get; } = "Reverse Integer Problem";
        public string Difficulty { get; } = "Medium";

        public void Solve()
        {
            Solve(exampleNum: 1, 123);
            Solve(exampleNum: 2, -123);
            Solve(exampleNum: 3, 120);
            Solve(exampleNum: 4, 2147483647);
        }

        private static void Solve(int exampleNum, int input)
        {
            int result = ReverseIntegerProblemSolution.Reverse(input);

            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Input: x = {input}");
            Console.WriteLine($"  Output: {result}");
            Console.WriteLine();
        }
    }

    internal class ReverseIntegerProblemSolution
    {
        public static int Reverse(int x)
        {
            char[] value = Math.Abs((long)x).ToString().ToCharArray();

            Array.Reverse(value);

            if (int.TryParse(value, out int reversed))
            {
                return x < 0 ? -reversed : reversed;
            }

            return 0;
        }
    }
}
