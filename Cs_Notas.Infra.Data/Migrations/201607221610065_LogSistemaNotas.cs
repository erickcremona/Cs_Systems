namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogSistemaNotas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogSistema",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        Tela = c.String(maxLength: 50, unicode: false),
                        Data = c.DateTime(storeType: "date"),
                        Hora = c.String(maxLength: 10, unicode: false),
                        Descricao = c.String(maxLength: 255, unicode: false),
                        IdUsuario = c.Int(),
                        Usuario = c.String(maxLength: 100, unicode: false),
                        Maquina = c.String(maxLength: 50, unicode: false),
                        IdAto = c.Int(),
                        HoraClose = c.String(maxLength: 10, unicode: false),
                        InicioTela = c.String(maxLength: 255, unicode: false),
                        FimTela = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.LogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogSistema");
        }
    }
}
