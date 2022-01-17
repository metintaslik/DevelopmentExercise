using DevelopmentExercise.API.Core.Abstracts;
using DevelopmentExercise.API.Models;
using System.Net;
using System.Text.Json;

namespace DevelopmentExercise.API
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<Middleware> _logger;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public Middleware(RequestDelegate next, ILogger<Middleware> logger, IUnitOfWorkRepository unitOfWorkRepository)
        {
            _next = next;
            _logger = logger;
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await _unitOfWorkRepository.RollbackAsync().ConfigureAwait(false);
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;

            var errorResponse = new ResponseModel<Middleware>
            {
                IsError = true,
                ErrorCode = -1,
                ErrorDetail = ErrorType.AnUnexpectedErrorOccurred.ToString(),
            };
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            _logger.LogError(exception.Message);
            var result = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(result);
        }
    }
}
