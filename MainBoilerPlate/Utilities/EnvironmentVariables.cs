namespace MainBoilerPlate.Utilities
{
    public static class EnvironmentVariables
    {
        private static string GetEnvVar(string envVarName, string fallbackValue)
        {
            return Environment.GetEnvironmentVariable(envVarName) ?? fallbackValue;
        }

        private static int GetEnvVarInt(string envVarName, int fallbackValue)
        {
            var envValue = Environment.GetEnvironmentVariable(envVarName);
            return int.TryParse(envValue, out var result) ? result : fallbackValue;
        }

        private static bool GetEnvVarBool(string envVarName, bool fallbackValue)
        {
            var envValue = Environment.GetEnvironmentVariable(envVarName);
            return bool.TryParse(envValue, out var result) ? result : fallbackValue;
        }

        private static Guid GetEnvVarGuid(string envVarName, string fallBackValue)
        {
            var value = Environment.GetEnvironmentVariable(envVarName);
            return Guid.TryParse(value, out var result) ? result : Guid.Parse(fallBackValue);
        }

        public static string JWT_KEY => GetEnvVar("JWT_KEY", "");
        public static string? API_BACK_URL => GetEnvVar("API_BACK_URL", "");
        public static string? API_FRONT_URL => GetEnvVar("API_FRONT_URL", "");

        // DATABASE
        public static string? DB_PORT => GetEnvVar("DB_PORT", "5432");
        public static string? DB_HOST => GetEnvVar("DB_HOST", "localhost");
        public static string? DB_NAME => GetEnvVar("DB_NAME", "mainDB");
        public static string? DB_USER => GetEnvVar("DB_USER", "postgres");
        public static string? DB_PASSWORD => GetEnvVar("DB_PASSWORD", "beecoming");

        // Roles
        public static Guid ROLE_SUPER_ADMIN =>
            GetEnvVarGuid("ROLE_SUPER_ADMIN", "bde5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid ROLE_ADMIN =>
            GetEnvVarGuid("ROLE_ADMIN", "4a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid ROLE_USER =>
            GetEnvVarGuid("ROLE_USER", "87a0a5ed-c7bb-4394-a163-7ed7560b3703");

        // Genders
        public static Guid GENDER_MALE =>
            GetEnvVarGuid("GENDER_MALE", "bde5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid GENDER_FEMALE =>
            GetEnvVarGuid("GENDER_FEMALE", "4a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid GENDER_OTHER =>
            GetEnvVarGuid("GENDER_OTHER", "87a0a5ed-c7bb-4394-a163-7ed7560b3703");
    }
}
