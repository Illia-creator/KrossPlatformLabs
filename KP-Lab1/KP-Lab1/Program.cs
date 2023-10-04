using iTextSharp.text.pdf;
using System.ComponentModel;
using System.IO;
using System.Reflection.Metadata;
using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;

class Program
{
    [STAThread]
    static void Main()
    {
        try
        {
            Console.WriteLine("Write Path To File");
            string path = Console.ReadLine();
            int[] numbers = new int[2];
            string[] result = new string[2];

            if (CheckFile(path))
            {
                numbers = GetNumbers(path);

                if (numbers == null)
                    throw new CustomException("Numbers in file were not found");

                if (numbers[1] < numbers[0] * 2 || numbers[1] > 7 * numbers[0])
                    Console.WriteLine("No Solution!");

                result[0] = FindMinNumber(numbers);
                result[1] = FindMaxNumber(numbers);

                WriteAnswer(result);

                Console.WriteLine("Complete");
            }
            else 
            { Console.WriteLine("File does not exist"); }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }

    static bool CheckFile(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException();

           
        return true;
    }

    static int[] GetNumbers(string path)
    {
        int n = 0;
        int k = 0;
        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split();
                    if (parts.Length == 2)
                    {
                        if (double.TryParse(parts[0],out double N) && double.TryParse(parts[1], out double K))
                        {
                            if (N >= int.MinValue && N <= int.MaxValue && K >= int.MinValue && K <= int.MaxValue)
                            {
                                n = (int)Math.Floor(N);
                                k = (int)Math.Floor(K);
                            }
                            else
                                throw new CustomException("Numbers must be integer type");
                            Console.WriteLine($"N: {n}");
                            Console.WriteLine($"K: {k}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid data format in the file. Data shoul be written as: 5 15");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid data format in the file. Should be two integers");
                    }
                }
            }
            
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while reading the file: {e.Message}");
        }

        return new int[] { n, k };
    }

    static void WriteAnswer(string[] numbers)
    {
        string fileName;
        bool fileExists;

        do
        {
            Console.Write("Enter the file name: ");
            fileName = Console.ReadLine();
            fileExists = File.Exists(fileName);

            if (fileExists)
            {
                Console.WriteLine("File already exists. Please choose a different name.");
            }
        } while (fileExists);

        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                doc.Open();

                string data = $"{numbers[0]} {numbers[1]}";

                Paragraph paragraph = new Paragraph(data);
                doc.Add(paragraph);

                doc.Close();

                string fullPath = Path.GetFullPath(fileName);
                Console.WriteLine($"Data has been written to {fullPath}");
            }            
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while writing the file: {e.Message}");
        }
    }

    static string FindMinNumber(int[] numbers)
    {
        int n = numbers[0];
        int k = numbers[1];

        string minNumber = "";
        bool isCompleted = false;
        int remainingBlackStripes = k;
        int numbersLeft = n;

        for (int i = 1; i <= n; i++)
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

    static string FindMaxNumber(int[] numbers)
    {
        int n = numbers[0];
        int k = numbers[1];
        string maxNumber = "";
        int remainingBlackStripes = k;
        int numbersLeft = n;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 9; j >= 0; j--)
            {
                try
                {
                    int blackStripesInDigit = CountBlackStripesInDigit(j);

                    int timeNumbersLeft = numbersLeft - 1;

                    int leftStripesInDigit = remainingBlackStripes - blackStripesInDigit;

                    if (leftStripesInDigit < timeNumbersLeft * 2)
                        throw new CustomException($"Number has too many stripes ");

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
                catch (CustomException e) 
                {
                    
                }
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