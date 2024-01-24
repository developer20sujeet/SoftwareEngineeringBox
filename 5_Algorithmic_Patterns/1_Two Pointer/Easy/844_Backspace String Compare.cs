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
	public bool BackspaceCompare(string s, string t)
	{
		int i = s.Length - 1, j = t.Length - 1;

		//# backspace counter
		int sCounter = 0, tCounter = 0;

		while (i >= 0 || j >= 0)
		{
			while (i >= 0 && (s[i] == '#' || sCounter > 0))
			{
				if (s[i] == '#')
					sCounter++;
				else
					sCounter--;

				i--;
			}

			while (j >= 0 && (t[j] == '#' || tCounter > 0))
			{
				if (t[j] == '#')
					tCounter++;
				else
					tCounter--;

				// in both case string is getting consumed and processed - t[j] == '#' for deleting and tCounter > 0 for skipping , 
				j--;
			}

			// the very crucial point - after string is processed above if s[i] != t[j] it means there is mismatch
			// Example s= ab#c , t ad#c
			if (i >= 0 && j >= 0 && s[i] == t[j])
			{
				// This moves the pointers for the next round of comparison.
				i--;
				j--;
			}
			else
			{
				/**
				 Break Condition: The else clause with the break statement is executed if either:
					One or both pointers move past the beginning of their strings (i < 0 || j < 0), meaning there are no more characters to compare, or
					The characters at the current positions are not equal (s[i] != t[j]), indicating a mismatch between the two strings.
				*/
				break;
			}
		}

		// all charater got processed. If all character is not processed then it means there was mismatch
		return i < 0 && j < 0;
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
