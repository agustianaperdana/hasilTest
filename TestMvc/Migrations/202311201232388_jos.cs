namespace TestMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nama_barang = c.String(nullable: false, maxLength: 40),
                        kode_barang = c.String(nullable: false, maxLength: 40),
                        jumlah_barang = c.String(nullable: false, maxLength: 40),
                        tanggal = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produks");
        }
    }
}
