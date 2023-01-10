namespace TestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args);
            var app = builder.Build();
            app.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return new HostBuilder()
                .ConfigureAppConfiguration((ctx, config) =>
                {
                    //ctx.HostingEnvironment.ApplicationName = "TestApp"; //works in .net6, 7
                    ctx.HostingEnvironment.ApplicationName = "abc"; //works in .net6, fails in 7
                })
                .ConfigureWebHostDefaults(config => config.UseStartup<Startup>());
        }
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}