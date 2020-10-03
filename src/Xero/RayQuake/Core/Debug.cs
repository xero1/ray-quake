using System;
using System.Collections.Generic;
using System.Text;

namespace Xero.RayQuake.Core
{
    public static class Debug
    {
        public static void LogMethod(params string[] names)
        {
            var sb = new StringBuilder();

            foreach (var n in names)
                sb.Append($"{n}.");

            Console.WriteLine(sb.ToString().TrimEnd('.') + "()");
        }
    }
}
