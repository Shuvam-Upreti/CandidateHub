using CandidateHub.Core.Enums;
using CandidateHub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CandidateHub.Extension;

public class ApiResponseExtensions : IActionResult
{
    private readonly APIResponse _response;

    public ApiResponseExtensions(APIResponse response)
    {
        _response = response;
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var objectResult = new ObjectResult(_response)
        {
            StatusCode = _response.StatusCode
        };
        await objectResult.ExecuteResultAsync(context);
    }
}



public static class ControllerExtensions
{


    public static IActionResult ApiErrorResponse(this ControllerBase controller, HttpStatusCode code, List<string> errors, string status, string message = "Error")
    {
        var response = new APIResponse
        {
            StatusCode = (int)code,
            Message = message,
            Errors = errors,
            Status = status
        };

        return new ApiResponseExtensions(response);
    }


    public static IActionResult ApiSuccessResponse(this ControllerBase controller, HttpStatusCode statusCode, string message = "Success", object data = null)
    {
        if (statusCode == HttpStatusCode.NoContent)
        {
            return new StatusCodeResult((int)statusCode);
        }

        var response = new APIResponse
        {
            StatusCode = (int)statusCode,
            Data = data,
            Message = message,
            Status = NotifyEnum.Success.ToString()
        };

        return new ApiResponseExtensions(response);
    }
}