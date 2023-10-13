using Lab3.Helpers;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter path to file: (OR enter if want to use default files)");
            string filePath = Console.ReadLine();
            string inputText = string.Empty;
            
            inputText = FileManagement.GetDataFromFile(filePath);
                      

            int result = MainLogic.Calculating(inputText);

            
            FileManagement.WriteAnswer(result);

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