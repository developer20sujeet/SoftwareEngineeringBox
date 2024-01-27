

//new Solution().TwoSum(new int[] { 2, 7, 11, 15 }, 9);





#region  Revise and practice 

public partial class Solution
{
    public bool BackspaceCompare(string s, string t)
    {

        // First - In Backspace problem , you start processing from end 
        // Second - Crucial and Key - anytime if any position character do not match it is not same -
        // Protips - S= abc##t , T= adc##u - this is not same as last charcater is not matching and same apply to middle and start charctaer also 

        // Third - you need inner while loop to pocess repetative and continous ## backspace 
        // Fourth - plan is to keep ## counter incrementing and skip valid character for each # counter


        int sLength = s.Length - 1;
        int tLength = t.Length - 1;

        int sCounter = 0;
        int tCounter = 0;


        //Two Pointer Approach 
        // process till all charctaer in string is processed 
        while (sLength >=0 && tLength >=0 )
        {
            
            // Third - you need inner while loop to pocess repetative and continous ## backspace 
            while(sLength>=0)
            {

                if(s[sLength].ToString() == "#")
                {
                    sCounter++; // increase for each # counter 
                }
                else if(sCounter >0 )
                {
                     sCounter--; // skipp valid charcater for each # counter 
                }

            }

             // Third - you need inner while loop to pocess repetative and continous ## backspace 
            while(tLength>=0)
            {

                if(t[tLength].ToString() == "##")
                {
                    tCounter++; // increase for each # counter 
                }
                else if(tLength >0 )
                {
                     tCounter--; // skipp valid charcater for each # counter 
                }
                
            }
            


            // Prepare for next iteration 
            // Crucial and condition to stop 
            if(sLength >=0 && tLength >=0 && (s[sLength] == t[tLength]) )
            {
                sLength--;
                tLength--;
            }
            else
            {
                // Crucial and condition to stop 
              break;
            }


        }

        // all characcter got processed successfully
        return sLength <= 0 && tLength <= 0;


    }
}


#endregion