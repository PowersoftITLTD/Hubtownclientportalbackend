using HubTown_Client_Protal_Backend.Api;
using HubTown_Client_Protal_Backend.Api.Middlewares;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
{

    Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day) // Save logs to a file
    .CreateLogger();

    // Step 2: Use Serilog as the logging provider
    builder.Host.UseSerilog();

    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
    });
}


var app = builder.Build();
{
    app.UseExceptionHandler();

    app.UseSerilogRequestLogging();

    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "swagger"; // Make sure this matches your URL structure
    });

    app.UseCors("AllowAll");

    app.UseMiddleware<ResponseMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
