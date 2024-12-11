namespace Coding_Problems.Problems.GeeksForGeeks.NoCategoryProblems
{
    internal class MissingInArray_1416 : IProblem, IGeeksForGeeksProblem
    {
        public int Id { get; } = 1416;
        public string Name { get; } = "Missing In Array";
        public string Difficulty { get; } = "Easy";

        public void Solve()
        {
            Solve(exampleNum: 1, input: [1, 2, 3, 5]);              // Expected = 4
            Solve(exampleNum: 2, input: [8, 2, 4, 5, 3, 7, 1]);     // Expected = 6
            Solve(exampleNum: 3, input: [1]);                       // Expected = 2
        }

        private static void Solve(int exampleNum, int[] input)
        {
            int result = MissingInArraySolution.MissingNumber(input);

            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Input: arr[] = [{string.Join(",", input)}]");
            Console.WriteLine($"  Output: {result}");
            Console.WriteLine();
        }
    }

    internal class MissingInArraySolution
    {
        public static int MissingNumber(int[] input)
        {
            // get sum of values in array
            int inputSum = 0;
            foreach(int num in input){
                inputSum += num;
            }

            // determine N (length + 1)
            int n = input.Length + 1;

            // calculate sum of 1 + 2 + ... + N 
            //   N * (N+1) / 2
            int totalNSum = n * (n+1) / 2;

            // subtract n sum - array sum
            return totalNSum - inputSum;
        }
    }

}