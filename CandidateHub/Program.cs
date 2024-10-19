using CandidateHub.Core.Entities;
using CandidateHub.Core.Mapper;
using CandidateHub.Core.Repository.Interfaces;
using CandidateHub.Infrastructure.Repository.Implementations;
using CandidateHub.Logging;
using CandidateHub.Middleware;
using CandidateHub.SeedData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CandidateContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("CandidateConnection"), b => b.MigrationsAssembly("CandidateHub.Infrastructure"));
    // options.ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning));
});

RegisterServices(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
SeedDatabase();
app.Run(); 
void RegisterServices(IServiceCollection services)
{
    // Register your services here
    services.Scan(scan => scan
        .FromAssembliesOf(typeof(IBaseRepository<>), typeof(BaseRepository<>), typeof(ISeriLogger))
        .AddClasses()
        .AsSelf()
        .AsImplementedInterfaces()
        .WithScopedLifetime());
    services.AddScoped<ApplicationDbInitializer>();
    services.AddAutoMapper(typeof(AutoMapperProfiles));
}
void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<ApplicationDbInitializer>();
        dbInitializer.Initialize();
    }
}