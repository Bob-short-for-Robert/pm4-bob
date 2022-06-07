using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.PackageManager;
using UnityEngine;

public class BOB_Logger
{
    private static StreamWriter sw = new StreamWriter("./LOG.csv", true);

    internal static void Log(string[] s)
    {
        Log(s, LogLevel.Warn);
    }

    internal static void Log(string s)
    {
        Log(s, LogLevel.Warn);
    }

    internal static void Log(string[] s, LogLevel level)
    {
        foreach (var msg in s)
        {
            Log(msg, level);
        }
    }

    internal static void Log(string s, LogLevel level)
    {
        String msg = String.Format("{0};{1};{2}", DateTime.Now.ToString(), level.ToString(), s);
        sw.WriteLine(msg);
        Console.WriteLine(msg);
    }
}
