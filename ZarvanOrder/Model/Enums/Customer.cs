using System.ComponentModel.DataAnnotations;

namespace ZarvanOrder.Model.Enums
{
    public class Customer
    {
        public enum CustomerType : byte
        {
            [Display(Name ="حقیقی")]
            Person = 1,
            [Display(Name = "حقوقی")]
            Company = 2
        }
    }
}
