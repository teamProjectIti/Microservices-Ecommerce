using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Dto.Common
{
    public static class ExtensionMethods
    {
        public static string ToJsonNS(this object obj, bool handleRefLoop = true)
        {
            return Helpers.ToJsonNS(obj, handleRefLoop);
        }

        public static T FromJsonNS<T>(this string json) => JsonConvert.DeserializeObject<T>(json);

        public static string ToSpacedString(this object obj)
        {
            if (!Regex.IsMatch(obj.ToString(), "(?<=[a-z])([A-Z])"))
                return obj.ToString();

            return Regex.Replace(obj.ToString(), "(?<=[a-z])([A-Z])", " $1", RegexOptions.Compiled).Replace("_", " ");
        }
        public static bool IsNullOrEmptyWithTrim(this string str)
        {

            if (str == null || str.Trim() == "")
                return true;
            return false;

        }
        public static bool IsNullOrWhiteSpace(this string str)
        {
            try
            {
                var t = string.IsNullOrWhiteSpace(str);
                if (t == true)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static DateTime ToUtc(this DateTime datetime)
        {
            try
            {
                datetime = datetime.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(datetime, DateTimeKind.Utc) : datetime;
                return datetime.Kind != DateTimeKind.Utc ? datetime.ToUniversalTime() : datetime;

            }
            catch (Exception ex)
            {
                return datetime;
            }

        }

    }
}
