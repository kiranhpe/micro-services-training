using Customer.BL;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Customer.MigrationService
{
    public class DbMigrationService
    {
        public static void MigrationInit(IApplicationBuilder app)
        {


            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                try
                {
                    serviceScope.ServiceProvider.GetService<CustomerContext>().Database.Migrate();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
