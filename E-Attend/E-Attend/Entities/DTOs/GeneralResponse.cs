using E_Attend.Entities.Models;

namespace E_Attend.Entities.DTOs;

public class GeneralResponse<T>
{
    public bool State { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }


    public GeneralResponse(bool state, string message, T data)
    {
        State = state;
        Message = message;
        Data = data;
    }


    public static GeneralResponse<T> Success(T data, string message = "Operation successful") =>
        new(true, message, data);


    public static GeneralResponse<T> Error(string message = "Operation failed") =>
        new(false, message, default); // default(T) is also acceptable
}