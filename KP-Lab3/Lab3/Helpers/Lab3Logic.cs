using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


[assembly: InternalsVisibleTo("PK-Lab4.Console")]
namespace Lab3.Helpers;


public static class Lab3Logic
{
    public static void StartLab(string inputPath, string outputPath)
    {
        string filePath = inputPath;
        try
        {
            string inputText = string.Empty;

            inputText = FileManagement.GetDataFromFile(filePath);

            int result = MainLogic.Calculating(inputText);

            FileManagement.WriteAnswer(result, outputPath);

            Console.WriteLine("Result: " + result);

            Console.WriteLine("Completed");
        }
        catch (CustomException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }

    }
}
