using System.Data.Entity.Migrations;
using Laboratorium.DAL;
using Laboratorium.Helpers;

namespace Laboratorium.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<LaboratoriumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LaboratoriumContext context)
        {
            var dataHelper = new DatabasePreparer(context);

            dataHelper.AddData();
        }
    }
}