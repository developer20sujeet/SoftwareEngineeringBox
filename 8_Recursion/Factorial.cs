public class Solution {
    public int Factorial(int n) {
        // Base case: if n is 0 or 1
        if (n <= 1) {
            return 1;
        }
        // Recursive case: n * factorial of n-1
        else {
            return n * Factorial(n - 1);
        }
    }
}
