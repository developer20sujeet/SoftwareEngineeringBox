

public partial class Solution
{
    /*
        1. key techniques - sorting, skipping duplicates for i, left and right, and  two pointers

        Teaching 
            1. Sorting is a common first step in many array-related problems, especially when dealing with pairs or triplets. It often simplifies the problem.

        Concept : 
            1. How sort help with skipping duplicate element 
    */
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        // Step 1: Edge case check and sort the array.            
            IList<IList<int>> result = new List<IList<int>>();

            if (nums == null || nums.Length < 3) 
                return result;

            // Reason: A sorted array helps us use the two-pointer technique effectively.
            Array.Sort(nums);

            // Step 2: Loop through the sorted array and fix the first element for each triplet.
            for (int i = 0; i < nums.Length - 2; i++)
            {

                // Step 2.1: Skip duplicates to ensure unique triplets.
                // understand why -you need sum==0 from three element
                    // so you fix one element and find another two element in array by two pointer
                    // so if your fixed element 1 and other two element from entire array is 0 and 1 so triplet is -1,0,1
                    // now next element is 1 then other two two element from entire array is 0 and 1 so triplet is -1,0,1 again so we do not need same element next time
                if (i > 0 && nums[i] == nums[i - 1]) 
                    continue;

                // Step 2.2: Initialize two pointers, one at i+1 and the other at the end of the array.
                int left = i + 1, right = nums.Length - 1;

                // Step 2.3: Loop through with the two pointers to find triplets.
                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    // Step 2.4: Check if the sum of the triplet is zero, and adjust pointers accordingly.
                    if (sum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });

                        // Step 2.5: Skip duplicates for the second and third elements of the triplet.
                        // Skip duplicate elements for j - understand why 
                            // you are in loop left > right and fixed element 1 and left and right element is -1 and 0 so  triplet is -1,0,1
                            // in next loop if we get left++ == -1 and right-- == 0 then triplet is -1,0,1 again duplicate so we do not need same left and right element

                        while (left < right && nums[left] == nums[left + 1]) left++;

                        // // Skip duplicate elements for k
                        while (left < right && nums[right] == nums[right - 1]) right--;


                        // Move the pointer
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return result;

    }
}