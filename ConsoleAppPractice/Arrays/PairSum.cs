namespace ConsoleAppPractice.Arrays;

public class PairSum
{
    public bool HasPairWithSum(int[] array, int targetSum)
    {//[1, 4, -9, 5, 3], 9
        int max = int.MinValue;
        int min = int.MaxValue;

        var size = array.Length;
        for (int i = 0; i < size; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }

            if (array[i] < min)
            {
                min = array[i];
            }
        }
        bool[] visitied = new bool[max - min + 1];

        for (int i = 0; i < size; i++)
        {
            int compliment = targetSum - array[i];

            if (compliment >= min && compliment <= max && visitied[compliment - min])
            {
                return true;
            }

            visitied[array[i] - min] = true;
        }

        return false;
    }
}
