namespace WebApiWithASP.Net.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiWithASP.Net.Data.WebApiWithASPNetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApiWithASP.Net.Data.WebApiWithASPNetContext context)
        {
            context.Employees.AddOrUpdate(x => x.Id, 
                new Models.Employee() {Id  =1,Name = "Vishal Bhanderi"},
                new Models.Employee() {Id = 2,Name = "JAy Ramani" },
                new Models.Employee() { Id = 3, Name = "Aarti Bhanderi" },
                new Models.Employee() { Id = 4, Name = "Bhautik Dholariya" },
                new Models.Employee() { Id = 5, Name = "Akash B Patel" }
                );

            context.Offices.AddOrUpdate(x => x.Id,
                new Models.Office()
                {
                    Id = 101,
                    Location = "Ahmedabad",
                    EmployeeId = 1
                },
                new Models.Office()
                {
                    Id = 102,
                    Location = "Surat",
                    EmployeeId = 2
                }
                );
        }
    }
}
