using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Models.Response
{
    public class UserResponse<T>
    {
        public T? Data { get; set; }
        public string Token { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}