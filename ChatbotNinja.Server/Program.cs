using ChatbotNinja.Application.Services;
using ChatbotNinja.Core.IRepositories;
using ChatbotNinja.DataAccess.Repositories;
using ChatbotNinja.DataAccess;
using Microsoft.EntityFrameworkCore;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);


    // Add services to the container.
    builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );


    //// angular configuration
    builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
                             builder => builder.AllowAnyOrigin()
                                               .AllowAnyHeader()
                                               .AllowAnyMethod()));


    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // automapper
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // Add services to the container.
    builder.Services.AddScoped<ICharactersService, CharactersService>();
    builder.Services.AddScoped<IPersonalitiesService, PersonalitiesService>();


    // repositories
    builder.Services.AddScoped<ICharactersRepository, CharactersRepository>();
    builder.Services.AddScoped<IPersonalitiesRepository, PersonalitiesRepository>();



    var app = builder.Build();

    app.UseDefaultFiles();
    app.UseStaticFiles();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
     

        app.UseSwagger();
        app.UseSwaggerUI();
    }



    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.MapFallbackToFile("/index.html");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
