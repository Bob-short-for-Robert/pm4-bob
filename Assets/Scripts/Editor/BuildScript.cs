using System;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Editor
{
    public class BuildScript
    {
        static void Windows()
        {
            string filepath = @"E:\Projects\bob\test_builder\build.exe";
            updateVersion();
            BuildReport report = BuildPipeline.BuildPlayer(GetScenes(), filepath, BuildTarget.StandaloneWindows64,
                BuildOptions.None);
            BuildSummary summary = report.summary;


            if (summary.result == BuildResult.Succeeded)
            {
                Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            }

            if (summary.result == BuildResult.Failed)
            {
                Debug.Log("Build failed");
            }
        }

        static string[] GetScenes()
        {
            return EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();
        }

        static void updateVersion()
        {
            string _versionNumber = Environment.GetEnvironmentVariable("VERSION_NUMBER");
            if (string.IsNullOrEmpty(_versionNumber))
                _versionNumber = "1.0.0.0";

            string _buildNumber = Environment.GetEnvironmentVariable("BUILD_NUMBER");
            if (string.IsNullOrEmpty(_buildNumber))
                _buildNumber = "1";

            PlayerSettings.productName = "Book of Boilers";
            PlayerSettings.bundleVersion = _versionNumber +"." + _buildNumber;
        }
    }
}