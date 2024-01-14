
using Ab_pk_task_MovieStore;
using Ab_pk_task_MovieStore.DBOperations;

namespace Ab_pk_task_MovieStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // in memory de baslangýc olarak database kontrolu ve veri ekleme için kullanýlýyor
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                DataGenerator.Initialize(services);
            }
            host.Run();


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    
    }
}
