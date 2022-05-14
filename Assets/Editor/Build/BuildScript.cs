using System;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace Editor
{
    public class BuildScript
    {
        private static readonly string Eol = Environment.NewLine;
        private static readonly string[] Secrets =
            {"androidKeystorePass", "androidKeyaliasName", "androidKeyaliasPass"};
        public static void Builder()
        {
            Dictionary<string, string> options = GetValidatedOptions();

            string increment = options["increment"];
            if (string.IsNullOrEmpty(increment))
                increment = "build";

            string buildTag = options["buildTag"];
            if (string.IsNullOrEmpty(buildTag))
                buildTag = "gitlab_tag";
            
            string buildPath = options["customBuildPath"];
            if (string.IsNullOrEmpty(buildPath))
                buildPath = @"C:\bob\BoB.exe";
            
            
            var buildTarget = (BuildTarget) Enum.Parse(typeof(BuildTarget), options["buildTarget"]);
            
            SetVersion(increment, buildTag);
            BuildReport report = BuildPipeline.BuildPlayer(GetScenes(), buildPath, buildTarget,
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

        private static string[] GetScenes()
        {
            return EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();
        }

        private static void SetVersion(string increment, string buildTag)
        {
            

            Console.WriteLine(
                $"{Eol}" +
                $"###########################{Eol}" +
                $"#       Set Version       #{Eol}" +
                $"###########################{Eol}" +
                $"{Eol}"
            );
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
            
            Console.WriteLine(
                $"{Eol}" +
                $"bundleversion -> {PlayerSettings.bundleVersion}" +
                $"{Eol}"
            );
        }
        

        private static Dictionary<string, string> GetValidatedOptions()
        {
            ParseCommandLineArguments(out Dictionary<string, string> validatedOptions);

            if (!validatedOptions.TryGetValue("projectPath", out string _))
            {
                Console.WriteLine("Missing argument -projectPath");
                EditorApplication.Exit(110);
            }

            if (!validatedOptions.TryGetValue("buildTarget", out string buildTarget))
            {
                Console.WriteLine("Missing argument -buildTarget");
                EditorApplication.Exit(120);
            }

            if (!Enum.IsDefined(typeof(BuildTarget), buildTarget ?? string.Empty))
            {
                EditorApplication.Exit(121);
            }

            if (!validatedOptions.TryGetValue("customBuildPath", out string _))
            {
                Console.WriteLine("Missing argument -customBuildPath");
                EditorApplication.Exit(130);
            }

            const string defaultCustomBuildName = "TestBuild";
            if (!validatedOptions.TryGetValue("customBuildName", out string customBuildName))
            {
                Console.WriteLine($"Missing argument -customBuildName, defaulting to {defaultCustomBuildName}.");
                validatedOptions.Add("customBuildName", defaultCustomBuildName);
            }
            else if (customBuildName == "")
            {
                Console.WriteLine($"Invalid argument -customBuildName, defaulting to {defaultCustomBuildName}.");
                validatedOptions.Add("customBuildName", defaultCustomBuildName);
            }

            return validatedOptions;
        }

        private static void ParseCommandLineArguments(out Dictionary<string, string> providedArguments)
        {
            providedArguments = new Dictionary<string, string>();
            string[] args = Environment.GetCommandLineArgs();

            Console.WriteLine(
                $"{Eol}" +
                $"###########################{Eol}" +
                $"#    Parsing settings     #{Eol}" +
                $"###########################{Eol}" +
                $"{Eol}"
            );

            // Extract flags with optional values
            for (int current = 0, next = 1; current < args.Length; current++, next++)
            {
                // Parse flag
                bool isFlag = args[current].StartsWith("-");
                if (!isFlag) continue;
                string flag = args[current].TrimStart('-');

                // Parse optional value
                bool flagHasValue = next < args.Length && !args[next].StartsWith("-");
                string value = flagHasValue ? args[next].TrimStart('-') : "";
                bool secret = Secrets.Contains(flag);
                string displayValue = secret ? "*HIDDEN*" : "\"" + value + "\"";

                // Assign
                Console.WriteLine($"Found flag \"{flag}\" with value {displayValue}.");
                providedArguments.Add(flag, value);
            }
        }
    }
}
