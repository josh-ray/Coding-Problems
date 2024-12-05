namespace Coding_Problems.Problems.LeetCode
{
    internal class LongestPalindromicSubstringProblem_5 : IProblem, ILeetCodeProblem
    {
        public int Id { get; } = 5;
        public string Name { get; } = "Longest Palindromic Substring Problem";
        public string Difficulty { get; } = "Medium";

        public void Solve()
        {
            Solve(1, "babad");
            Solve(2, "cbbd");
            Solve(3, "kaklsdkartbbtrlaksjklfdjlafkjsl");
            Solve(4, "ac");
            Solve(5, "xaaaabbbbbbbbbbccccccccccddddddddddeeeeeeeeeeffffffffffgggggggggghhhhhhhhhhiiiiiiiiiijjjjjjjjjjkkkkkkkkkkllllllllllmmmmmmmmmmnnnnnnnnnnooooooooooppppppppppqqqqqqqqqqrrrrrrrrrrssssssssssttttttttttuuuuuuuuuuvvvvvvvvvvwwwwwwwwwwxxxxxxxxxxyyyyyyyyyyzzzzzzzzzzyyyyyyyyyyxxxxxxxxxxwwwwwwwwwwvvvvvvvvvvuuuuuuuuuuttttttttttssssssssssrrrrrrrrrrqqqqqqqqqqppppppppppoooooooooonnnnnnnnnnmmmmmmmmmmllllllllllkkkkkkkkkkjjjjjjjjjjiiiiiiiiiihhhhhhhhhhggggggggggffffffffffeeeeeeeeeeddddddddddccccccccccbbbbbbbbbbaaaaaaaabbbbbbbbbbccccccccccddddddddddeeeeeeeeeeffffffffffgggggggggghhhhhhhhhhiiiiiiiiiijjjjjjjjjjkkkkkkkkkkllllllllllmmmmmmmmmmnnnnnnnnnnooooooooooppppppppppqqqqqqqqqqrrrrrrrrrrssssssssssttttttttttuuuuuuuuuuvvvvvvvvvvwwwwwwwwwwxxxxxxxxxxyyyyyyyyyyzzzzzzzzzzyyyyyyyyyyxxxxxxxxxxwwwwwwwwwwvvvvvvvvvvuuuuuuuuuuttttttttttssssssssssrrrrrrrrrrqqqqqqqqqqppppppppppoooooooooonnnnnnnnnnmmmmmmmmmmllllllllllkkkkkkkkkkjjjjjjjjjjiiiiiiiiiihhhhhhhhhhggggggggggffffffffffeeeeeeeeeeddddddddddccccccccccbbbbbbbbbbaaaa");
        }

        private static void Solve(int exampleNum, string input)
        {
            string result = LongestPalindromicSubstringSolution.LongestPalindrome(input);

            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Input: s = \"{input}\"");
            Console.WriteLine($"  Output: \"{result}\"");
            Console.WriteLine();
        }
    }

    // TODO: Works and accepted but not at all efficient compared with other answers
    internal class LongestPalindromicSubstringSolution
    {
        public static string LongestPalindrome(string s)
        {
            if (s.Length == 1 || IsPalindrome(s)) { return s; }
            if (s.Length == 2)
            {
                return s.Substring(0, 1);
            }

            int testLength = s.Length - 1;
            while (testLength >= 2)
            {
                // test until last segment, left to right
                string segment = "";
                int start = 0;

                do
                {
                    segment = s.Substring(start, testLength);
                    if (IsPalindrome(segment)) { return segment; }

                    start++;
                } while (segment != s.Substring(s.Length - testLength));

                testLength--;
            }

            return s.Substring(0, 1);
        }

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
