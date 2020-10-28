namespace Migrations.Identifiers
{
    internal static class CategoriesConst
    {
        internal const string Table = "categories";

        internal const string Id = "id";
        internal const string Name = "name";
        internal const string CodePrefixId = "code_prefix_id";
        internal const string Description = "description";
        internal const string ParentId = "parent_id";
        internal const string UserId = "user_id";

        // Indexes
        internal const string IxPk = "ix_categories_pk";
        internal const string IxName = "ix_categories_name";
        internal const string IxCodePrefix = "ix_categories_code_prefix_id";
        internal const string IxUser = "ix_categories_user_id";

        // Foreign keys
        internal const string FkCodePrefix = "fk_categories_code_prefix_id";
        internal const string FkParent = "fk_categories_parent_id";
    }
}
