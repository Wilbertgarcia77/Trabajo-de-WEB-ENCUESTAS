using System;
using System.IO;
using System.Collections.Generic;

namespace encuestasgym.Helpers
{
    public static class EnvHelper
    {
        private static Dictionary<string, string>? _envVars;

        public static string? Get(string key)
        {
            if (_envVars == null)
            {
                _envVars = new Dictionary<string, string>();
                var envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
                if (File.Exists(envPath))
                {
                    foreach (var line in File.ReadAllLines(envPath))
                    {
                        if (string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith("#")) continue;
                        var parts = line.Split('=', 2);
                        if (parts.Length == 2)
                        {
                            _envVars[parts[0].Trim()] = parts[1].Trim();
                        }
                    }
                }
            }
            if (_envVars.ContainsKey(key))
            {
                var value = _envVars[key];
                if (value.StartsWith("\"") && value.EndsWith("\""))
                {
                    value = value.Substring(1, value.Length - 2);
                }
                return value;
            }
            return null;
        }
    }
}
