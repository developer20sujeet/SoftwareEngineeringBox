
public class Solution
{

	#region Brute Force Solution

	/// <summary>
	/// check every possible pair of numbers 
	/// Inefficiencies - time complexity of O(n^2)
	/// </summary>
	/// <param name="nums"></param>
	/// <param name="target"></param>
	/// <returns></returns>
	public int[] TwoSum1(int[] nums, int target)
	{
		for (int i = 0; i < nums.Length; i++)
		{
			for (int j = i + 1; j < nums.Length; j++)
			{
				if (nums[i] + nums[j] == target)
				{
					return [i, j];
				}
			}
		}

		return [-1, -1];
	}


	#endregion

	#region  Optimized -Two pointer - Array and sort based solution

	/// <summary>
	///  Tips 
	///   1. Learn to sort array without changing element index 
	///   2. Learn tuples
	/// </summary>
	/// <param name="nums"></param>
	/// <param name="target"></param>
	/// <returns></returns>
	public int[] TwoSum(int[] nums, int target)
	{
		//Tuple
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

	#endregion

	#region Optimized  hash table and Dictionary based 

	/// <summary>
	/// time complexity of O(n) and a space complexity of O(n)
	/// </summary>
	/// <param name="nums"></param>
	/// <param name="target"></param>
	/// <returns></returns>
	public int[] TwoSumOptimized(int[] nums, int target)
	{
		Dictionary<int, int> map = [];

		for (int i = 0; i < nums.Length; i++)
		{
			int complement = target - nums[i];

			//if (map.ContainsKey(complement))
			if (map.TryGetValue(complement, out int value))
			{
				return [value, i];
			}

			// Add the current number to the dictionary
			if (!map.ContainsKey(nums[i]))
			{
				// value is key == index is value 
				map[nums[i]] = i;
			}
		}

		return [-1, -1];
	}



	#endregion
}