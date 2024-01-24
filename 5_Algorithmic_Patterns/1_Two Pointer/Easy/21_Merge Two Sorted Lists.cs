
public partial class Solution
{	
	public ListNode MergeTwoLists(ListNode list1, ListNode list2)
	{
		//Create a dummy node to simplify the process of building the merged list.
		ListNode dummy = new ListNode(0);
		
		//  Use the 'tail' pointer to iterate through and build the merged list.
		ListNode tail = dummy;

		while (list1 != null && list2 != null)
		{
			if (list1.val < list2.val)
			{
				tail.next = list1;
				list1 = list1.next;
			}
			else
			{
				tail.next = list2;
				list2 = list2.next;
			}
			
			// Important part
			tail = tail.next;
		}

		// Explicitly appending the remaining elements of list1 or list2
		if (list1 != null)
		{
			tail.next = list1;
		}
		else if (list2 != null)
		{
			tail.next = list2;
		}

		return dummy.next;
	}
}


// Definition for singly-linked list.
public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int val = 0, ListNode next = null)
	{
		this.val = val;
		this.next = next;
	}
}
