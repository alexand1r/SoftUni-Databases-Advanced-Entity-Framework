using System.IO;
using System.Linq;
using Project.Data;
using Project.Client.Import;

namespace Project.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new ShopContext();
            context.Database.Initialize(true);

            // import jsons - file is located in Client/Import

            ImportFunctions import = new ImportFunctions();
            import.ImportUsers(context);
            import.ImportProducts(context);
            import.ImportCategories(context);

        }
    }
}
