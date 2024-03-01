using System;

public class MergeSort_InPlace
{
    public static void MergeSort(int[] A, int left, int right)
    {
        if (left < right)
        {
            // Find the midpoint of the array
            // same as int mid = (right + left) / 2; but some time addition might be bigger and error come for int overflow so it done this way
            int mid = left + (right - left) / 2;

            // Recursively sort the left half
            MergeSort(A, left, mid);

            // Recursively sort the right half
            MergeSort(A, mid + 1, right);

            // Merge the sorted halves
            Merge(A, left, mid, right);
        }
    }

    // Merge function modified to use temporary space efficiently
    public static void Merge(int[] A, int left, int mid, int right)
    {
        int[] temp = new int[right - left + 1];
        int i = left, j = mid + 1, k = 0;

        // Traverse both halves and copy the smaller element to the temp array
        while (i <= mid && j <= right)
        {
            if (A[i] <= A[j])
            {
                temp[k++] = A[i++];
            }
            else
            {
                temp[k++] = A[j++];
            }
        }

        // Copy any remaining elements of the left half into temp
        while (i <= mid)
        {
            temp[k++] = A[i++];
        }

        // Copy any remaining elements of the right half into temp
        while (j <= right)
        {
            temp[k++] = A[j++];
        }

        // Copy the merged elements back into the original array
        for (i = left, k = 0; i <= right; i++, k++)
        {
            A[i] = temp[k];
        }
    }

    public static void PrintArray(int[] array)
    {
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public static void Driver()
    {
        int[] array = { 12, 11, 13, 5, 6, 7 };
        Console.WriteLine("Original Array: ");
        PrintArray(array);

        MergeSort(array, 0, array.Length - 1);

        Console.WriteLine("Sorted Array: ");
        PrintArray(array);
    }
}
