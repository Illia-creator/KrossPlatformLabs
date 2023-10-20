using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Helpers;

public static class Lab2Logic
{
    public static void StartLab(string inputPath, string outputPath)
    {
        string filePath = inputPath;

        try
        {
            string fileContent = FileManagement.GetDataFromFile(filePath);

            if (string.IsNullOrEmpty(fileContent))
                throw new CustomException("File Is Empty");

            var incomeData = MainLogic.GetIncomeData(fileContent);
            MainLogic.NumbersCheck(incomeData);

            var createdArray = MainLogic.CreateMainArray(incomeData);

            var result = MainLogic.DeletedSeconds(incomeData, createdArray);

            FileManagement.WriteAnswer(result, outputPath);

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
