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
        private static string version = "";

        private static readonly string[] Secrets =
            {"androidKeystorePass", "androidKeyaliasName", "androidKeyaliasPass"};

        public static void Builder()
        {
            Dictionary<string, string> options = GetValidatedOptions();

            string increment = options["increment"];

            string buildTag = options["buildTag"];

            string buildVersion = options["buildVersion"];

            string buildPath = options["customBuildPath"];

            var buildTarget = (BuildTarget) Enum.Parse(typeof(BuildTarget), options["buildTarget"]);

            SetVersion(increment, buildTag, buildVersion);
            BuildReport report = BuildPipeline.BuildPlayer(GetScenes(), buildPath, buildTarget,
                BuildOptions.None);

            BuildSummary summary = report.summary;


            if (summary.result == BuildResult.Succeeded)
            {
                Console.WriteLine("Build succeeded: " + summary.totalSize + " bytes");
            }

            if (summary.result == BuildResult.Failed)
            {
                Console.WriteLine("Build Failed");
                throw new Exception($"Build ended with {summary.result} status");
            }
        }

        private static string[] GetScenes()
        {
            return EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();
        }

        private static void SetVersion(string increment, string buildTag, string buildVersion)
        {
            Console.WriteLine(
                $"{Eol}" +
                $"###########################{Eol}" +
                $"#       Set Version       #{Eol}" +
                $"###########################{Eol}" +
                $"{Eol}"
            );

            string newVersion = buildVersion;

            if (increment == "release")
            {
                version = buildVersion;
            }
            else
            {
                version = buildVersion + "." + buildTag;
            }

            PlayerSettings.productName = "Book of Boilers";
            PlayerSettings.bundleVersion = version;


            Console.WriteLine(
                $"{Eol}" +
                $"bundleversion -> {PlayerSettings.bundleVersion}" +
                $"{Eol}"
            );
        }


        private static Dictionary<string, string> GetValidatedOptions()
        {
            ParseCommandLineArguments(out Dictionary<string, string> validatedOptions);

            if (!validatedOptions.TryGetValue("buildTarget", out string buildTarget))
            {
                Console.WriteLine("Missing argument -buildTarget");
                EditorApplication.Exit(100);
            }

            if (!Enum.IsDefined(typeof(BuildTarget), buildTarget ?? string.Empty))
            {
                EditorApplication.Exit(101);
            }

            if (!validatedOptions.TryGetValue("customBuildPath", out string _))
            {
                Console.WriteLine("Missing argument -customBuildPath");
                EditorApplication.Exit(110);
            }
            
            if (!validatedOptions.TryGetValue("buildVersion", out string _))
            {
                Console.WriteLine("Missing argument -buildVersion");
                EditorApplication.Exit(120);
            }
            
            if (!validatedOptions.TryGetValue("increment", out string _))
            {
                Console.WriteLine("Missing argument -increment");
                EditorApplication.Exit(130);
            }
            
            if (!validatedOptions.TryGetValue("buildTag", out string _))
            {
                Console.WriteLine("Missing argument -buildTag");
                EditorApplication.Exit(140);
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
