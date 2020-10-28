namespace Migrations.Identifiers
{
    internal static class CodePrefixesConst
    {
        internal const string Table = "code_prefixes";

        internal const string Id = "id";
        internal const string Code = "code";
        internal const string UserId = "user_id";

        // Indexes
        internal const string IxPk = "ix_code_prefixes_pk";
        internal const string IxUser = "ix_code_prefixes_user_id";
    }
}
