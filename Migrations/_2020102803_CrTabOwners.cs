using FluentMigrator;
using Migrations.Identifiers;

namespace Migrations
{
    [Migration(2020102803, "Created table owners")]
    public sealed class _2020102803_CrTabOwners : Migration
    {
        public override void Down()
        {
            Delete.Table(OwnersConst.Table);
        }

        public override void Up()
        {
            Create.Table(OwnersConst.Table)
                .WithColumn(OwnersConst.Id).AsInt64().PrimaryKey().Identity()
                .WithColumn(OwnersConst.Name).AsAnsiString(512).NotNullable()
                .WithColumn(OwnersConst.Description).AsString().Nullable()
                .WithColumn(OwnersConst.UserId).AsGuid().NotNullable();

            Create.Index(OwnersConst.IxPk)
                .OnTable(OwnersConst.Table).WithOptions().Clustered().OnColumn(OwnersConst.Id);
            Create.Index(OwnersConst.IxName)
                .OnTable(OwnersConst.Table).WithOptions().NonClustered().OnColumn(OwnersConst.Name).Ascending();
            Create.Index(OwnersConst.IxUser)
                .OnTable(OwnersConst.Table).WithOptions().NonClustered().OnColumn(OwnersConst.UserId);
        }
    }
}
