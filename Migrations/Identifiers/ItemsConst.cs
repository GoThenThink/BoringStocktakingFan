namespace Migrations.Identifiers
{
    internal static class ItemsConst
    {
        internal const string Table = "items";

        internal const string Id = "id";
        internal const string Name = "name";
        internal const string Code = "code";
        internal const string Description = "description";
        internal const string CategoryId = "category_id";
        internal const string StorageId = "storage_id";
        internal const string OwnerId = "owner_id";
        internal const string UserId = "user_id";

        // Indexes
        internal const string IxPk = "ix_items_pk";
        internal const string IxName = "ix_items_name";
        internal const string IxCode = "ix_items_code";
        internal const string IxCategory = "ix_items_category_id";
        internal const string IxStorage = "ix_items_storage_id";
        internal const string IxOwner = "ix_items_owner_id";
        internal const string IxUser = "ix_items_user_id";

        // Foreign keys
        internal const string FkCategory = "fk_items_category_id";
        internal const string FkStorage = "fk_items_storage_id";
        internal const string FkOwner = "fk_items_owner_id";
    }
}
