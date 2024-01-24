public partial class Solution
{
	/// <summary>
	/// Central point :
	///     1. Clue - your array is sorted in decreasing order so last index is bigger 
	///     2. so Squered sorted array last index should be bigger as well 
	///     3. so take a poistion = array.length-1 and start putting the bigger at last and move to left 
	/// </summary>
	/// <param name="nums"></param>
	/// <returns></returns>
	public int[] SortedSquares(int[] nums)
	{
		if (nums == null || nums.Length == 0)
		{
			return [];
		}

		// two pointer 
		int left = 0;
		int right = nums.Length - 1;

		int[] result = new int[nums.Length];
		int position = nums.Length - 1;

		// Step 2: Iterate through the array using two pointers
		while (left <= right)
		{
			// Step 2.1: Compare absolute values
			if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
			{
				// Step 2.1.1: Add square of the left element if it's greater
				result[position] = nums[left] * nums[left];
				left++; // Move the left pointer
			}
			else
			{
				// Step 2.1.2: Add square of the right element if it's greater or equal
				result[position] = nums[right] * nums[right];
				right--; // Move the right pointer
			}

			position--; // Decrement the position for the next largest square
		}

		return result;

	}
}