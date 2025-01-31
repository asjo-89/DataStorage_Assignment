namespace Business.Errors;

public class ErrorResult : Result
{
    public ErrorResult(int statusCode, string message)
    {
        Success = false;
        StatusCode = statusCode;
        ErrorMessage = message;
    }
}
