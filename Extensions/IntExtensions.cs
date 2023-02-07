using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_User_Management.Extensions
{
    public static class IntExtensions
    {
        public static int FromString(this string source, int defaultValue = 0)
        {
            if (string.IsNullOrEmpty(source)) return defaultValue;
            int v;
            if (int.TryParse(source, out v))
                return v;
            return defaultValue;
        }
    }
}
