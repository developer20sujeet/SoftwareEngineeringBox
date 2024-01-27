public partial class Solution
{

	#region  using two pointer
	// Crux of the 'Backspace String Compare' Algorithm:
	// 1. Start Comparing from the End: Begin from the last character of both strings.
	// 2. Use Counters for Backspaces: Employ counters (sCounter and tCounter) to manage backspaces. These counters determine how many characters to skip.
	// 3. Inner While Loops for Continuous Backspaces: Use inner while loops to process continuous backspace characters ('#'). These loops adjust the counters and skip over the characters that are "erased" by backspaces.
	// 4. Outer While Loop for Character Comparison: The outer while loop is used for comparing the characters of both strings, taking into account the effective characters after processing backspaces.
	// 5. Return True if All Characters are Processed: After the outer loop, if both string pointers (i and j) have traversed their entire lengths (i.e., i < 0 && j < 0), it indicates that all characters were successfully processed and matched, resulting in a true return value. Otherwise, any discrepancy or unprocessed characters will lead to a false return value.

	/*
	
	Explanation of Each Point
		1. Start Comparing from the End: The algorithm starts comparing characters from the end of both strings since backspaces have a backward effect on strings.

		2. Use Counters for Backspaces: Counters (sCounter and tCounter) track the number of backspaces encountered. They are crucial for determining how many characters should be skipped or ignored in the comparison.

		3. Inner While Loops for Continuous Backspaces: These loops handle scenarios where multiple backspace characters occur consecutively. They adjust the counters accordingly, ensuring that the correct number of characters are skipped.

		4. Outer While Loop for Character Comparison: Once the inner loops have processed the backspaces, the outer loop compares the current characters of both strings. It decrements the pointers as long as the characters match.

		5. Return True if All Characters are Processed: The final condition checks if both pointers have gone past the start of their respective strings. If so, it means all characters (considering backspaces) matched, and the function returns true. If the loop is exited early due to a mismatch or if one string is processed completely before the other, it returns false.
			
	*/

	/// <summary>
	/// Compares two strings, taking into account backspaces ('#').
	/// Time Complexity: O(N + M), where N and M are the lengths of the input strings.
	/// Space Complexity: O(1), as no additional space is used.
	/// Algorithm: Two Pointer Approach.
	/// Data Structure: Strings.
	/// Company: Common in coding interviews (specific company not mentioned in LeetCode).
	/// Tips: Keep track of backspaces and skip characters accordingly.
	/// Lessons Learned: Understanding the effect of backspaces on string comparison.
	/// </summary>
	/// <param name="s">First input string.</param>
	/// <param name="t">Second input string.</param>
	/// <returns>True if the strings are equal after applying backspace operations; otherwise, false.</returns>
	public bool BackspaceCompare(string s, string t)
	{
		// First - In Backspace problem , you start processing from end 
		// Second - Crucial and Key - anytime if any position character do not match it is not same -
		// Protips - S= abc##t , T= adc##u - this is not same as last charcater is not matching and same apply to middle and start charctaer also 

		// Third - you need inner while loop to pocess repetative and continous ## backspace 
		// Fourth - plan is to keep ## counter incrementing and skip valid character for each # counter


		// Initialize pointers for both strings
		int sLength = s.Length - 1;
		int tLength = t.Length - 1;

		// Counters for backspaces
		int sCounter = 0;
		int tCounter = 0;

		// Process characters from the end using two pointers
		while (sLength >= 0 || tLength >= 0)
		{
			// Process continuous backspaces for string s
			// Third - you need inner while loop to pocess repetative and continous ## backspace 
			// Crucial - && (s[sLength] == '#' || sCounter > 0) 
			while (sLength >= 0 && (s[sLength] == '#' || sCounter > 0))
			{
				if (s[sLength] == '#')
				{
					sCounter++; // Increase counter for each backspace
				}
				else if (sCounter > 0)
				{
					sCounter--; // Skip a character for each backspace
				}

				// in both case string is getting consumed and processed - t[j] == '#' for deleting and tCounter > 0 for skipping ,
				sLength--; // Move to the previous character
			}

			// Process continuous backspaces for string t
			while (tLength >= 0 && (t[tLength] == '#' || tCounter > 0))
			{
				if (t[tLength] == '#')
				{
					tCounter++; // Increase counter for each backspace
				}
				else if (tCounter > 0)
				{
					tCounter--; // Skip a character for each backspace
				}
				tLength--; // Move to the previous character
			}

			// Check if current characters are equal
			if (sLength >= 0 && tLength >= 0 && s[sLength] == t[tLength])
			{
				// This moves the pointers for the next round of comparison.
				sLength--; // Move to the previous character in s
				tLength--; // Move to the previous character in t
			}
			else
			{
				/**
				 Break Condition: The else clause with the break statement is executed if either:
					One or both pointers move past the beginning of their strings (i < 0 || j < 0), meaning there are no more characters to compare, or
					The characters at the current positions are not equal (s[i] != t[j]), indicating a mismatch between the two strings.
				*/
				break; // Characters are not equal, or one string is fully processed
			}
		}

		// Check if both strings are fully processed and equal
		return sLength < 0 && tLength < 0;
	}

	#endregion


	#region using stack 


	/// <summary>
	/// Time complexity: O(n)
	/// Space complexity: O(n)
	/// Algorithm used: Stack
	/// Algorithmic coding pattern: Stack
	/// Data structure used: Stack
	/// Company name: Commonly asked in various companies
	/// </summary>
	public bool BackspaceCompare_stackWay(string S, string T)
	{
		// Step 1: Process both strings with backspaces
		string processedS = ProcessString(S);
		string processedT = ProcessString(T);

		// Step 2: Compare the processed strings
		return processedS == processedT;
	}

	/// <summary>
	/// Helper function to process the string with backspaces
	/// </summary>
	private string ProcessString(string str)
	{
		// Step 1: Initialize a stack to hold characters
		Stack<char> stack = new Stack<char>();

		// Step 2: Iterate through the string
		for (int i = 0; i < str.Length; i++)
		{
			// Step 2.1: Push character into stack if it's not a backspace
			if (str[i] != '#')
			{
				stack.Push(str[i]);
			}
			// Step 2.2: Pop character from stack if it's a backspace and stack is not empty
			else if (stack.Count > 0)
			{
				stack.Pop();
			}
		}

		// Step 3: Return the processed string
		return new string(stack.ToArray().Reverse().ToArray());
	}


	#endregion

}
