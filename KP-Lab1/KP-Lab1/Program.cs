class Program
{
    static void Main()
    {
        Console.WriteLine("Input N");
        int N = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Input K");
        int K = Convert.ToInt32(Console.ReadLine());

        if (K < N * 2 || K > 7 * N)
            Console.WriteLine("No Solution!");

        else
        {
            string maxNumber = FindMaxNumber(N, K);
            string minNumber = FindMinNumber(N, K);

            Console.WriteLine(minNumber + " " + maxNumber);
        }
    }

    static string FindMinNumber(int N, int K)
    {
        string minNumber = "";
        bool isCompleted = false;
        int remainingBlackStripes = K;
        int numbersLeft = N;

        for (int i = 1; i <= N; i++)
        {

            for (int j = 0; j <= 9; j++)
            {
                try
                {

                    int blackStripesInDigit = CountBlackStripesInDigit(j);

                    int timeNumbersLeft = numbersLeft - 1;

                    int leftStripesInDigit = remainingBlackStripes - blackStripesInDigit;

                    if (leftStripesInDigit > 7 * timeNumbersLeft)
                        throw new CustomException("Invalid number for rest stripes in digit");

                    if (leftStripesInDigit < timeNumbersLeft * 2)
                        throw new CustomException("Number has too many stripes");

                    if (blackStripesInDigit > remainingBlackStripes)
                        throw new CustomException("Total numbet of stripes is too low");

                    if (numbersLeft == 1 && blackStripesInDigit != remainingBlackStripes)
                        throw new CustomException("Error amount of stripes");

                    if (minNumber.Length == 0 && j == 0)
                        throw new CustomException("Number can not starts with 0");

                    numbersLeft = timeNumbersLeft;
                    minNumber += j;
                    remainingBlackStripes -= blackStripesInDigit;
                    break;
                }
                catch (CustomException ex) { }
            }

        }

        return minNumber;
    }

    static string FindMaxNumber(int N, int K)
    {
        string maxNumber = "";
        int remainingBlackStripes = K;
        int numbersLeft = N;

        for (int i = 1; i <= N; i++)
        {
            for (int j = 9; j >= 0; j--)
            {
                try
                {
                    int blackStripesInDigit = CountBlackStripesInDigit(j);

                    int timeNumbersLeft = numbersLeft - 1;

                    int leftStripesInDigit = remainingBlackStripes - blackStripesInDigit;

                    if (leftStripesInDigit < timeNumbersLeft * 2)
                        throw new CustomException("Number has too many stripes");

                    if (blackStripesInDigit > remainingBlackStripes)
                        throw new CustomException("Total numbet of stripes is too low");

                    if (leftStripesInDigit > 7 * timeNumbersLeft)
                        throw new CustomException("Invalid number for rest stripes in digit");

                    if (numbersLeft == 1 && blackStripesInDigit != remainingBlackStripes)
                        throw new CustomException("Error amount of stripes");

                    numbersLeft = timeNumbersLeft;
                    maxNumber += j;
                    remainingBlackStripes -= blackStripesInDigit;
                    break;
                }
                catch (CustomException e) { }
            }
        }
        return maxNumber;
    }

    static int CountBlackStripesInDigit(int digit)
    {
        int[] blackStripesInDigit = { 6, 2, 5, 5, 4, 5, 6, 3, 7, 6 };
        return blackStripesInDigit[digit];
    }
}

public class CustomException : Exception
{
    public string Message { get; set; } = string.Empty;

    public CustomException(string message)
       => Message = message;
}