namespace Coding_Problems.Problems.GeeksForGeeks.PuzzleProblems
{
    internal class CheckIsSquare_3 : IProblem, IGeeksForGeeksProblem
    {
        public int Id { get; } = 3;
        public string Name { get; } = "Check if four points form a square";
        public string Difficulty { get; } = "Easy";

        public void Solve()
        {
            Solve(exampleNum: 1, x1: 20, y1: 10, x2: 10, y2: 20, x3: 20, y3: 20, x4: 10, y4: 10);  // Yes
            Solve(exampleNum: 1, x1: 1, y1: 1, x2: 1, y2: 1, x3: 1, y3: 1, x4: 1, y4: 1);  // No
        }

        public static void Solve(int exampleNum, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            string result = CheckIsSquareSolution.IsSquare(x1, y1, x2, y2, x3, y3, x4, y4);
            Console.WriteLine($"Example {exampleNum}");
            Console.WriteLine($" Input:");
            Console.WriteLine($"   x1 = {x1}, y1 = {y1}    x2 = {x2}, y2 = {y2}");
            Console.WriteLine($"   x3 = {x3}, y3 = {y3}    x4 = {x4}, y4 = {y4}");
            Console.WriteLine($"  Output: {result}");
        }
    }

    internal class CheckIsSquareSolution
    {
        public static string IsSquare(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            if (x1 == x2){
                if (x3 == x4){
                    return BoolToYN(Math.Max(y1, y2) == Math.Max(y3, y4)
                        && Math.Min(y1, y2) == Math.Min(y3, y4)
                        && y1 != y2);
                }
                return "No";
            }

            if (x1 == x3){
                if (x2 == x4){
                    return BoolToYN(Math.Max(y1, y3) == Math.Max(y2, y4)
                        && Math.Min(y1, y3) == Math.Min(y2, y4)
                        && y1 != y3);
                }
                return "No";
            }

            if (x1 == x4){
                if (x2 == x3){
                    return BoolToYN(Math.Max(y1, y4) == Math.Max(y2, y3)
                        && Math.Min(y1, y4) == Math.Min(y2, y3)
                        && y1 != y4);
                }
                return "No";
            }

            return "No";
        }

        private static string BoolToYN(bool value){
            return value ? "Yes" : "No";
        }
    }
}