namespace Lab2.Helpers;

public static class MainLogic
{
    public static IncomeDataDto GetIncomeData(string inputString)
    {
        string[] parts = inputString.Split(' ');

        int[] numbersLineParameters = new int[3];
        int[] numbersToFind = new int[parts.Length - 3];

        for (int i = 0; i < parts.Length; i++)
        {
            int number;
            if (int.TryParse(parts[i], out number))
            {
                if (i < 3)
                {
                    numbersLineParameters[i] = number;
                }
                else
                {
                    numbersToFind[i - 3] = number;
                }
            }
            else
                throw new CustomException($"Invalid number {parts[i]}. Numbers must be integers!");

        }

        return new IncomeDataDto()
        {
            NumbersLineParameters = numbersLineParameters,
            NumbersToFind = numbersToFind
        };

    }

    public static void NumbersCheck(IncomeDataDto incomeData)
    {
        if (incomeData.NumbersLineParameters.Length != 3)
            throw new CustomException("Should be first 3 parameters!");

        if (!incomeData.NumbersToFind.All(n => n > 0) && !incomeData.NumbersLineParameters.All(n => n > 0))
            throw new CustomException("All numbers in file must be more then 0");

        if (incomeData.NumbersLineParameters[2] != incomeData.NumbersToFind.Length)
            throw new CustomException($"Third parameter {incomeData.NumbersLineParameters[2]} do not equals to number " +
                $"of elements we need to delete {incomeData.NumbersToFind.Length}!");

        if (incomeData.NumbersLineParameters[1] > incomeData.NumbersLineParameters[0])
            throw new CustomException("Step must be less or equal to amount of elements");
    }

    public static int[] CreateMainArray(IncomeDataDto incomeData)
    {
        int[] numberArray = new int[incomeData.NumbersLineParameters[0]];

        for (int i = 0; i < numberArray.Length; i++)
        {
            numberArray[i] = i + 1;
        }

        return numberArray;
    }

    public static int[] DeletedSeconds(IncomeDataDto incomeData, int[] array)
    {
        int k = incomeData.NumbersLineParameters[1];

        int[] resultSeconds = new int[incomeData.NumbersLineParameters[2]];

        List<int> list = array.ToList();

        int second = 0;

        while (list.Count() >= k)
        {
            List<int> removingPositions = new List<int>();
            for (int i = k - 1; i < list.Count(); i += k)
            {
                second++;
                for (int j = 0; j < incomeData.NumbersLineParameters[2]; j++)
                {
                    if (list[i] == incomeData.NumbersToFind[j])
                    {
                        resultSeconds[j] = second;
                    }
                }

                removingPositions.Add(list[i]);
            }

            foreach (int i in removingPositions)
            {
                list.Remove(i);
            }
        }

        return resultSeconds.ToArray();

    }
}
