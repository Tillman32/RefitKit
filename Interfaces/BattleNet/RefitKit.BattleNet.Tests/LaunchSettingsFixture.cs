using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace RefitKit.BattleNet.Tests
{
    public class LaunchSettingsFixture : IDisposable
    {
        public LaunchSettingsFixture()
        {
            var launchSettings = "Properties\\launchSettings.json";

            // This shouldn't exist when on Azure Pipeline.
            // For local testing make sure you have a launchSettings.json with env variables.
            if (!File.Exists(launchSettings))
            {
                Console.WriteLine($"{launchSettings} does not exist");
                return;
            }

            using (var file = File.OpenText(launchSettings))
            {
                var reader = new JsonTextReader(file);
                var jObject = JObject.Load(reader);

                var variables = jObject
                    .GetValue("profiles")
                    //select a proper profile here
                    .SelectMany(profiles => profiles.Children())
                    .SelectMany(profile => profile.Children<JProperty>())
                    .Where(prop => prop.Name == "environmentVariables")
                    .SelectMany(prop => prop.Value.Children<JProperty>())
                    .ToList();

                foreach (var variable in variables)
                {
                    Environment.SetEnvironmentVariable(variable.Name, variable.Value.ToString());
                }
            }
        }

        public void Dispose()
        {
            // ... clean up
        }
    }
}
