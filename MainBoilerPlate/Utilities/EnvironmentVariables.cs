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

        public static string JWT_KEY => GetEnvVar("JWT_KEY", "averyveryveryLongkeyforaveryveryverysecureaaplicationTwiceaveryveryveryLongkeyforaveryveryverysecureaaplicationTwice");
        public static string? API_BACK_URL => GetEnvVar("API_BACK_URL", "");
        public static string? API_FRONT_URL => GetEnvVar("API_FRONT_URL", "");

        // DATABASE
        public static string DB_PORT => GetEnvVar("DB_PORT", "5432");
        public static string DB_HOST => GetEnvVar("DB_HOST", "localhost");
        public static string DB_NAME => GetEnvVar("DB_NAME", "mainDB");
        public static string DB_USER => GetEnvVar("DB_USER", "postgres");
        public static string DB_PASSWORD => GetEnvVar("DB_PASSWORD", "beecoming");

        // Roles
        public static Guid ROLE_SUPER_ADMIN =>
            GetEnvVarGuid("ROLE_SUPER_ADMIN", "bde5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid ROLE_ADMIN =>
            GetEnvVarGuid("ROLE_ADMIN", "4a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid ROLE_TEACHER =>
            GetEnvVarGuid("ROLE_TEACHER", "87a0a5ed-c7bb-4394-a163-7ed7560b3703");
        public static Guid ROLE_STUDENT =>
            GetEnvVarGuid("ROLE_STUDENT", "87a0a5ed-c7bb-4394-a163-7ed7560b4a01");

        // Genders
        public static Guid GENDER_MALE =>
            GetEnvVarGuid("GENDER_MALE", "bde5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid GENDER_FEMALE =>
            GetEnvVarGuid("GENDER_FEMALE", "4a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid GENDER_OTHER =>
            GetEnvVarGuid("GENDER_OTHER", "87a0a5ed-c7bb-4394-a163-7ed7560b3703");

        // Statuses
        public static Guid STATUS_PENDING =>
            GetEnvVarGuid("GENDER_MALE", "bde5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid STATUS_CONFIRMED =>
            GetEnvVarGuid("GENDER_FEMALE", "4a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid STATUS_BANNED =>
            GetEnvVarGuid("GENDER_OTHER", "87a0a5ed-c7bb-4394-a163-7ed7560b3703");

        // auth
        public static int COOKIES_VALIDITY_DAYS => GetEnvVarInt("COOKIES_VALIDITY_DAYS", 7);
        public static int TOKEN_VALIDITY_MINUTES => GetEnvVarInt("TOKEN_VALIDITY_MINUTES", 30);

        // mail
        public static string SMTP_HOST => GetEnvVar("SMTP_HOST", "smtp.mailtrap.io");
        public static int SMTP_PORT => GetEnvVarInt("SMTP_PORT", 543);
        public static string SMTP_LOGIN => GetEnvVar("SMTP_LOGIN", "");
        public static string SMTP_KEY => GetEnvVar("SMTP_KEY", "");
        public static string DO_NO_REPLY_MAIL => GetEnvVar("DO_NO_REPLY_MAIL", "do-not-reply@inspire.fr");
        // default admin email and password
        public static string SUPER_ADMIN_EMAIL => GetEnvVar("ADMIN_EMAIL", "super.admin@inspire.fr");
        public static string SUPER_ADMIN_PASSWORD => GetEnvVar("ADMIN_PASSWORD", "SuperPassword123!");
    }
}
