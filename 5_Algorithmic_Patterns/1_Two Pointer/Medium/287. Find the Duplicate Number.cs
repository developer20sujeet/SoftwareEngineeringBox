public partial class Solution
{
    public ListNode DetectCycle(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return null; // No cycle if the list is empty or has only one node.
        }

        ListNode tortoise = head, hare = head;
        bool hasCycle = false;

        // Step 1: Detect if a cycle exists
        while (hare != null && hare.next != null)
        {
            tortoise = tortoise.next;      // Moves by 1 step
            hare = hare.next.next;         // Moves by 2 steps

            if (tortoise == hare)
            {
                hasCycle = true;           // Cycle detected
                break;
            }
        }

        // If no cycle, return null
        if (!hasCycle) return null;

        // Step 2: Find the start of the cycle
        tortoise = head;                  // Reset tortoise to the start of the list
        while (tortoise != hare)
        {
            tortoise = tortoise.next;     // Both move by 1 step now
            hare = hare.next;
        }

        // Tortoise (or hare) is now at the start of the cycle
        return tortoise;
    }
}
