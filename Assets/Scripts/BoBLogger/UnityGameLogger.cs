using System;
using UnityEngine;
using static BoBLogger.Logger;

namespace BoBLogger
{
    internal class UnityGameLogger : MonoBehaviour
    {
        private void Awake()
        {
            Application.logMessageReceived += HandleException;
            DontDestroyOnLoad(gameObject);
        }

        private static void HandleException(string logString, string stackTrace, LogType type)
        {
            switch (type)
            {
                case LogType.Exception:
                    Log(stackTrace);
                    break;
                case LogType.Error:
                    Log(stackTrace, LogType.Error);
                    break;
                case LogType.Warning:
                    Log(stackTrace);
                    break;
                case LogType.Assert:
                    //dont log tests into LogFile
                    break;
                case LogType.Log:
                    Log(stackTrace, LogType.Log);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
