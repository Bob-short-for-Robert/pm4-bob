using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

namespace BoBLogger
{
    public static class Logger
    {
        private static readonly StreamWriter SW = new StreamWriter("./LOG.csv", true);

        internal static void Log(IEnumerable<string> s)
        {
            Log(s, LogType.Warning);
        }

        internal static void Log(string s)
        {
            Log(s, LogType.Warning);
        }

        internal static void Log(IEnumerable<string> s, LogType level)
        {
            foreach (var msg in s)
            {
                Log(msg, level);
            }
        }

        internal static void Log(string s, LogType level)
        {
            // ReSharper disable once HeapView.BoxingAllocation
            var msg = $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)};{level.ToString()};{s}";
            SW.WriteLine(msg);
            Console.WriteLine(msg);
        }
    }
}
