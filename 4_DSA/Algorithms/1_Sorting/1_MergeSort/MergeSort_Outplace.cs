using System;

public class MergeSorts_OutPlace
{
    // Main MergeSort function
    public static void MergeSort(int[] A)
    {
        #region  Base case for recursion

        if (A.Length <= 1)
        {
            return; // Array is already sorted if it has 1 or 0 elements
        }

        #endregion Base case for recursion


        #region Divide -Division Phase (Splitting the Array)

        // Find the midpoint of the array
        int mid = A.Length / 2;

        // Create left subarray
        int[] L = new int[mid];

        // Create right subarray
        int[] R = new int[A.Length - mid];

        // Copy the elements to the left subarray
        for (int i = 0; i < mid; i++)
        {
            L[i] = A[i];
        }

        // Copy the elements to the right subarray
        for (int i = mid; i < A.Length; i++)
        {
            R[i - mid] = A[i];
        }

        #endregion Divide


        #region Conquer -Conquering Phase (Sorting and Merging)

        // Recursively sort the left subarray
        MergeSort(L);

        // Recursively sort the right subarray
        MergeSort(R);

        #endregion Conquer

        // Merge the sorted subarrays
        // merge method is executed for every stack frame
        // Merge on Return: As the recursive calls return, merge is executed for each pair of sorted subarrays, which merges them into a single sorted array. This happens at each level of the recursion as the call stack unwinds.
        // The merge function is not just called at the very end; it is called at the end of each recursion level.
        Merge(L, R, A);
    }

    // The Merge function as seen in the provided image
    public static void Merge(int[] L, int[] R, int[] A)
    {
        // Length of left subarray
        int nL = L.Length;

        // Length of right subarray
        int nR = R.Length;

        // Initialize pointers for subarrays and the main array
        int i = 0,
            j = 0,
            k = 0;

        // While there are elements in both subarrays
        while (i < nL && j < nR)
        {
            if (L[i] <= R[j])
            {
                A[k] = L[i]; // Take element from left subarray
                i++; // Move pointer in left subarray
            }
            else
            {
                A[k] = R[j]; // Take element from right subarray
                j++; // Move pointer in right subarray
            }

            k++; // Move pointer in main array
        }

        // Copy any remaining elements from left subarray, if any
        while (i < nL)
        {
            A[k] = L[i];
            i++;
            k++;
        }

        // Copy any remaining elements from right subarray, if any
        while (j < nR)
        {
            A[k] = R[j];
            j++;
            k++;
        }
    }

    // Utility method to print the array
    public static void PrintArray(int[] array)
    {
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    // Example usage
    public static void Driver()
    {
        int[] array = { 2, 4, 1, 6, 8, 5,3,7 };
        Console.WriteLine("Original Array: ");
        PrintArray(array);

        MergeSort(array);

        Console.WriteLine("Sorted Array: ");
        PrintArray(array);
    }

    /*
        Notes
        Explanation:
            Divide: The array A is divided into two halves, L (left) and R (right).
            Conquer: Each half is sorted recursively by calling MergeSort on L and R till array element is left 1.
            
            Merge: The sorted halves are then merged back together using the Merge function, which compares the elements of L and R and copies them into A in sorted order.
            
            Base Case: The recursion stops when an array length is less than or equal to 1, as it's already sorted.

    */
}
