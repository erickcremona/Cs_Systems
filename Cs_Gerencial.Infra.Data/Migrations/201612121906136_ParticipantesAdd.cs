namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParticipantesAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Participantes",
                c => new
                    {
                        ParticipantesId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 40, unicode: false),
                        Oculto = c.String(nullable: false, maxLength: 1, unicode: false),
                        Doi = c.String(nullable: false, maxLength: 2, unicode: false),
                        Ditribuicao = c.String(nullable: false, maxLength: 1, unicode: false),
                        OcultarXmlTd = c.String(maxLength: 1, unicode: false),
                    })
                .PrimaryKey(t => t.ParticipantesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Participantes");
        }
    }
}
