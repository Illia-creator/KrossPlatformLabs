namespace Lab2.Helpers;

public class CustomException : Exception
{
    public string Message { get; set; } = string.Empty;

    public CustomException(string message)
       => Message = message;
}
