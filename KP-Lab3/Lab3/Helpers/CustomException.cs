namespace Lab3.Helpers;

public class CustomException : Exception
{
    public string Message { get; set; } = string.Empty;

    public CustomException(string message)
       => Message = message;
}
