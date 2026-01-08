using System.Collections.Generic;

public static class Arrays
{
    public static double[] MultiplesOf(double start, int count)
    {
        // PLAN:
        // 1. Create an array that can hold the required number of multiples.
        // 2. Loop through each index of the array.
        // 3. For each index, calculate the next multiple by multiplying
        //    the starting value by (index + 1).
        // 4. Store the calculated value in the array.
        // 5. Return the completed array.

        double[] result = new double[count];

        for (int i = 0; i < count; i++)
        {
            result[i] = start * (i + 1);
        }

        return result;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Determine how many values need to move from the end of the list
        //    to the front based on the amount.
        // 2. Use GetRange to copy the last "amount" values of the list.
        // 3. Use GetRange to copy the remaining values at the beginning.
        // 4. Clear the original list.
        // 5. Add the values that were at the end first.
        // 6. Add the remaining beginning values after.

        List<int> endPart = data.GetRange(data.Count - amount, amount);
        List<int> frontPart = data.GetRange(0, data.Count - amount);

        data.Clear();
        data.AddRange(endPart);
        data.AddRange(frontPart);
    }
}
