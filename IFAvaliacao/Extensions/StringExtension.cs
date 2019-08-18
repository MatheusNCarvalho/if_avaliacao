namespace IFAvaliacao.Extensions
{
    public static class StringExtension
    {
        public static bool HasValue(this string value) =>
            !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);
    }
}