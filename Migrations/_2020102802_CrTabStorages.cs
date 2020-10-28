using FluentMigrator;
using Migrations.Identifiers;

namespace Migrations
{
    [Migration(2020102802, "Created table storages")]
    public sealed class _2020102802_CrTabStorages : Migration
    {
        public override void Down()
        {
            Delete.Table(StoragesConst.Table);
        }

        public override void Up()
        {
            Create.Table(StoragesConst.Table)
                .WithColumn(StoragesConst.Id).AsInt64().PrimaryKey().Identity()
                .WithColumn(StoragesConst.Name).AsAnsiString(512).NotNullable().Unique()
                .WithColumn(StoragesConst.CodePrefixId).AsInt32().Nullable().ForeignKey(StoragesConst.FkCodePrefix, CodePrefixesConst.Table, CodePrefixesConst.Id)
                .WithColumn(StoragesConst.Description).AsString().Nullable()
                .WithColumn(StoragesConst.ParentId).AsInt64().Nullable().ForeignKey(StoragesConst.FkParent, StoragesConst.Table, StoragesConst.Id)
                .WithColumn(StoragesConst.UserId).AsGuid().NotNullable();

            Create.Index(StoragesConst.IxPk)
                .OnTable(StoragesConst.Table).WithOptions().Clustered().OnColumn(StoragesConst.Id);
            Create.Index(StoragesConst.IxCodePrefix)
                .OnTable(StoragesConst.Table).WithOptions().NonClustered().OnColumn(StoragesConst.CodePrefixId);
            Create.Index(StoragesConst.IxUser)
                .OnTable(StoragesConst.Table).WithOptions().NonClustered().OnColumn(StoragesConst.UserId);
        }
    }
}
