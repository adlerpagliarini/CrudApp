using System.Text.RegularExpressions;

namespace Crud.App.Application.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex _regexApenasNumeros = new Regex(@"[^\d]");

        public static string ApenasNumeros(this string str) 
            => string.IsNullOrEmpty(str) ? "" : _regexApenasNumeros.Replace(str, "");
    }
}
