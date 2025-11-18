using Microsoft.AspNetCore.Mvc;

namespace Practice.API.Controllers;

[Route("api/first")]
[ApiController]
public class FirstController : ControllerBase
{
    [HttpGet]
    public int[] TwoSum1([FromQuery] int[] nums, [FromQuery] int target)
    {
        var newNums = nums.Order().ToArray();
        var num2Index = -1;
        var num1Index = -1;

        for (int i = 0; i < newNums.Length; i++)
        {
            var num2 = target - nums[i];
            num2Index = Array.IndexOf(nums, num2);

            if (num2Index != -1)
            {
                num1Index = Array.IndexOf(nums, nums[i]);

                if (num2Index == num1Index)
                {
                    num2Index = Array.FindLastIndex(nums, x => x == num2);

                    if (num2Index == num1Index)
                    {
                        continue;
                    }
                }

                break;
            }
        }

        return [num1Index, num2Index];
    }

    [HttpGet("t")]

    public int[] TwoSum2([FromQuery] int[] nums, [FromQuery] int target)
    {
        var map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            var x = map.TryGetValue(complement, out int v);
            if (map.TryGetValue(complement, out int value))
            {
                return new int[] { value, i };
            }
            map[nums[i]] = i;
        }
        return new int[0];
    }

    [HttpGet("use-dic")]

    public Dictionary<int, int> TwoSum3([FromQuery] int[] nums, [FromQuery] int target)
    {
        return new Dictionary<int, int>();
    }

    [HttpPost("three-sum")]

    public IList<IList<int>> ThreeSum([FromBody] int[] nums)
    {
        var finalList = new List<IList<int>>(3);
        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int secondIteration = i + 1;
            int thiredIterataion = nums.Length - 1;

            while (secondIteration < thiredIterataion)
            {
                var sum = nums[i] + nums[secondIteration] + nums[thiredIterataion];
                if (sum == 0)
                {
                    finalList.Add([nums[i], nums[secondIteration], nums[thiredIterataion]]);

                    while (secondIteration < thiredIterataion && nums[secondIteration] == nums[secondIteration + 1]) secondIteration++;
                    while (secondIteration < thiredIterataion && nums[thiredIterataion] == nums[thiredIterataion - 1]) thiredIterataion--;

                    secondIteration++;
                    thiredIterataion--;

                }
                else if (sum < 0)
                {
                    secondIteration++;
                }
                else
                {
                    thiredIterataion--;
                }
            }
        }

        return finalList;
    }


    [HttpGet("exception")]
    public IActionResult WriteException()
    {
        throw new InvalidOperationException("This is a test exception.");
    }

    [HttpPost("add-two-numbers")]
    public LinkedList<int> AddTwoNumbers([FromQuery] LinkedList<int> l1, [FromQuery] LinkedList<int> l2)
    {
        var reversedl1 = l1.Reverse();
        var reversedl2 = l2.Reverse();

        var num1 = int.Parse(string.Join("", reversedl1));
        var num2 = int.Parse(string.Join("", reversedl2));

        var sum = (num1 + num2).ToString();

        return new LinkedList<int>(sum.Select(x => int.Parse(x.ToString())));

        //return new LinkedList<int>();
    }


    //[HttpPost("add-two-numbers-nodes")]
    //public ListNode AddTwoNumbersNodes([FromBody] ListsInput lists)
    //{

    //    return new ListNode();
    //}

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

    public class ListsInput
    {
        public ListNode? L1 { get; set; }
        public ListNode? L2 { get; set; }
    }


    [HttpPost("add-two-numbers-nodes")]
    public ListNode AddTwoNumbersNodes([FromBody] ListsInput lists)
    {
        return AddTwoNumbers(lists.L1, lists.L2);
    }

    private ListNode AddTwoNumbers(ListNode l1, ListNode l2)
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

            current.next = new ListNode(sum % 10);
            current = current.next;

            l1 = l1?.next;
            l2 = l2?.next;
        }

        return dummyHead.next;
    }

}
