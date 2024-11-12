using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Products.Data
{
    public class DbMigrationService
    {
        public static void MigrationInit(IApplicationBuilder app)
        {


            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                try
                {
                    serviceScope.ServiceProvider.GetService<ProductsContext>().Database.Migrate();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
