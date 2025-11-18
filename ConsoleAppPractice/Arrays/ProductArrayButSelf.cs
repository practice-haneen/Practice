namespace ConsoleAppPractice.Arrays;

public class ProductArrayButSelf
{
    public int[] Generate(int[] data)
    {
        int product = 1;
        int n = data.Length;
        int[] prefixProduct = new int[n];

        prefixProduct[0] = 1;
        for (int i = 1; i < n; i++)
        {

            prefixProduct[i] = prefixProduct[i - 1] * data[i - 1];
        }

        int[] suffixArray = new int[n];
        suffixArray[n - 1] = 1;

        for (int i = n - 2; i >= 0; i--)
        {
            suffixArray[i] = suffixArray[i + 1] * data[i + 1];
        }

        int[] resultArray = new int[data.Length];

        for (int i = 0; i < n; i++)
        {
            resultArray[i] = suffixArray[i] * prefixProduct[i];
        }

        return resultArray;
    }
}