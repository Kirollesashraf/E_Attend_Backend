namespace E_Attend.Service.Common;

public class GeneralResponse<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }

    public GeneralResponse(bool success, string? message = null, T? data = default)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public static GeneralResponse<T> SuccessResponse(T? data = default, string? message = null)
    {
        return new GeneralResponse<T>(true, message, data);
    }

    public static GeneralResponse<T> FailureResponse(string message)
    {
        return new GeneralResponse<T>(false, message);
    }
}