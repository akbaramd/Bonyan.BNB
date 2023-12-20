using Bonyan.Bnb;
using Bonyan.Bnb.Statics;
using Bonyan.Bnb.Threading;

namespace Bonyan.BNB.AspNetCore.Microsoft.AspNetCore.Builder;

public static class BnbApplicationBuilderExtensions
{
    private const string ExceptionHandlingMiddlewareMarker = "_BnbExceptionHandlingMiddleware_Added";

    public async static Task InitializeApplicationAsync( this IApplicationBuilder app)
    {
        BnbCheck.NotNull(app, nameof(app));

        var application = app.ApplicationServices.GetRequiredService<IBnbApplicationWithExternalServiceProvider>();
        var applicationLifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

        applicationLifetime.ApplicationStopping.Register(() =>
        {
            AsyncHelper.RunSync(() => application.ShutdownAsync());
        });

        applicationLifetime.ApplicationStopped.Register(() =>
        {
            application.Dispose();
        });

        await application.InitializeAsync(app.ApplicationServices);
    }

    public static void InitializeApplication(this IApplicationBuilder app)
    {
        BnbCheck.NotNull(app, nameof(app));

        // app.ApplicationServices.GetRequiredService<ObjectAccessor<IApplicationBuilder>>().Value = app;
        var application = app.ApplicationServices.GetRequiredService<IBnbApplicationWithExternalServiceProvider>();
        var applicationLifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

        applicationLifetime.ApplicationStopping.Register(() =>
        {
            application.Shutdown();
        });

        applicationLifetime.ApplicationStopped.Register(() =>
        {
            application.Dispose();
        });

        application.Initialize(app.ApplicationServices);
    }

   
}