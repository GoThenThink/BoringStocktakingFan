using FluentMigrator;
using Migrations.Identifiers;

namespace Migrations
{
    [Migration(2020102800, "Created table code_prefixes")]
    public sealed class _2020102800_CrTabCodePrefixes : Migration
    {
        public override void Down()
        {
            Delete.Table(CodePrefixesConst.Table);
        }

        public override void Up()
        {
            Create.Table(CodePrefixesConst.Table)
                .WithColumn(CodePrefixesConst.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn(CodePrefixesConst.Code).AsAnsiString(2).NotNullable().Unique()
                .WithColumn(CodePrefixesConst.UserId).AsGuid().NotNullable();

            Create.Index(CodePrefixesConst.IxPk)
                .OnTable(CodePrefixesConst.Table).WithOptions().Clustered().OnColumn(CodePrefixesConst.Id);
            Create.Index(CodePrefixesConst.IxUser)
                .OnTable(CodePrefixesConst.Table).WithOptions().NonClustered().OnColumn(CodePrefixesConst.UserId);
        }
    }
}
