using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using APLICATION.Wrappers;
using DOMAIN.ENTITIES;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace API.Middleware
{
  public class ErrorHandlerMiddlerware
  {
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;



    public ErrorHandlerMiddlerware(RequestDelegate next,ILogger<Log> logger)
    {
      _next = next;
      _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception error)
      {
        var response = context.Response;
        response.ContentType = "application/json";
        //  var responseModel = new CustomErrorResponse() { Message = error?.Message};  
        var errorResponse = new ApiResponse();
        errorResponse.status = new Status();
        errorResponse.status.error_message = error?.Message;

        switch (error)
        {           
          
          case ValidationException e:
            // custom application error
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            
            //responseModel.Errors = e;
            break;
          case KeyNotFoundException e:
            // not found error
            response.StatusCode = (int)HttpStatusCode.NotFound;
            
            break;
          default:
            // unhandled error
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            _logger.LogError(error, error?.Message);
            break;
        }
       
        errorResponse.status.error_code= response.StatusCode;
        var result = JsonSerializer.Serialize(errorResponse);

        await response.WriteAsync(result);
      }
    }
  }
}
