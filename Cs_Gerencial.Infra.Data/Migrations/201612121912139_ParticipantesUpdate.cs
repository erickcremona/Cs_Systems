namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParticipantesUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participantes", "Distribuicao", c => c.String(nullable: false, maxLength: 1, unicode: false));
            DropColumn("dbo.Participantes", "Ditribuicao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participantes", "Ditribuicao", c => c.String(nullable: false, maxLength: 1, unicode: false));
            DropColumn("dbo.Participantes", "Distribuicao");
        }
    }
}
