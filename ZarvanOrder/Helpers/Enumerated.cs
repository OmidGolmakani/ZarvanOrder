using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Helpers
{
    internal static class Enumerated
    {
        internal static List<(byte, string, string)> GetDisplayNames<TEnum>(TEnum @enum) where TEnum : Enum
        {
            if (@enum is not Enum) return null;
            List<(byte, string, string)> lstResult = new List<(byte, string, string)>();
            foreach (var item in Enum.GetValues(@enum.GetType()))
            {
                lstResult.Add(((byte)item, item.ToString(), GetDisplay<TEnum>(@enum)));
            }
            return lstResult;
        }
        private static string GetDisplay<TEnum>(TEnum @enum) where TEnum : Enum
        {
            if (@enum is not Enum) return string.Empty;
            return @enum?.GetType().
                          GetMember(@enum.ToString()).
                          FirstOrDefault()?.
                          GetCustomAttribute<DisplayAttribute>().Name;
        }
        internal static string FindById<TEnum>(List<(byte, string, string)> lst, TEnum @enum) where TEnum : Enum
        {
            if (lst?.Count() == 0) return "";
            return lst.FirstOrDefault(p => p.Item1 == (byte)(object)@enum).Item2;
        }
        internal static string FindByName<TEnum>(List<(byte, string, string)> lst, TEnum @enum) where TEnum : Enum
        {
            if (lst?.Count() == 0) return "";
            return lst.FirstOrDefault(p => p.Item2 == @enum.ToString()).Item2;
        }
        internal static string FindById<TEnum>(TEnum @enum) where TEnum : Enum
        {
            List<(byte, string, string)> lst = GetDisplayNames<TEnum>(@enum);
            if (lst?.Count() == 0) return "";
            return lst.FirstOrDefault(p => p.Item1 == (byte)(object)@enum).Item2;
        }
        internal static string FindByName<TEnum>(TEnum @enum) where TEnum : Enum
        {
            List<(byte, string, string)> lst = GetDisplayNames<TEnum>(@enum);
            if (lst?.Count() == 0) return "";
            return lst.FirstOrDefault(p => p.Item2 == @enum.ToString()).Item2;
        }
        internal static string Find(Type @enum, byte Id)
        {
            return Enum.GetName(@enum, Id)?.Trim() ?? "";
        }
    }
}
