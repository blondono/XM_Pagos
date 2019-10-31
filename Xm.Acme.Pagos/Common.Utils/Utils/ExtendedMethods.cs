using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Utils
{
    public static class ExtendedMethods
    {
        /// <summary>
        /// return nullable date with format yyyy-MM-dd
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStringDateFormatted(this DateTime? date)
        {
            return Convert.ToDateTime(date).ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// return date with format yyyy-MM-dd
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStringDateFormatted(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// return date with format yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStringDateTimeFormatted(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
