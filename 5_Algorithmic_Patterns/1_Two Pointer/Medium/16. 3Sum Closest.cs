public partial class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        // sort so that we can a apply two pointer
        Array.Sort(nums);

        int n = nums.Length;

        // initial value of closestSum is just a starting point, 
        // and the algorithm is expected to update this value as it examines various combinations of triplets.
        int closestSum = nums[0] + nums[1] + nums[2];


        // Fix one index and do two pointer : Basic of 3 pointer or 3 sum
        for (int i = 0; i < n - 2; i++)
        {
            int left = i + 1, right = n - 1;

            while (left < right)
            {
                int currentSum = nums[i] + nums[left] + nums[right];

                if (currentSum == target)
                {
                    // found closest sum
                    return currentSum;
                }

                // Need absolute value - irrespective of minus and plus 
                // Simple - take a Starting Point of three sum - Perform the 3Sum - Compare current sum with random sum - Update ClosestSum:
                if (Math.Abs(target - currentSum) < Math.Abs(target - closestSum))
                {
                    closestSum = currentSum;
                }

                if (currentSum < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return closestSum;
    }
}
