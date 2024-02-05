

public partial class Solution {

#region Best and Optmimal - t(n) s(1)
        /// <summary>
        /// Time Complexity: O(n)
        /// Space Complexity: O(1)
        /// Algorithm used: Two Pointers
        /// Algorithmic coding pattern: Two Pointers
        /// Data structure used: Array
        ///
        /// Company name: This problem is commonly asked in interviews at Amazon, Google, and many other companies.
        /// Important Tips and Tricks: 
        ///     The water that can be trapped is limited by the shorter height.
        /// Lessons Learned: 
        ///     Be cautious when updating the leftMax and rightMax variables.
        ///     
        /// Central Idea: 
        ///         0. totally you need to visualize 
        ///         1. First remember if two wall is attched to each other then no water can be stored , it need space to store water - visualize
        ///         2. Second think - you have only two wall - left wall and right wall and space betwwen it then water can be stored in space 
        ///         3. Thnik - left wall or right wall whichever is smaller only that much water can be stored so 
        ///             so if left wall height is 5 and righ wall is 3 and space in beetween then - 5-3 = 2 unit water can be stored
        ///             but if left wall height is 5 and righ wall is 3 and 1 foot height wall in beetween then - min( 5,3)-1= 2 , -1 because water can not be stored upto wall in beetween
        ///         4. so for any index you need left max , right max and space height , second which ever max is shorted that would be limiting and only that match water can be stored and minus wall height which is in beetween so it is limitingMax-indexwallheight
        ///             -- so if left wall height is 5 and righ wall is 3 and 1 foot height wall = 3-1 = 2 
        ///  More breakdown 
        ///         1. water trapped by tower height[i] will be bounded by the maximum height on the left and right sides of height[i]
        ///         2. So we traverse elements on the left of height[i] to find the highest tower on the left side. Similarly, we traverse elements on the right of height[i] to find the highest tower on the right side
        ///         3. Note: We need to include the current height[i] in the calculation for finding the max height on the left and right sides
        ///         4. Rainwater trapped at the height[i] = min (maximum height on the left side, maximum height on the right side) - height[i]
        ///         
        /// </summary>
        public int Trap(int[] height)
        {
            // Step 1: Initialize pointers and variables
            // Reason: To keep track of the maximum height from both ends and the total trapped water
            int left = 0, right = height.Length - 1;


            int leftMax = 0, rightMax = 0;

            // to save result 
            int trappedWater = 0;

            // Step 2: Traverse the array using two pointers
            // Reason: To find trapping points based on maximum heights
            while (left < right)
            {
                // Step 3: Update maximum heights
                // Reason: The trapping water at any index depends on the maximum height of both wall from current index 
                // Based on concept you need leftmax and rightmax for very index to calculate trapping water 
                // Here's the thing: When your left and right pointers meet, you have effectively considered every "immediate right maximum" and "immediate left maximum" for each index. 
                leftMax = Math.Max(leftMax, height[left]);
                rightMax = Math.Max(rightMax, height[right]);

                // Step 4: Calculate trapped water
                // Reason: Water trapping is limited by the shorter height
                //          we're sure that leftMax is the limiting factor for water trapping at index left
                // we know that we will take min(left,right) - height[left]
                if (leftMax < rightMax)
                {
                    // Reason: Water can be trapped here as leftMax is limiting
                    trappedWater += leftMax - height[left];
                    left++;
                }
                else
                {
                    // Reason: Water can be trapped here as rightMax is limiting
                    // then rightMax is the limiting factor for water trapping at index right
                    trappedWater += rightMax - height[right];
                    right--;
                }
            }

            // Step 5: Return the total trapped water
            // Reason: Result of the problem
            return trappedWater;
        }
        #endregion
        

#region Brute Force time O(n^2) space O(1)

        /// <summary>
        /// Time Complexity: O(n^2)
        /// Space Complexity: O(1)
        /// Algorithm Used: Brute-force
        /// Algorithmic Coding Pattern: Nested Loops
        /// Data Structure Used: Array
        /// Company Name: Commonly asked in Amazon, Google, and Facebook
        /// 
        /// Important Tips and Tricks: 
        ///    
        /// </summary>
        public int Trap_bruteForce(int[] height)
        {
            // Initialize variables to store the result and temporary maximum heights
            int result = 0;
            int leftMax, rightMax;

            // Loop through the array to find trapped water at each index
            for (int i = 0; i < height.Length; i++)
            {
                // Reset leftMax and rightMax for each index
                leftMax = 0;
                rightMax = 0;

                // Find the maximum height to the left of the current index (excluding the index itself)
                for (int j = 0; j < i; j++)
                {
                    leftMax = Math.Max(leftMax, height[j]);
                }

                // Find the maximum height to the right of the current index (excluding the index itself)
                for (int j = i + 1; j < height.Length; j++)
                {
                    rightMax = Math.Max(rightMax, height[j]);
                }

                // this is more acurate - see PPT 
                // Add trapped water only when both sides are greater than the current height
                // if both side of wall is heigher than current index
                if (leftMax > height[i] && rightMax > height[i])
                {
                    //Finding minium as water can be trapped upto minium wall 
                    // Limiting factor - water can only be trapped upto minium of height of both wall height  
                    int minVal = Math.Min(leftMax, rightMax);

                    // - height[i] because water can not trapped upto current wall 
                    result += minVal - height[i];
                } 
            }

            // Return the total trapped water
            return result;
        }

        #endregion


 #region Dyanamic programming t-O(n) s-O(n)

        /// <summary>
        /// Method to trap rain water.
        /// Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// Algorithm: Dynamic Programming
        /// Data Structure Used: Array
        /// Company: This type of problem is often asked in companies like Amazon, Google, and Facebook.
        /// </summary>
        /// <param name="height">The heights array.</param>
        /// <returns>The total trapped water.</returns>
        public static int Trap_dynamicProgramming(int[] height)
        {
            int n = height.Length;

            // Step 1: Initialize leftMax and rightMax arrays.
            int[] leftMax = new int[n];
            int[] rightMax = new int[n];

            // Step 2: Fill in leftMax
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                max = Math.Max(max, height[i]);
                leftMax[i] = max;
            }

            // Step 3: Fill in rightMax
            max = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                max = Math.Max(max, height[i]);
                rightMax[i] = max;
            }

            // Step 4: Calculate trapped water
            int trappedWater = 0;
            for (int i = 0; i < n; i++)
            {
                trappedWater += Math.Min(leftMax[i], rightMax[i]) - height[i];
            }

            return trappedWater;
        }
        #endregion

        
}