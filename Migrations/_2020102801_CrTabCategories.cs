using FluentMigrator;
using Migrations.Identifiers;

namespace Migrations
{
    [Migration(2020102801, "Created table categories")]
    public sealed class _2020102801_CrTabCategories : Migration
    {
        public override void Down()
        {
            Delete.Table(CategoriesConst.Table);
        }

        public override void Up()
        {
            Create.Table(CategoriesConst.Table)
                .WithColumn(CategoriesConst.Id).AsInt64().PrimaryKey().Identity()
                .WithColumn(CategoriesConst.Name).AsAnsiString(512).NotNullable().Unique()
                .WithColumn(CategoriesConst.CodePrefixId).AsInt32().Nullable().ForeignKey(CategoriesConst.FkCodePrefix, CodePrefixesConst.Table, CodePrefixesConst.Id)
                .WithColumn(CategoriesConst.Description).AsString().Nullable()
                .WithColumn(CategoriesConst.ParentId).AsInt64().Nullable().ForeignKey(CategoriesConst.FkParent, CategoriesConst.Table, CategoriesConst.Id)
                .WithColumn(CategoriesConst.UserId).AsGuid().NotNullable();

            Create.Index(CategoriesConst.IxPk)
                .OnTable(CategoriesConst.Table).WithOptions().Clustered().OnColumn(CategoriesConst.Id);
            Create.Index(CategoriesConst.IxCodePrefix)
                .OnTable(CategoriesConst.Table).WithOptions().NonClustered().OnColumn(CategoriesConst.CodePrefixId);
            Create.Index(CategoriesConst.IxUser)
                .OnTable(CategoriesConst.Table).WithOptions().NonClustered().OnColumn(CategoriesConst.UserId);
        }
    }
}
