

public partial class Solution
{
    //DNF - algorithms to solve 
    public void SortColors(int[] nums)
    {
        // to put all 0 at front 
        int low = 0;

        // to traverse the whole array from index 0 till end of array  and swap 
        // traverse +swap
        int mid = 0; 

        // to put all 2nd at end 
        int high = nums.Length - 1;
        
        // mid index=0 till high
        while (mid <= high)
        {
            switch (nums[mid])
            {
                // if found 0 in middle then need to put at beginning 
                case 0:
                    // Swap nums[mid] and nums[low] and increment 'low' and 'mid'.
                    Swap(nums, low, mid);
                    low++; // increase as 0 is put at index low and now need to adjust next low
                    mid++; // Increment as value at this index got processed 
                    break;


                // if found 1 in middle then it is already at currect place no action just see next value in array
                case 1:
                    // '1' is in its right place, just move 'mid'.
                    mid++;
                    break;


                // if found 2 in middle then need to put at end  
                case 2:
                    // Swap nums[mid] and nums[high] and decrement 'high'.
                    Swap(nums, mid, high);
                    high--; // descreasing because value at index high processed 
                            // 'mid' is not incremented because the swapped element needs to be evaluated also as hight swapped value can be 0 that need to go at begining 
                    break;
            }
        }
    }

    /// <summary>
    /// Swaps two elements in an array.
    /// </summary>
    /// <param name="nums">The array containing the elements.</param>
    /// <param name="i">The index of the first element.</param>
    /// <param name="j">The index of the second element.</param>
    private void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
        // A temporary variable 'temp' is used to hold the value of nums[i] while nums[i] and nums[j] are swapped.
    }
}