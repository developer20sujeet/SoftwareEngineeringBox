
/*
 1. Understand contiguous subarrays - each element is subarray + rest
 2. See code how it work 

    // printing all contiguous subarrays of an array

    int[] arr = {1, 2, 3};
    Solution solution = new Solution();
    solution.PrintContiguousSubarrays(arr);
    right-left+1 
     when right and left =0 then 1 
     when r=1 left=0 then 2
     when r=2 left =0 then 3

    Output 
    [1]
    [1, 2]
    [1, 2, 3]
    [2]
    [2, 3]
    [3]

*/

public partial class Solution {

    // Method to print all contiguous subarrays of a given array

    public void PrintContiguousSubarrays(int[] arr) 
    {
        // Determine the length of the array to set boundaries for iteration
        int n = arr.Length;

        // Outer loop to select the start index of the subarray
        for (int start = 0; start < n; start++) 
        {
            // Inner loop to select the end index of the subarray
            // It starts from the 'start' index to ensure we're only considering contiguous subarrays
            for (int end = start; end < n; end++) 
            {
                // Print the subarray defined from the current start to the current end index
                Console.Write("[");

                // Iterate from the start index to the end index to print each element of the subarray
                for (int i = start; i <= end; i++) 
                {
                    // Print the current element
                    // Add a comma after all but the last element for proper formatting
                    Console.Write(arr[i] + (i < end ? ", " : ""));
                }

                Console.WriteLine("]"); // Close the subarray printout and move to a new line
            }
        }
    }
}
