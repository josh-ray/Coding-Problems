namespace Coding_Problems.Problems.GeeksForGeeks.DynamicProgrammingProblems
{
    internal class FirstNFibonacci_1 : IProblem, IGeeksForGeeksProblem
    {
        public int Id { get; } = 1;
        public string Name { get; } = "Print first n Fibonacci Numbers";
        public string Difficulty { get; } = "Basic";

        public void Solve()
        {
            Solve(exampleNum: 1, n: 5);
            Solve(exampleNum: 2, n: 7);
            Solve(exampleNum: 3, n: 2);
        }

        private static void Solve(int exampleNum, int n)
        {
            List<long> result = FirstNFibonacciSolution.PrintFibb(n);
            Console.WriteLine($"Example {exampleNum} first ({n}) fibonacci are: [{string.Join(", ", result)}]");
        }
    }

    internal class FirstNFibonacciSolution
    {
        public static List<long> PrintFibb(int n)
        {
            List<long> result = [];

            for (int i = 0; i < n; i++)
            {
                if (i < 2)
                { 
                    result.Add(1);
                    continue;
                }

                result.Add(result[i - 2] + result[i - 1]);
            }

            return result;
        }
    }
}
