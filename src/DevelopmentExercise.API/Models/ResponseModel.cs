using System.ComponentModel.DataAnnotations;

namespace DevelopmentExercise.API.Models
{
    public class ResponseModel<T> where T : class
    {
        public ResponseModel(bool isError = false, int? errorCode = null, string? errorDetail = null, T? model = null)
        {
            IsError = isError;
            ErrorCode = errorCode;
            ErrorDetail = errorDetail;
            Model = model;
        }

        public bool IsError { get; set; }

        public int? ErrorCode { get; set; }

        public string? ErrorDetail { get; set; }

        public T? Model { get; set; }
    }


    public enum ErrorType
    {
        [Display(Name = "AnUnexpectedErrorOccurred")]
        AnUnexpectedErrorOccurred = -1,
        [Display(Name = "OrderNotFound")]
        OrderNotFound = 1000,
        [Display(Name = "UserNotFound")]
        UserNotFound = 1001,
        [Display(Name = "InvoiceAlreadyCreated")]
        InvoiceAlreadyCreated = 1002,
    }
}