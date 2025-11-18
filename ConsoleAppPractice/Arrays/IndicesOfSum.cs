namespace ConsoleAppPractice.Arrays;

public class IndicesOfSum
{
    public int[] FindIndicesOfTwoSum(int[] arr, int target)
    {
        //{8, 1, 5, 2, 0, 4}
        // target = 7

        var copyArr = arr.Order().ToArray();
        //{0, 1, 2, 4, 5, 8}

        var arrLength = arr.Length;

        int first = 0;
        var last = arrLength - 1;

        int[] sumIndicesArray = new int[2];

        while (first < last)
        {
            var sum = copyArr[first] + copyArr[last];
            if (sum == target)
            {
                for (int i = 0; i < arrLength; i++)
                {
                    if (arr[i] == first)
                    {
                        sumIndicesArray[0] = i;
                        break;
                    }
                }

                for (int i = arrLength - 1; i > 0; i--)
                {
                    if (arr[i] == last)
                    {
                        sumIndicesArray[1] = i;
                        break;
                    }
                }

                break;
            }
            else if (sum < target)
            {
                first++;
            }
            else
            {
                last--;
            }
        }
        return sumIndicesArray;

    }
}