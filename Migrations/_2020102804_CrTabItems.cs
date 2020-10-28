using FluentMigrator;
using Migrations.Identifiers;

namespace Migrations
{
    [Migration(2020102804, "Created table items")]
    public sealed class _2020102804_CrTabItems : Migration
    {
        public override void Down()
        {
            Delete.Table(ItemsConst.Table);
        }

        public override void Up()
        {
            Create.Table(ItemsConst.Table)
                .WithColumn(ItemsConst.Id).AsInt64().PrimaryKey().Identity()
                .WithColumn(ItemsConst.Name).AsAnsiString(512).NotNullable().Unique()
                .WithColumn(ItemsConst.Code).AsAnsiString(4).Nullable()
                .WithColumn(ItemsConst.Description).AsString().Nullable()
                .WithColumn(ItemsConst.CategoryId).AsInt64().Nullable().ForeignKey(ItemsConst.FkCategory, CategoriesConst.Table, CategoriesConst.Id)
                .WithColumn(ItemsConst.StorageId).AsInt64().Nullable().ForeignKey(ItemsConst.FkStorage, StoragesConst.Table, StoragesConst.Id)
                .WithColumn(ItemsConst.OwnerId).AsInt64().Nullable().ForeignKey(ItemsConst.FkOwner, OwnersConst.Table, OwnersConst.Id)
                .WithColumn(ItemsConst.UserId).AsGuid().NotNullable();

            Create.Index(ItemsConst.IxPk).OnTable(ItemsConst.Table).WithOptions().Clustered().OnColumn(ItemsConst.Id);
            Create.Index(ItemsConst.IxCode).OnTable(ItemsConst.Table).WithOptions().NonClustered().OnColumn(ItemsConst.Code);
            Create.Index(ItemsConst.IxCategory).OnTable(ItemsConst.Table).WithOptions().NonClustered().OnColumn(ItemsConst.CategoryId);
            Create.Index(ItemsConst.IxStorage).OnTable(ItemsConst.Table).WithOptions().NonClustered().OnColumn(ItemsConst.StorageId);
            Create.Index(ItemsConst.IxOwner).OnTable(ItemsConst.Table).WithOptions().NonClustered().OnColumn(ItemsConst.OwnerId);
            Create.Index(ItemsConst.IxUser).OnTable(ItemsConst.Table).WithOptions().NonClustered().OnColumn(ItemsConst.UserId);
        }
    }
}
