using NJsonSchema.Annotations;
using System;
using System.IO;
using System.Xml.Serialization;

namespace DadtApi.CommonUtility
{
    public static class StringExtensions
    {
        [CanBeNull]
        public static string FirstCharToLowerCase([CanBeNull] this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;

            return char.ToLower(str[0]) + str.Substring(1);
        }

        [CanBeNull]
        public static string ConvertDateFormattedString([CanBeNull] this string strdate)
        {
            if (!string.IsNullOrEmpty(strdate))
            {
                var onlyDate = strdate.Split(" ");
                var date = onlyDate[0].Split(@"/");
                var newlyformeddate = date[2] + "-" + (date[0].Length == 1 ? "0" + date[0] : date[0]) + "-" + (date[1].Length == 1 ? "0" + date[1] : date[1]);
                return newlyformeddate;
            }

            return strdate;
        }

        [CanBeNull]
        public static string ConvertDateFormattedString([CanBeNull] this DateTime dt)
        {
            string strdate= string.Empty;
            if (dt != null)
            {
                string yr = dt.Year.ToString();
                string mm = dt.Month.ToString();
                string dd = dt.Day.ToString();
                var newlyformeddate = yr + "-" + (mm.Length == 1 ? "0" + mm : mm) + "-" + (dd.Length == 1 ? "0" + dd : dd);
                return newlyformeddate;
            }

            return strdate;
        }

        [CanBeNull]
        public static string ConvertDateTimeFormattedString([CanBeNull] this DateTime dt)
        {
            string strdate = string.Empty;
            if (dt != null)
            {
                strdate = dt.ToString("MM/dd/yyyy hh:mm tt");
            }

            return strdate;
        }

        [CanBeNull]
        public static string ObjectToXml([CanBeNull] this object dataToSerialize)
        {
            if (dataToSerialize == null) return null;

            using (StringWriter stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(dataToSerialize.GetType());
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
        }

        [CanBeNull]
        public static T XmltoObject<T>([CanBeNull] this string xmlText)
        {
            if (String.IsNullOrWhiteSpace(xmlText)) return default(T);

            using (StringReader stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
        }
    }
}
