using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Models.ViewModel.Commons
{
    public class APIResponse<T> where T : class
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public APIResponse()
        {
            Errors = new List<string>();
        }

        // Convenience method for creating a successful response
        public static APIResponse<T> SuccessResponse(T data, string message = "")
        {
            return new APIResponse<T> { Success = true, Data = data, Message = message };
        }

        // Convenience method for creating a failed response
        public static APIResponse<T> ErrorResponse(List<string> errors, string message = "")
        {
            return new APIResponse<T> { Success = false, Errors = errors, Message = message };
        }
    }
}
