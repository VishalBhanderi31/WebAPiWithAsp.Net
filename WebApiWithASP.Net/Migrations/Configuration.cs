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
                new Models.Employee() {Id = 2,Name = "JAy Ramani" });

            context.Offices.AddOrUpdate(x => x.Id,
                new Models.Office()
                {
                    Id = 101,
                    Location = "Ahmedabad",
                    EmployeeId = 1
                });
        }
    }
}
