using iTextSharp.text;
using iTextSharp.text.pdf;
using KP_Lab2.Exceptions;

namespace KP_Lab2.Helpers;

public static class FileHelper
{
    public static string GetDataFromFile(string path)
    {

        if (!File.Exists(path))
            throw new CustomException("File not found");

        string fileContents = File.ReadAllText(path);

        string modifiedContents = fileContents.Replace(Environment.NewLine, " ");

        return modifiedContents;
    }

    public static void WriteAnswer(int[] numbers)
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
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (int number in numbers)
                {
                    string data = number.ToString();
                    writer.WriteLine(data);
                }
            }

            string fullPath = Path.GetFullPath(fileName);
            Console.WriteLine($"Data has been written to {fullPath}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while writing the file: {e.Message}");
        }
    }
}
