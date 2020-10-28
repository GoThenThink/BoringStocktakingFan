namespace Migrations.Identifiers
{
    internal static class StoragesConst
    {
        internal const string Table = "storages";

        internal const string Id = "id";
        internal const string Name = "name";
        internal const string CodePrefixId = "code_prefix_id";
        internal const string Description = "description";
        internal const string ParentId = "parent_id";
        internal const string UserId = "user_id";

        // Indexes
        internal const string IxPk = "ix_storages_pk";
        internal const string IxName = "ix_storages_name";
        internal const string IxCodePrefix = "ix_storages_code_prefix_id";
        internal const string IxUser = "ix_storages_user_id";

        // Foreign keys
        internal const string FkCodePrefix = "fk_storages_code_prefix_id";
        internal const string FkParent = "fk_storages_parent_id";
    }
}
