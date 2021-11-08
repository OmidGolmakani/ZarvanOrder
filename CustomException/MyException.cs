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
        { Error = new Error(); }
        internal MyException(int code, string message) :
            base(message)
        {
            Error.Code = code;
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
        public Error Error { get; set; } = new Error();
    }
}
