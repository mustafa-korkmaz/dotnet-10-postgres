namespace API.Requests
{
    public static class RequestValidationErrorCodes
    {
        public const string RequiredField = "{0}_FIELD_IS_REQUIRED";

        public const string InvalidGuidField = "{0}_FIELD_SHOULD_BE_GUID";

        public const string MaxLength = "{0}_FIELD_SHOULD_BE_MAX_{1}_CHARS";

        public const string BetweenRange = "{0}_FIELD_SHOULD_BE_BETWEEN_{1}_AND_{2}";

        public const string InvalidField = "{0}_FIELD_IS_NOT_VALID";
    }
}
