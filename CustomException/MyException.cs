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
        { }

        internal MyException(string message)
            : base(message)
        { }

        internal MyException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
