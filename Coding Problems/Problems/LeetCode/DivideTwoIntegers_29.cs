namespace Coding_Problems.Problems.LeetCode
{
    internal class DivideTwoIntegers_29 : IProblem, ILeetCodeProblem
    {
        public int Id { get; } = 29;
        public string Name { get; } = "Divide Two Integers";
        public string Difficulty { get; } = "Medium";

        public void Solve()
        {
            //Solve(exampleNum: 1, dividend: 10, divisor: 3);
            //Solve(exampleNum: 2, dividend: 7, divisor: -3);
            // TODO: edge cases
            //Solve(exampleNum: 3, dividend: int.MaxValue, divisor: 1);
            Solve(exampleNum: 4, dividend: int.MinValue, divisor: -1); // should be 2147483647
            Solve(exampleNum: 5, dividend: int.MinValue, divisor: 1); // should be -2147483648

            // Time limite exceeded
            Solve(exampleNum: 6, dividend: int.MaxValue, divisor: -1); 
        }

        private void Solve(int exampleNum, int dividend, int divisor)
        {
            int result = DivideTwoIntegersSolution.Divide(dividend, divisor);

            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Input: dividend = {dividend}, divisor = {divisor}");
            Console.WriteLine($"  Output: {result}");
            Console.WriteLine();
        }
    }

    internal class DivideTwoIntegersSolution
    {
        /*public static int bitShiftingSolution(int dividend, int divisor)
        {

        }

        private static bool IsPowerOfTwo(int value)
        {
            return (value & (value - 1)) == 0;
        }*/

        // Accepted but needs improvement
        public static int Divide(int dividend, int divisor)
        {
            // XOR operation: sign should be negative only if one operand is negative but not both
            bool negativeSign = (dividend < 0) ^ (divisor < 0);

            long quotient = 0;
            long longDividend = Math.Abs((long)dividend);
            long longDivisor = Math.Abs((long)divisor);

            if (longDivisor == 1)
            {
                quotient = longDividend;
            }
            else
            {
                // Could use bit shifting for other low value cases like 2 etc
                while (longDividend >= longDivisor)
                {
                    longDividend -= longDivisor;
                    quotient++;
                }
            }


            // Reapply sign
            quotient = negativeSign ? quotient * -1 : quotient;

            if (quotient > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (quotient < int.MinValue)
            {
                return int.MinValue;
            }
            else
            {
                return (int)quotient;
            }
        }

        // Time limit exceeded
        public static int Divide_TLE(int dividend, int divisor)
        {
            // XOR operation: sign should be negative only if one operand is negative but not both
            bool negativeSign = (dividend < 0) ^ (divisor < 0);

            long quotient = 0;
            long longDividend = Math.Abs((long)dividend);
            long longDivisor = Math.Abs((long)divisor);

            while (longDividend >= longDivisor)
            {
                longDividend -= longDivisor;
                quotient++;
            }

            // Reapply sign
            quotient = negativeSign ? quotient * -1 : quotient;

            if (quotient > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (quotient < int.MinValue)
            {
                return int.MinValue;
            }
            else
            {
                return (int)quotient;
            }
        }

        public static int orig(int dividend, int divisor)
        {
            // XOR operation: sign should be negative only if one operand is negative but not both
            bool negativeSign = (dividend < 0) ^ (divisor < 0);

            int count = 0;
            dividend = Math.Abs(dividend);
            divisor = Math.Abs(divisor);

            while (dividend >= divisor)
            {
                dividend -= divisor;
                count++;
            }

            return negativeSign ? count * -1 : count;
        }
    }
}
