
public partial class Solution
{
    public int MaxArea(int[] height)
    {
        // max width between two array index 
        int width = 0;

        // Minimum height between two array value at two index (Left and right)
        int minHeight = 0;

        int maxWaterArea = int.MinValue;


        int leftIndex = 0;
        int rightIndex = height.Length - 1;

        while (leftIndex < rightIndex)
        {
            // max width between two array index 
            width = rightIndex - leftIndex;

            // Minimum height between two array value at two index (Left and right)
            minHeight = Math.Min(height[leftIndex], height[rightIndex]);

            // Max water that can hold 
            maxWaterArea = Math.Max((width * minHeight), maxWaterArea);

            // idea is to move toward max vertical line - so compare which vertical line is shorter 
            // which ever is shorter move that pointer 
            if (height[leftIndex] < height[rightIndex])
            {
                leftIndex++;
            }
            else
            {
                rightIndex--;
            }
        }
        
        return maxWaterArea;
    }
}