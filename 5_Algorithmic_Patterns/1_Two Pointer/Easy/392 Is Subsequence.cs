
public partial class Solution
{
    /// <summary>
        /// Time Complexity: O(n)
        /// Space Complexity: O(1)
        /// Algorithm Used: Two Pointer Method
        /// Algorithmic Coding Pattern: Two Pointer
        /// Data Structure Used: String
        /// Company Name: Commonly asked in various companies
        /// Important Tips and Tricks: Always remember to update both pointers correctly.
        /// Lessons Learned: Two pointers can provide a quick and efficient way to solve subsequence problems.
        /// </summary>
    public bool IsSubsequence(string s, string t)
    {       
        
            // Step 0: Handle edge case for empty string 's'
            // Reason: An empty string is always a subsequence of any string.
            if (string.IsNullOrEmpty(s))
                return true;

            // Step 1: Initialize two pointers for both strings
            // Reason: We will use pointers to traverse both strings.
            int pointerS = 0, pointerT = 0;

            // Step 2: Traverse the string t
            // Reason: To check if each character of s is found in t in the same order.
            while (pointerT < t.Length)
            {
                // Step 2.1: Compare the current character in t with the current character in s
                // Reason: We are looking for an exact match for each character in s within t.
                if (s[pointerS] == t[pointerT])
                {
                    pointerS++;  // Move the pointer for string s one step forward.

                    // Step 2.2: Check if all characters in s are found
                    // Reason: If all characters in s are found, then s is a subsequence of t.
                    if (pointerS == s.Length)
                        return true;
                }

                // Step 2.3: Always move the pointer for string t one step forward.
                // Reason: We need to check every character in t.
                pointerT++;
            }

            // Step 3: Return false if we come out of the loop
            // Reason: If we exit the loop, it means not all characters in s were found in t.
            return false;
        }
    }
}