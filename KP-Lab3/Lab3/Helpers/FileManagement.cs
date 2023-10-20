using System.Reflection;

namespace Lab3.Helpers;

public static class FileManagement
{
    public static string GetDataFromFile(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string desiredPath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(assemblyLocation))), "Lab3", "Files", "INPUT3.txt");
            path = desiredPath.Replace("\\bin\\Lab3", "");
        }

        if (!File.Exists(path))
            throw new CustomException("File not found");

        string fileContents = File.ReadAllText(path);
        string modifiedContents = fileContents.Replace(Environment.NewLine, " ");

        return modifiedContents;
    }

    public static void WriteAnswer(int numberOf, string path)
    {
        string fileName;
        bool fileExists;

        if (!string.IsNullOrEmpty(path))
            fileName = path;
        else
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string desiredPath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(assemblyLocation))), "Lab3", "Helpers", "Files", "OUTPUT3.txt");
            fileName = desiredPath.Replace("\\bin\\Lab3", "");
        }
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {

                string data = numberOf.ToString();
                writer.WriteLine(data);
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
