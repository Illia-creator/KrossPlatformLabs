using KP_Lab2.Calculating;
using KP_Lab2.Exceptions;
using KP_Lab2.Helpers;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter path to file: ");
        string filePath = Console.ReadLine();

        try
        {
            string fileContent = FileHelper.GetDataFromFile(filePath);

            if (string.IsNullOrEmpty(fileContent))
                throw new CustomException("File Is Empty");

            var incomeData = MainLogic.GetIncomeData(fileContent);
            MainLogic.NumbersCheck(incomeData);

            var createdArray = MainLogic.CreateMainArray(incomeData);

            var result = MainLogic.DeletedSeconds(incomeData, createdArray);

            FileHelper.WriteAnswer(result);

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