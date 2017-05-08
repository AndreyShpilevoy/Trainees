namespace MeetWagonMVC4.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using WebMatrix.WebData;
	using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<MeetWagonMVC4.Context.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MeetWagonMVC4.Context.DataContext context)
        {
			WebSecurity.InitializeDatabaseConnection(
				"DefaultConnection",
				"UserProfile",
				"UserID",
				"UserName",
				autoCreateTables: true);

			if (!Roles.RoleExists("Administrator"))
				Roles.CreateRole("Administrator");

			if (!WebSecurity.UserExists("matt"))
				WebSecurity.CreateUserAndAccount(
					"matt",
					"password");

			if (!WebSecurity.UserExists("guest"))
				WebSecurity.CreateUserAndAccount(
					"guest",
					"password");

			if (!Roles.GetRolesForUser("matt").Contains("Administrator"))
				Roles.AddUserToRole("matt", "Administrator");
        }
    }
}
