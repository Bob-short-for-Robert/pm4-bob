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
            
            string buildPath = Environment.GetEnvironmentVariable("BUILD_PATH");
            if (string.IsNullOrEmpty(buildPath))
                buildPath = @"C:\bob\BoB.exe";
            
            SetVersion();
            BuildReport report = BuildPipeline.BuildPlayer(GetScenes(), buildPath, BuildTarget.StandaloneWindows64,
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

        static void SetVersion()
        {
            string increment = Environment.GetEnvironmentVariable("INCREMENT");
            if (string.IsNullOrEmpty(increment))
                increment = "build";

            string buildTag = Environment.GetEnvironmentVariable("BUILD_TAG");
            if (string.IsNullOrEmpty(buildTag))
                buildTag = "gitlab_tag";

            string[] versions = PlayerSettings.bundleVersion.Split('.');

            int MajorVersion = int.Parse(versions[0]);
            int MinorVersion = int.Parse(versions[1]);
            string BuildTag = versions[2];

            if (increment == "major")
            {
                MajorVersion++;
            }
            else if (increment == "minor")
            {
                MinorVersion++;
            }
            BuildTag = buildTag;

            PlayerSettings.productName = "Book of Boilers";
            PlayerSettings.bundleVersion = MajorVersion + "." + MinorVersion + "." + BuildTag;
        }
    }
}