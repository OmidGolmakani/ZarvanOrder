using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.CustomException
{
    [Serializable]
    public class MyException : Exception
    {
        internal MyException()
        { Error = new ErrorResponse(); }
        internal MyException(int code, string message) :
            base(message)
        {
            Error.Code = code;
            Error.Description = message;
        }
        internal MyException(System.Net.HttpStatusCode status, string message) : base(message)
        {
            Error.Code = (int)status;
            Error.Description = message;
        }
        internal MyException(string message)
            : base(message)
        {
            this.Error.Code = 0;
            this.Error.Description = message;
        }

        internal MyException(string message, Exception innerException)
            : base(message, innerException)
        {
            this.Error.Code = 0;
            this.Error.Description = message;
        }
        public ErrorResponse Error { get; set; } = new ErrorResponse();
    }
}
