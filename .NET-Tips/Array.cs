
internal class Tips
{
    public int[] TwoSum1(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] + nums[j] == target)
            {
                return new int [i, j];
            }
        }
    }
}

