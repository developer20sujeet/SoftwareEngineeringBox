public partial class Solution
{
    //Key to solve it - forget zero and focus on non zero to move at front 
    public void MoveZeroes(int[] nums)
    {

        int position = 0;
        int arrLength = nums.Length - 1;


        for(int left=0; left < nums.Length; left++)
        {

            if (nums[left] != 0)
            {
                nums[position] = nums[left];
                position++;
            }

        }

        while(position < nums.Length)
        {
            nums[position] = 0;
             position++;

        }
    }
}