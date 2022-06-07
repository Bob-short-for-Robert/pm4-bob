using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEditor.PackageManager;

namespace BoBLogger
{
    public static class Logger
    {
        private static readonly StreamWriter SW = new StreamWriter("./LOG.csv", true);

        internal static void Log(IEnumerable<string> s)
        {
            Log(s, LogLevel.Warn);
        }

        internal static void Log(string s)
        {
            Log(s, LogLevel.Warn);
        }

        internal static void Log(IEnumerable<string> s, LogLevel level)
        {
            foreach (var msg in s)
            {
                Log(msg, level);
            }
        }

        internal static void Log(string s, LogLevel level)
        {
            // ReSharper disable once HeapView.BoxingAllocation
            var msg = $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)};{level.ToString()};{s}";
            SW.WriteLine(msg);
            Console.WriteLine(msg);
        }
    }
}
