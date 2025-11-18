namespace ConsoleAppPractice.Arrays;

public class ContainerWithMostWater
{
    public static int Get(int[] container)
    {
        var length = container.Length;

        //[1,8,6,2,5,4,8,3,7]
        //[0,1,2,3,4,5,6,7,8]

        var left = 0;
        var maxArea = 0;
        var right = length - 1;//8

        while (left < right)
        {
            var width = right - left;

            var area = Math.Min(left, right) * width;

            maxArea = Math.Max(maxArea, area);

            if (container[left] < container[right])
            {
                left++;//1
            }
            else if (container[right] < container[left])
            {
                right--;
            }
            else
            {
                left++;
                right--;
            }
        }

        return maxArea;
    }
}