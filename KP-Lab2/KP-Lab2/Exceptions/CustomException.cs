namespace KP_Lab2.Exceptions;

public class CustomException : Exception
{
    public string Message { get; set; } = string.Empty;

    public CustomException(string message)
       => Message = message;
}
