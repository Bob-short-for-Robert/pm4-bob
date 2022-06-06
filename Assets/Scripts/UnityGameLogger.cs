using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static BOB_Logger;

public class UnityGameLogger : MonoBehaviour
{
    void Awake()
    {
        Application.logMessageReceived += HandleException;
        DontDestroyOnLoad(gameObject);
    }

    void HandleException(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Exception)
        {
            Log(stackTrace);
        }
        if (type == LogType.Error)
        {
            Log(stackTrace, LogLevel.Error);
        }
        
        if (type == LogType.Warning)
        {
            Log(stackTrace);
        }
    }

}
