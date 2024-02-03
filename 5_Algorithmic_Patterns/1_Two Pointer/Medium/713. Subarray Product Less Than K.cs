

public class Solution {
    public int NumSubarrayProductLessThanK(int[] nums, int k) 
    {
       if (nums == null || nums.length == 0 || k == 0) 
       {
            return 0;
       }
       
        int left = 0, count = 0;
        long prod = 1; // Use long to avoid integer overflow

        for (int right = 0; right < nums.Length; right++) 
        {
            prod *= nums[right];
            
            // Shrink the window from the left if the product exceeds or equals k
            while (prod >= k && left <= right) 
            {
                // remove value from left so that product remain lesser than k
                prod /= nums[left];

                // as product has left index value and we removed that value from product so we need to increment left and move forword
                left++;
            }

            // Add the number of subarrays ending at 'right' with product less than k
            // This expression calculates the size of the current window.
            // This method ensures that the algorithm dynamically maintains a valid window where the product condition is satisfied, and accurately counts the number of such subarrays.
            // calculates all subarray whose product is less than k at each step.
            count += right - left + 1;
        }
        
        return count;
    }
}


/*
    Example for Clarity
     // calculates all subarray whose product is less than k at each step.
     count += right - left + 1;


    The Sliding Window and Contiguous Subarrays
    When you're considering a window in the array from left to right where the product of all elements is less than k, 
    every possible contiguous subarray that ends at right and starts anywhere between left and right (inclusive) also has a product less than k. This is because removing elements from the left does not increase the product.


    Consider nums = [10, 5, 2] with k = 100 and a current window from left = 0 to right = 2 (inclusive):

    When right = 1 (element is 5), the valid subarrays counted are [10] and [10, 5]. Here, right - left + 1 equals 2, which correctly matches the count of new valid subarrays added by including 5.
    Expanding the window to include 2 (right = 2), you add:
    The subarray [2] itself.
    The subarray [5, 2] starting from left + 1.
    The subarray [10, 5, 2] spanning the whole current window.
    At each expansion step, right - left + 1 counts all these possibilities.
*/