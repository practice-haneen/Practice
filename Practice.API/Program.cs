/*
 * configure the host
 * Add services to the container.
 */
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

    // the words Use/Map/Run are called delegates
    app.UseCors("AllowAll");

    app.UseAuthentication();

    app.UseAuthorization();

    app.UseEndpoints(endpionts =>
    endpionts.MapControllers());


    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("Middleware1: Incoming Request\n");
        //Calling the Next Middleware Component
        await next();
        await context.Response.WriteAsync("Middleware1: Outgoing Response\n");
    });
    //Second Middleware Component Registered using Use Extension Method
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("Middleware2: Incoming Request\n");
        //Calling the Next Middleware Component
        await next();
        await context.Response.WriteAsync("Middleware2: Outgoing Response\n");
    });
    //Third Middleware Component Registered using Run Extension Method
    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("Middleware3: Incoming Request handled and response generated\n");
        //Terminal Middleware Component i.e. cannot call the Next Component
    });

    //app.Run();
}
