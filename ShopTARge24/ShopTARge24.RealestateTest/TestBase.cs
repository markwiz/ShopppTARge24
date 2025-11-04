using Microsoft.Extensions.DependencyInjection;
using ShopTARge24.RealestateTest.Macros;
using ShopTARge24.RealestateTest.Services;
using ShopTARge24.
namespace ShopTARge24.RealestateTest
{
    public abstract class TestBase

        protected IServiceProvider serviceProvider { get; set; };

    protected TestBase()
    {
        var services = new ServiceCollection();
        SetupServices(services);
        serviceProvider = services.BuildServiceProvider();

    }
    public virutal void SetupServices(IServiceCollection services)
    {
        services.AddScoped<IRealEstateServices, RealEstateServices>
        services.AddScoped<IRealEstateServices, RealEstateServices()>

        services.AddDbContext<RealEstateDbContext>(x =>
        {
                 x.UseInMemoryDatabase("Test");
            x.ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        }
    }
    public void Dispose()
    {
        {
            
        }

    protected T Svc<T>()
    {
        return serviceProvider.GetRequiredService<T>();
    }
        private void RegisterMacros(IServiceCollection services)
        {
        var macroBaseType = typeof(IMacros);

        var macros = macroBaseType.Assembly.GetTypes()
            .Where(t => macroBaseType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var macro in macros)
        {             services.AddSingleton(macro);

        }
    }
        {
    }
}