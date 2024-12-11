namespace Coding_Problems.Problems.LeetCode
{
    internal class ContainerWithMostWater_11 : IProblem, ILeetCodeProblem
    {
        public int Id { get; } = 11;
        public string Name { get; } = "Container With Most Water";
        public string Difficulty { get; } = "Medium";

        public void Solve()
        {
            Solve(1, [1, 8, 6, 2, 5, 4, 8, 3, 7]);
            Solve(2, [1, 1]);
        }

        public static void Solve(int exampleNum, int[] input)
        {
            int result = ContainerWithMostWaterSolution.MaxArea(input);

            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Input: height = [{string.Join(",", input)}]");
            Console.WriteLine($"  Output: {result}");
            Console.WriteLine();
        }

    }

    internal class ContainerWithMostWaterSolution
    {
        // Accepted: can be improved
        public static int MaxArea(int[] height)
        {
            int maxArea = 0;

            int left = 0;
            int right = height.Length - 1;

            int prevLeftHeight = 0;
            int prevRightHeight = 0;

            while (left < right){
                int currLeftHeight = height[left];
                int currRightHeight = height[right];

                // if height is less than prev height or is equal to zero then area can't be greater
                if (currLeftHeight <= prevLeftHeight || currLeftHeight == 0){
                    left++;
                    continue;
                }

                if (currRightHeight <= prevRightHeight || currRightHeight == 0){
                    right--;
                    continue;
                }

                int containerHeight = Math.Min(currLeftHeight, currRightHeight);
                maxArea = Math.Max(maxArea, GetArea(containerHeight, right - left));
                
                if (currLeftHeight == currRightHeight){
                    // move both closer
                    left++;
                    right--;
                } else if (currLeftHeight < currRightHeight){
                    // move left closer
                    left++;
                } else{
                    // move right closer
                    right--;
                }
            }
        
            return maxArea;
        }

        // Time limit exceeded
        public static int MaxArea_TLE(int[] height)
        {
            int maxArea = 0;

            for (int i = 0; i < height.Length; i++){
                if (height[i] == 0) { continue; }

                for (int j = i + 1; j < height.Length; j++){
                    if (height[j] == 0) { continue; }

                    int containerHeight = Math.Min(height[i], height[j]);
                    maxArea = Math.Max(maxArea, GetArea(containerHeight, j - i));
                }
            }

            return maxArea;
        }

        private static int GetArea(int height, int width){
            return height * width;
        }
    }

}