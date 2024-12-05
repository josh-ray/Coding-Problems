using System.Text;

namespace Coding_Problems.Problems.LeetCode
{
    internal class ZigzapConversionProblem_6 : IProblem, ILeetCodeProblem
    {
        public int Id { get; } = 6;
        public string Name { get; } = "Zig zap Conversion Problem";
        public string Difficulty { get; } = "Medium";

        public void Solve()
        {
            string input = "PAYPALISHIRING";
            Solve(exampleNum: 1, input: input, numRows: 3);
            Solve(exampleNum: 2, input: input, numRows: 4);
            Solve(exampleNum: 3, input: "A", numRows: 1);
            Solve(exampleNum: 4, input: "AB", numRows: 1);
        }

        private static void Solve(int exampleNum, string input, int numRows)
        {
            string result = ZigzapConversionProblemSolution.Convert(input, numRows);

            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Input: s = \"{input}\", numRows = {numRows}");
            Console.WriteLine($"  Output: \"{result}\"");
            Console.WriteLine();
        }
    }

    internal class ZigzapConversionProblemSolution
    {
        // TODO: accepted but can be improved
        public static string Convert(string s, int numRows)
        {
            if (numRows == 1) { return s; }

            List<string>[] zigzag = new List<string>[numRows];
            // need to initialze, is this structure efficient?

            for (int i = 0; i < numRows; i++)
            {
                zigzag[i] = [];
            }

            bool directionDown = true;
            int writePos = 0;

            foreach (char c in s.ToCharArray())
            {
                //zigzag[writePos].Add(c.ToString());
                zigzag[writePos].Add(Char.ToString(c));

                if (directionDown)
                {
                    // straight down
                    if (writePos != numRows - 1)
                    {
                        writePos++;
                        continue;
                    }
                    else
                    {
                        directionDown = false;
                        writePos--;
                    }
                }
                else
                {
                    // zig-zagging up
                    if (writePos != 0)
                    {
                        writePos--;
                        continue;
                    }
                    else
                    {
                        directionDown = true;
                        writePos++;
                    }

                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (List<string> row in zigzag)
            {
                sb.Append(String.Join("", row));
            }

            return sb.ToString();
        }
    }
}
