namespace Migrations.Identifiers
{
    internal static class OwnersConst
    {
        internal const string Table = "owners";

        internal const string Id = "id";
        internal const string Name = "name";
        internal const string Description = "description";
        internal const string UserId = "user_id";

        // Indexes
        internal const string IxPk = "ix_owners_pk";
        internal const string IxName = "ix_owners_name";
        internal const string IxUser = "ix_owners_user_id";
    }
}
