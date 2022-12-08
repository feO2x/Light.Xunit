using System;
using Light.GuardClauses;

namespace Light.Xunit;

internal sealed record TestConfiguration
{
    public bool IsInBuildServerMode
    {
        get
        {
            if (IsInBuildServerModeEnvironmentVariableName.IsNullOrWhiteSpace())
                return false;

            var environmentVariable = Environment.GetEnvironmentVariable(IsInBuildServerModeEnvironmentVariableName);
            if (environmentVariable is null)
                return false;

            var trimmedVariable = environmentVariable.Trim();
            return trimmedVariable.Equals("true", StringComparisonType.OrdinalIgnoreCase) ||
                   trimmedVariable.Equals("1", StringComparison.Ordinal);
        }
    }

    public string IsInBuildServerModeEnvironmentVariableName { get; set; } = string.Empty;
    public bool LoadEnvironmentVariables { get; set; }
    public string EnvironmentVariablesPrefix { get; set; } = string.Empty;
    public bool LoadDevelopmentSettingsFileInBuildServerMode { get; set; } = false;
}