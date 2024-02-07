public partial class Solution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        int n = nums.Length;
        int left = 0;
        int sum = 0;
        int minLength = int.MaxValue; // Use MaxValue to simplify comparison later

        for (int right = 0; right < n; right++)
        {
            sum += nums[right]; // Expand the window to the right

            // Shrink the window from the left as much as possible while keeping sum >= target
            while (sum >= target)
            {
                minLength = Math.Min(minLength, right - left + 1); // Update minLength if possible
                sum -= nums[left]; // Shrink the window from the left
                left++; // Move left pointer to shrink the window
            }
        }

        // Check if we have found a valid subarray
        return minLength == int.MaxValue ? 0 : minLength;
    }
}
