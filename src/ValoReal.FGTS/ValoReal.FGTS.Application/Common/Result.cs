using System;
using System.Net;

namespace ValoReal.FGTS.Application.Common;

public class Result<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public static Result<T> Ok(T data) => new() { Success = true, Data = data, StatusCode = HttpStatusCode.OK };
    public static Result<T> Fail(string message) => new() { Success = false, Message = message };
    public static Result<T> NotFound(string message) => new() { Success = false, Message = message, StatusCode = HttpStatusCode.NotFound };
    public static Result<T> Created(T data) => new() { Success = true, Data = data, StatusCode = HttpStatusCode.Created };
}
