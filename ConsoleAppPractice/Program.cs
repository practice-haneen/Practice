// See https://aka.ms/new-console-template for more information
using ConsoleAppPractice.Arrays;
using static Practice.API.Controllers.FirstController;

Console.WriteLine("Hello, World!");

ListNode firsListNode = new ListNode(2, new ListNode(3, new ListNode(4)));
ListNode secondListNode = new ListNode(1, new ListNode(5, new ListNode(6)));

Console.WriteLine(firsListNode.val);
Console.WriteLine(firsListNode.next.val);
Console.WriteLine();
Solution solution = new Solution();
solution.AddTwoNumbers1(firsListNode, secondListNode);
solution.RemoveDuplicates(new ListNode(8, new ListNode(8, new ListNode(9, new ListNode(8, new ListNode(2, new ListNode(9, new ListNode(8))))))));

PairSum PairSum = new PairSum();
PairSum.HasPairWithSum([1, 4, -9, 5, 3], 9);

IndicesOfSum indicesOfSum = new IndicesOfSum();
var indicesOfTwoSumArray = indicesOfSum.FindIndicesOfTwoSum([1, 4, -9, 5, 3], 5);

for (int i = 0; i < 2; i++)
{
    Console.WriteLine(indicesOfTwoSumArray[i]);
}

SortArrayOf123 sortArrayOf123 = new();
int[] arr = { 2, 2, 2, 1, 0, 1, 0, 2, 0 };

var arrLength = arr.Length;

sortArrayOf123.Sort(arr, arrLength);

//for (int i = 0; i < 9; i++)
//{
//    Console.WriteLine(arr[i]);
//}

ProductArrayButSelf productArrayButSelf = new ProductArrayButSelf();
var array = productArrayButSelf.Generate([1, 2, 3, 4]);

for (int i = 0; i < array.Length; i++)
{
    Console.WriteLine("product Array But Self = " + array[i]);
}


//MaxProfit MaxProfit = new MaxProfit();
//int profit = MaxProfit.CalculateProfit([1, 5, 3, 7, 1, 4]);

//Console.WriteLine("Profit is = " + profit);



ContainerWithMostWater containerWithMostWater = new ContainerWithMostWater();
int max = containerWithMostWater.Get([1, 8, 6, 2, 5, 4, 8, 3, 7]);
Console.WriteLine("container With Most Water = " + max);
public class Solution
{
    public ListNode AddTwoNumbers1(ListNode l1, ListNode l2)
    {
        ListNode dummyHead = new ListNode(0);
        ListNode current = dummyHead;
        int carry = 0;

        while (l1 != null || l2 != null || carry != 0)
        {
            int val1 = l1?.val ?? 0;
            int val2 = l2?.val ?? 0;

            int sum = val1 + val2 + carry;
            carry = sum / 10;
            var x = sum % 10;
            current.next = new ListNode(sum % 10);
            current = current.next;

            l1 = l1?.next;
            l2 = l2?.next;
        }

        return dummyHead.next;
    }

    public ListNode RemoveDuplicates(ListNode head)
    {
        if (head == null) return null;

        HashSet<int> seen = new HashSet<int>();
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode prev = dummy;
        ListNode current = head;

        while (current != null)
        {
            if (seen.Contains(current.val))
            {
                // Duplicate found, remove it
                prev.next = current.next;
            }
            else
            {
                // First time seeing this value
                seen.Add(current.val);
                prev = current;
            }

            current = current.next;
        }

        return dummy.next;
    }

}