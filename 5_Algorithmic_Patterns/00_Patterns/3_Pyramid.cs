using System;

partial class Solution
{
    /// <summary>
    /// Key for it 
    /// 1. get the total column 
    /// 2. Get total space left side and total space right side - and use that formula
    /// </summary>
    /// <param name="n"></param>
    public void PrintPyramidStar(int n)
    {
        for (int i = 1; i < n; i++)
        {
            //space
            for (int j = 1; j <= n-i - 1; j++) { 

                Console.Write(" ");

            }

            //star
            for (int j = 1; j <=i*2 - 1; j++) { 

                Console.Write("*");

            }

            //space
            for (int j = 1; j <=n-i - 1; j++) { 

                Console.Write(" ");

            }

            Console.WriteLine();
        }
    }
}

/* 5 row  9 column - 
    *    
   ***   
  *****  
******* 
*********


*/