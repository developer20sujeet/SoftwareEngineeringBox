
public class Solution
{

    /// <summary>
    /// https://leetcode.com/problems/two-sum/description/
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum(int[] nums, int target)
    {

        (int value, int index)[] arraVal = SortArrayWhileKeepingIndexUnchanged(nums);


        int left = 0;
        int right = arraVal.Length - 1;
        long sum = 0;


        while (left < right)
        {
            sum = arraVal[left].value + arraVal[right].value;

            if (sum == target)
            {
                return [arraVal[left].index, arraVal[right].index];
            }
            else if (sum > target)
            {
                right--;
            }
            else
            {
                left++;
            }



        }

        return [-1, -1];

    }

    private (int value, int index)[] SortArrayWhileKeepingIndexUnchanged(int[] nums)
    {
        (int value, int index)[] arra = new (int, int)[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            arra[i] = (nums[i], i);
        }

        Array.Sort(arra);

        return arra;
    }
}