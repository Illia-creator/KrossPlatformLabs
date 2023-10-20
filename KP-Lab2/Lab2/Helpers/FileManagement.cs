using System.Reflection;

namespace Lab2.Helpers;

public static class FileManagement
{
    public static string GetDataFromFile(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string desiredPath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(assemblyLocation))), "Lab2", "Files", "INPUT2.txt");
            path = desiredPath.Replace("\\bin\\Lab2", "");
        }
        if (!File.Exists(path))
            throw new CustomException("File not found");

        string fileContents = File.ReadAllText(path);
        string modifiedContents = fileContents.Replace(Environment.NewLine, " ");

        return modifiedContents;
    }

    public static void WriteAnswer(int[] numbers, string path)
    {
        string fileName;
        bool fileExists;

        if (!string.IsNullOrEmpty(path))
        {
            fileName = path;
        }
        else
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string desiredPath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(assemblyLocation))), "Lab2", "Files", "OUTPUT2.txt");
            fileName = desiredPath.Replace("\\bin\\Lab2", "");
        }

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
