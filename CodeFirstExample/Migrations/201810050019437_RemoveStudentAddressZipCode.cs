namespace CodeFirstExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveStudentAddressZipCode : DbMigration
    {
        public override void Up()
        {
            DropColumn("Admin.StudentAddresses", "Zipcode");
        }
        
        public override void Down()
        {
            AddColumn("Admin.StudentAddresses", "Zipcode", c => c.Int(nullable: false));
        }
    }
}
