using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Helpers;

namespace ZarvanOrder.Extensions.Other
{
    internal static class Extention
    {
        /// <summary>
        /// رشته میگیرد و Int برمیگرداند
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static int ToInt(this string x)
        {
            try
            {
                if (x.Length == 0)
                {
                    return 0;
                }
                int Ret = 0;
                int.TryParse(x, out Ret);
                return Ret;
            }
            catch (Exception ex)
            {
                throw new Exception("ToInt", ex);
            }
        }
        /// <summary>
        /// تبدیل Deciaml به int
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static int ToInt(this decimal x)
        {
            try
            {
                if (x == 0)
                {
                    return 0;
                }
                int Ret = 0;
                int.TryParse(x.ToString(), out Ret);
                return Ret;
            }
            catch (Exception ex)
            {
                throw new Exception("ToInt", ex);
            }
        }
        internal static long ToLong(this decimal x)
        {
            try
            {
                if (x == 0)
                {
                    return 0;
                }
                long Ret = 0;
                long.TryParse(x.ToString(), out Ret);
                return Ret;
            }
            catch (Exception ex)
            {
                throw new Exception("ToLong", ex);
            }
        }
        internal static Guid ToGuid(this string x)
        {
            try
            {
                if (x.Length == 0)
                {
                    return new Guid();
                }
                Guid Ret = new Guid();
                Guid.TryParse(x, out Ret);
                return Ret;
            }
            catch (Exception ex)
            {
                throw new Exception("ToLong", ex);
            }
        }

        /// <summary>
        /// رشته میگیرد و Long برمیگرداند
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static long ToLong(this string x)
        {
            try
            {
                if (x.Length == 0)
                {
                    return 0;
                }
                long Ret = 0;
                long.TryParse(x, out Ret);
                return Ret;
            }
            catch (Exception ex)
            {
                throw new Exception("ToLong", ex);
            }
        }
        /// <summary>
        /// رشته میگیرد و Byte برمیگرداند
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static byte ToByte(this string x)
        {
            try
            {
                if (x.Length == 0)
                {
                    return 0;
                }
                byte Ret = 0;
                byte.TryParse(x, out Ret);
                return Ret;
            }
            catch (Exception ex)
            {
                throw new Exception("ToByte", ex);
            }
        }
        /// <summary>
        /// رشته میگیرد و Double برمیگرداند
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static double ToDouble(this string x)
        {
            try
            {
                if (x.Length == 0)
                {
                    return 0;
                }
                double Ret = 0;
                double.TryParse(x, out Ret);
                return Ret;
            }
            catch (Exception ex)
            {
                throw new Exception("ToDouble", ex);
            }
        }
        /// <summary>
        /// رشته میگیرد و DateTime برمیگرداند
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static DateTime ToDateTime(this string x)
        {
            try
            {
                if (x.Length == 0)
                {
                    return DateTime.Now;
                }
                DateTime ret = DateTime.Now;
                DateTime.TryParse(x, out ret);
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("ToDateTime", ex);
            }
        }

        /// <summary>
        /// رشته میگیرد و Int برمیگرداند
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static int ToInt(this object x)
        {
            try
            {
                if (x == null) return 0;
                if (x.ToString().Length == 0)
                {
                    return 0;
                }
                int Ret = 0;
                int.TryParse(x.ToString(), out Ret);
                return Ret;
            }
            catch (Exception ex)
            {
                throw new Exception("ToInt", ex);
            }
        }
        /// <summary>
        /// Object میگیرد و Decimal برمیگرداند
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static decimal ToDecimal(this object x)
        {
            try
            {
                if (x == null) return 0;
                if (x.ToString().Length == 0)
                {
                    return 0;
                }
                decimal Ret = 0;
                decimal.TryParse(x.ToString(), out Ret);
                return Ret;
            }
            catch (Exception ex)
            {
                throw new Exception("ToDecimal", ex);
            }
        }
        /// <summary>
        /// رشته میگیرد و Long برمیگرداند
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static long ToLong(this object x)
        {
            try
            {
                if (x == null) return 0;
                if (x.ToString().Length == 0)
                {
                    return 0;
                }
                long Ret = 0;
                long.TryParse(x.ToString(), out Ret);
                return Ret;
            }
            catch (Exception ex)
            {
                throw new Exception("ToLong", ex);
            }
        }
        /// <summary>
        /// رشته میگیرد و Byte برمیگرداند
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static byte ToByte(this object x)
        {
            try
            {
                if (x == null) return 0;
                if (x.ToString().Length == 0)
                {
                    return 0;
                }
                byte Ret = 0;
                byte.TryParse(x.ToString(), out Ret);
                return Ret;
            }
            catch (Exception ex)
            {
                throw new Exception("ToByte", ex);
            }
        }
        /// <summary>
        /// رشته میگیرد و Double برمیگرداند
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static double ToDouble(this object x)
        {
            try
            {
                if (x == null) return 0;
                if (x.ToString().Length == 0)
                {
                    return 0;
                }
                double Ret = 0;
                double.TryParse(x.ToString(), out Ret);
                return Ret;
            }
            catch (Exception ex)
            {
                throw new Exception("ToDouble", ex);
            }
        }
        /// <summary>
        /// رشته میگیرد و DateTime برمیگرداند
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static DateTime ToDateTime(this object x)
        {
            try
            {
                if (x == null) return new DateTime();
                if (x.ToString().Length == 0)
                {
                    return DateTime.Now;
                }
                DateTime ret = DateTime.Now;
                DateTime.TryParse(x.ToString(), out ret);
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("ToDateTime", ex);
            }
        }
        /// <summary>
        /// درست بودن یا نبودن تاریخ شمسی را برمیگرداند
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static bool DateIsValid(this string x)
        {
            try
            {
                if (string.IsNullOrEmpty(x))
                {
                    return false;
                }
                return PersionDate.IsShamsi(x);
            }
            catch (Exception ex)
            {
                throw new Exception("DateIsValid", ex);
            }
        }
        /// <summary>
        /// تبدیل رشته به تاریخ میلادی
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static DateTime ToMiladi(this string x)
        {
            try
            {
                return PersionDate.GetMiladi(x).Value;
            }
            catch (Exception ex)
            {
                throw new Exception("ToMiladi", ex);
            }
        }
        /// <summary>
        /// تبدیل رشته به شمسی
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static string ToShamsi(this string x)
        {
            try
            {
                return PersionDate.GetShamsi(x.ToDateTime());
            }
            catch (Exception ex)
            {

                throw new Exception("ToShamsi", ex);
            }
        }
        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static string ToShamsi(this DateTime x, bool withTime)
        {
            try
            {
                return PersionDate.GetShamsi(x, withTime);
            }
            catch (Exception ex)
            {

                throw new Exception("ToShamsi", ex);
            }
        }
        /// <summary>
        /// تبدیل رشته به Boolean
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static bool ToBoolean(this string x)
        {
            bool ret = false;

            if (bool.TryParse(x, out ret) == false)
            {
                throw new Exception("سیستم قادر به تبدیل داده مورد نظر نمی باشد");
            }
            else
            {
                return ret;
            }
        }
        internal static bool ToBoolean(this int x)
        {
            return true ? x == 1 : false;
        }
        internal static bool ToBoolean(this byte x)
        {
            return true ? x == 1 : false;
        }
        internal static bool ToBoolean(this long x)
        {
            return true ? x == 1 : false;
        }
        /// <summary>
        /// چک کردن رشته قابل تبدیل به عدد
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static bool IsNumeric(this string x)
        {
            try
            {
                if (x.Length == 0)
                {
                    return false;
                }
                long Ret = 0;
                return long.TryParse(x.ToString(), out Ret);
            }
            catch (Exception ex)
            {

                throw new Exception("IsNumeric", ex);
            }
        }
        /// <summary>
        /// چک کردن شی قابل تبدیل به عدد
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static bool IsNumeric(this object x)
        {
            try
            {
                if (x == null) return false;
                if (x.ToString().Length == 0)
                {
                    return false;
                }
                long Ret = 0;
                return long.TryParse(x.ToString(), out Ret);
            }
            catch (Exception ex)
            {
                throw new Exception("IsNumeric", ex);
            }
        }
        internal static decimal ToDcimal(this string x)
        {
            try
            {
                if (x.Length == 0)
                {
                    return 0;
                }
                decimal Ret = 0;
                decimal.TryParse(x, out Ret);
                return Ret;
            }
            catch (Exception ex)
            {

                throw new Exception("ToDcimal", ex);
            }
        }
        /// <summary>
        /// یک مقدار Boolean را به فعال یا غیر فعال تبدیل میکند
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static string ConvertBooleanToString(this bool x)
        {
            try
            {
                return x == true ? "فعال" : "غیر فعال";
            }
            catch (Exception ex)
            {

                throw new Exception("ConvertBooleanToString", ex);
            }
        }
        /// <summary>
        /// یک مقدار Boolean را به فعال یا غیر فعال تبدیل میکند
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal static string ConvertBooleanToString(this Nullable<bool> x)
        {
            try
            {
                return x == true ? "فعال" : "غیر فعال";
            }
            catch (Exception ex)
            {

                throw new Exception("ConvertBooleanToString", ex);
            }
        }
        internal static string ListToString<T>(this List<T> x)
        {
            try
            {
                return string.Join("<br/>", x);
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal static string JsonConvert<T>(this List<T> List)
        {
            if (List.Count == 0) return null;
            return Newtonsoft.Json.JsonConvert.SerializeObject(List);
        }
        internal static ZarvanOrder.CustomException.MyException ToJson(this List<FluentValidation.Results.ValidationFailure> x)
        {
            var Result = Newtonsoft.Json.JsonConvert.SerializeObject((from e in x
                                                                      select new ZarvanOrder.CustomException.ErrorResponse()
                                                                      {
                                                                          Code = e.ErrorCode.ToInt(),
                                                                          Description = e.ErrorMessage
                                                                      }).ToList());
            return new CustomException.MyException(Result);
        }
        internal static ZarvanOrder.CustomException.MyException ToJson(this CustomException.MyException exception, CustomException.ErrorResponse error)
        {
            return new CustomException.MyException(Newtonsoft.Json.JsonConvert.SerializeObject(error));
        }
    }
}

