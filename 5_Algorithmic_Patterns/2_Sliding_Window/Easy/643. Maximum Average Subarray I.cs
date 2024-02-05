public partial class Solution
{
    #region Brute Force - Problem same value getting used many times

    /// <remarks>
    /// Time Complexity: O(n*k)
    /// Space Complexity: O(1)
    /// </remarks>
    public double FindMaxAverage1(int[] nums, int k)
    {
        int n = nums.Length;
        double maxSum = double.MinValue;

        // Iterate through the array
        // n - k - why think - it allows the nested loop to slide up to the last element
        for (int i = 0; i <= n - k; i++)
        {
            double currentSum = 0;

            // Calculate the sum of the next k elements
            // i + k - sliding window
            for (int j = i; j < i + k; j++)
            {
                currentSum += nums[j];
            }

            // Update maxSum if currentSum is greater
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }

        // Return the maximum average
        return maxSum / k;
    }
    #endregion

    #region Best - Sliding Window

    public double FindMaxAverage(int[] nums, int k)
    {
        // Rule of Sliding Window
        // 1. First Take total sum of Window -currentSum
        // 2. Adding the window - Add immediate next value in window value = + nums[i]
        // 3. exiting the window-Subtract last element from total window value = -nums[i - k]


        int n = nums.Length;
        double currentSum = 0;
        int left = 0; // remove element form curent window

        // 1. First Take total sum of Window k -currentSum
        for (int i = 0; i < k; i++)
        {
            currentSum += nums[i];
        }

        double maxSum = currentSum;

        // Slide the window across the array
        for (int i = k; i < n; i++)
        {
            // two thing on top of Current Window things

            // 1. A new element enters the window on the right
            // nums[i] adds the new element that just "slid into" the window.
            currentSum += nums[i];

            // 2. An old element exits the window on the left -typically, the element at the starting position of the previous window.
            // i - k = k positions back from the current element i
            // nums[left] effectively removes the element that just "slid out" of the window
            currentSum -= nums[left];
            left++; // as element moved from sum so increase

            maxSum = Math.Max(maxSum, currentSum);
        }

        // Calculate and return the maximum average
        return maxSum / k;
    }

    #endregion
}
