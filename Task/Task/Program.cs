using IRepo;
using Repo.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IRepo Services
builder.Services.AddSingleton<IItemIRepo, ItemRepo>();
builder.Services.AddSingleton<IBranchIRepo, BranchRepo>();
builder.Services.AddSingleton<IProductionIRepo, ProductionRepo>();
builder.Services.AddSingleton<IDistributionIRepo, DistributionRepo>();
builder.Services.AddScoped<ICompanyIRepo, CompanyRepo>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
