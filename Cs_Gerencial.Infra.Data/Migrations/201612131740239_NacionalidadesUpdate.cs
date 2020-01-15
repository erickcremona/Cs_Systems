namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NacionalidadesUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Nacionalidades", "Onu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nacionalidades", "Onu", c => c.Int());
        }
    }
}
