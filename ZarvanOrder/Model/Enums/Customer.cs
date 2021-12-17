using System.ComponentModel.DataAnnotations;

namespace ZarvanOrder.Model.Enums
{
    internal class Customer
    {
        internal enum CustomerType : byte
        {
            [Display(Name ="حقیقی")]
            Person = 1,
            [Display(Name = "حقوقی")]
            Company = 2
        }
    }
}
