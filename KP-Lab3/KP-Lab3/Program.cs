class Program
{
    static char[,] a = new char[10, 10];
    static int k = 0;

    static void U(int i, int j)
    {
        char c = a[i, j];
        a[i, j] = ' ';

        if (c == 'W' && a[i + 1, j] == 'B') U(i + 1, j);
        if (c == 'B' && a[i + 1, j] == 'W') U(i + 1, j);
        if (c == 'W' && a[i - 1, j] == 'B') U(i - 1, j);
        if (c == 'B' && a[i - 1, j] == 'W') U(i - 1, j);
        if (c == 'W' && a[i, j + 1] == 'B') U(i, j + 1);
        if (c == 'B' && a[i, j + 1] == 'W') U(i, j + 1);
        if (c == 'W' && a[i, j - 1] == 'B') U(i, j - 1);
        if (c == 'B' && a[i, j - 1] == 'W') U(i, j - 1);
    }

    static void Main()
    {
        using (StreamReader reader = new StreamReader("C:\\Users\\Illia\\Downloads\\input.txt"))
        using (StreamWriter writer = new StreamWriter("C:\\Users\\Illia\\Downloads\\output.txt"))
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    a[i, j] = (char)reader.Read();
                }
                reader.ReadLine();
            }

            for (int i = 1; i <= 8; i++)
            {
                a[0, i] = ' ';
                a[9, i] = ' ';
                a[i, 0] = ' ';
                a[i, 9] = ' ';
            }

            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (a[i, j] != ' ')
                    {
                        k++;
                        U(i, j);
                    }
                }
            }

            writer.Write(k);
        }
    }
}