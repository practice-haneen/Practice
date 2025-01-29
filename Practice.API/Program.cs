/*
* configure the host
* Add services to the container.
*/
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Practice.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

/*
 * register services and dependency injection
 */
ConfigureServices(builder.Services);

/*
 * configures http request pipeline
 */
var app = builder.Build();

/*
 * define middleware pipeline 
 */
Configuer(app, app.Environment);


app.Map("/error", (HttpContext httpContext, ILoggerFactory loggerFactory) =>
{
    var exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    var logger = loggerFactory.CreateLogger("ExceptionHandler");
    logger.LogInformation("Error: {error}", exception?.Message);
    return Results.Problem(exception?.Message);
});

app.Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

static void Configuer(IApplicationBuilder app, IWebHostEnvironment environment)
{
    if (environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<TimeLoggingMiddleware>();
    app.UseExceptionHandler("/error");
    // the words Use/Map/Run are called delegates
    app.UseCors("AllowAll");

    app.UseRouting();

    app.UseAuthentication();

    app.UseAuthorization();

    app.UseEndpoints(endpionts =>
    endpionts.MapControllers());
}
