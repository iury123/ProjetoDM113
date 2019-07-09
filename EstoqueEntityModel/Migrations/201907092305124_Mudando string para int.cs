namespace EstoqueEntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mudandostringparaint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProdutoEstoques", "EstoqueProduto", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProdutoEstoques", "EstoqueProduto", c => c.String(nullable: false));
        }
    }
}
