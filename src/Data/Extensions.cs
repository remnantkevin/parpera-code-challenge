using Parpera.Data;

public static class Extensions
{
    public static void SeedDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<TransactionContext>();
            if (context.Database.EnsureCreated())
            {
                DatabaseInitializer.Initialize(context);
            }
        }
    }
}
