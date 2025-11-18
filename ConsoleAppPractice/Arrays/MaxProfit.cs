namespace ConsoleAppPractice.Arrays;

public class MaxProfit
{
    public int CalculateProfit(int[] prices)
    {
        int min = int.MaxValue;
        int maxProfit = 0;

        for (int i = 0; i< prices.Length; i++)
        {
            if (prices[i] < min)
            {
                min = prices[i];
            }
            else if (prices[i] - min > maxProfit)
            {
                maxProfit = prices[i] - min;
            }
        }

        return maxProfit;
    }
}