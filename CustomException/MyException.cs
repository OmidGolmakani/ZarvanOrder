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

        internal MyException(string message)
            : base(message)
        { Error = new Error(); }
        internal MyException(int Code, string message)
        {
            this.Error = new Error()
            {
                Code = Code,
                Description = message
            };
        }

        internal MyException(string message, Exception innerException)
            : base(message, innerException)
        { }
        public Error Error { get; set; }
    }
}
