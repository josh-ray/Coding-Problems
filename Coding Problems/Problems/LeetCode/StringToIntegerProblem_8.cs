namespace Coding_Problems.Problems.LeetCode
{
    internal class StringToIntegerProblem_8 : IProblem, ILeetCodeProblem
    {
        public int Id { get; } = 8;
        public string Name { get; } = "String to Integer Problem (atoi)";
        public string Difficulty { get; } = "Medium";

        public void Solve()
        {
            Solve(exampleNum: 1, input: "42");
            Solve(exampleNum: 2, input: "-042");
            Solve(exampleNum: 3, input: "1337c0d3");
            Solve(exampleNum: 4, input: "0-1");
            Solve(exampleNum: 5, input: "words and 987");
            Solve(exampleNum: 6, input: "21474836460");
            Solve(exampleNum: 7, input: "20000000000000000000");
            Solve(exampleNum: 8, input: "-20000000000000000000");
            Solve(exampleNum: 9, input: "+-12");
        }

        private static void Solve(int exampleNum, string input)
        {
            int result = StringToIntegerProblemSolution.MyAtoi(input);

            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Input: s = \"{input}\"");
            Console.WriteLine($"  Output: {result}");
            Console.WriteLine();
        }
    }

    internal class StringToIntegerProblemSolution
    {
        // TODO: accepted but can be improved
        public static int MyAtoi(string s)
        {
            int result = 0;
            List<char> charsToPrint = [];

            char[] input = s.ToCharArray();

            // Step 1
            int index = 0;
            while (index < input.Length && input[index] == ' ')
            {
                index++;
            }

            if (index >= input.Length) { return result; }

            char current = input[index];
            // Step 2
            if (current == '-' || current == '+')
            {
                charsToPrint.Add(current);
                index++;
            }

            bool skipZeros = true;

            // Step 3
            while (index < input.Length)
            {
                current = input[index];

                if (current == '0')
                {
                    if (skipZeros == false)
                    {
                        charsToPrint.Add(current);
                    }
                    index++;
                }
                else if (char.IsDigit(current))
                {
                    charsToPrint.Add(current);
                    index++;
                    skipZeros = false;
                }
                else
                {
                    break;
                }
            }

            string pulledValue = string.Concat(charsToPrint);

            // Step 4
            if (long.TryParse(pulledValue, out long longResult))
            {
                // if a number
                if (longResult > int.MaxValue)
                {
                    result = int.MaxValue;
                }
                else if (longResult < int.MinValue)
                {
                    result = int.MinValue;
                }
                else
                {
                    result = (int)longResult;
                }

            }

            // check in-case value was not in range for long
            if (result == 0 && !string.IsNullOrEmpty(pulledValue) && pulledValue.Length >= 19)
            {
                if (pulledValue.Substring(0, 1) == "-")
                {
                    result = int.MinValue;
                }
                else
                {
                    result = int.MaxValue;
                }
            }

            return result;
        }
    }
}
