
using System.Text.RegularExpressions;

namespace Lab3.Helpers;

public static class MainLogic
{
    static char[,] a = new char[10, 10];
    
    static void Turtle(int i, int j)
    {
        char c = a[i, j];
        a[i, j] = ' ';

        if (c == 'W' && a[i + 1, j] == 'B')
            Turtle(i + 1, j);
        if (c == 'B' && a[i + 1, j] == 'W')
            Turtle(i + 1, j);
        if (c == 'W' && a[i, j + 1] == 'B')
            Turtle(i, j + 1);
        if (c == 'B' && a[i, j + 1] == 'W')
            Turtle(i, j + 1);
        if (c == 'W' && a[i, j - 1] == 'B')
            Turtle(i, j - 1);
        if (c == 'B' && a[i, j - 1] == 'W')
            Turtle(i, j - 1);
        if (c == 'W' && a[i - 1, j] == 'B')
            Turtle(i - 1, j);
        if (c == 'B' && a[i - 1, j] == 'W')
            Turtle(i - 1, j);
    }
    public static bool CheckValues(string text)
    {
        bool result = false;

        text = Regex.Replace(text, @"[\p{P}\s\r\n]+", "");

        if (text.Length != 64)
            throw new CustomException("Number of values must be 64");

        if(Regex.IsMatch(text, "^[wb]+$"))
            throw new CustomException("Text must contain symbols W and B");

        return result = true;
    }

    public static int Calculating(string text)
    {
        int k = 0;

        if (CheckValues(text))
            {
            int index = 0;

            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    a[i, j] = text[index++];
                }
            }

            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (a[i, j] != ' ')
                    {
                        k++;
                        Turtle(i, j);
                    }
                }
            }
        }
        return k;
    }
}
