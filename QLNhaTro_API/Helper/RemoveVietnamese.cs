using System;
using System.Text;
using System.Text.RegularExpressions;

namespace QLNhaTro_API.Helper
{
    public class RemoveVietnamese
    {
        public static string convertToSlug(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            temp = temp.Replace(" ", "-");
            temp = temp.Replace("--", "-");
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}