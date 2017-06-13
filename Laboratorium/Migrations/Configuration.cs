using System.Data.Entity.Migrations;
using System.Linq;
using Laboratorium.DAL.Contexts;
using Laboratorium.Helpers;
using Laboratorium.Models.DataModels;

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
            var dataHelper = new DefaultDataHelper(context);

            dataHelper.AddData();
        }
    }
}