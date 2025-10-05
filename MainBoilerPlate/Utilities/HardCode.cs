namespace MainBoilerPlate.Utilities
{
    public static class HardCode
    {
        // Roles
        public static Guid ROLE_SUPER_ADMIN => Guid.Parse( "bde5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid ROLE_ADMIN => Guid.Parse("4a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid ROLE_TEACHER => Guid.Parse("87a0a5ed-c7bb-4394-a163-7ed7560b3703");
        public static Guid ROLE_STUDENT => Guid.Parse("87a0a5ed-c7bb-4394-a163-7ed7560b4a01");

        // Genders
        public static Guid GENDER_MALE => Guid.Parse("bde5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid GENDER_FEMALE => Guid.Parse("4a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid GENDER_OTHER => Guid.Parse("87a0a5ed-c7bb-4394-a163-7ed7560b3703");

        // Statuses
        public static Guid STATUS_PENDING => Guid.Parse("bde5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid STATUS_CONFIRMED => Guid.Parse("4a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid STATUS_BANNED => Guid.Parse("87a0a5ed-c7bb-4394-a163-7ed7560b3703");

        // Statuses
        public static Guid LEVEL_BEGINNER => Guid.Parse("bde5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid LEVEL_INTERMEDIATE => Guid.Parse("4a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid LEVEL_ADVANCED => Guid.Parse("87a0a5ed-c7bb-4394-a163-7ed7560b3703");

        // Categories
        public static Guid CATEGORY_TECHNICS => Guid.Parse("bde5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid CATEGORY_SOFT => Guid.Parse("4a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid CATEGORY_FRONT => Guid.Parse("87a0a5ed-c7bb-4394-a163-7ed7560b3703");
        public static Guid CATEGORY_BACK => Guid.Parse("41f1f997-c392-4aac-bef0-fc8acaf109ec");

        // Languages
        public static Guid LANGUAGE_FRENCH => Guid.Parse("bde5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid LANGUAGE_ENGLISH => Guid.Parse("4a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid LANGUAGE_ARAB => Guid.Parse("87a0a5ed-c7bb-4394-a163-7ed7560b3703");
        public static Guid LANGUAGE_SPANISH => Guid.Parse("41f1f997-c392-4aac-bef0-fc8acaf109ec");

        // ProgrammingLanguages
        public static Guid LANGUAGE_JS => Guid.Parse("bde5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid LANGUAGE_JAVA => Guid.Parse("4a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid LANGUAGE_CSHARP => Guid.Parse("87a0a5ed-c7bb-4394-a163-7ed7560b3703");
        public static Guid LANGUAGE_CPP => Guid.Parse("41f1f997-c392-4aac-bef0-fc8acaf109ec");
    }
}
