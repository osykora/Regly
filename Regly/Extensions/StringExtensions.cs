namespace Regly.Extensions
{
    public static class StringExtensions
    {
        public static string FillBy(this string template, params object[] values)
        {
            return string.Format(template, values);
        }

        public static bool HasValue(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }
    }
}
