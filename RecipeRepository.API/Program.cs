using Microsoft.EntityFrameworkCore;
using RecipeRepository.API.Data;
using RecipeRepository.API.Repositories.Implementation;
using RecipeRepository.API.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inject DbContext to communicate with the controllers or repositories
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    //use the connection string name from appsetting.json file
    options.UseSqlServer(builder.Configuration.GetConnectionString("RecipeRepositoryConnectionString"));
});

//inject repository interface and implementation  
builder.Services.AddScoped<IMealCategoryRepository, MealCategoryRepository>();
builder.Services.AddScoped<IAllergenCategoryRepository, AllergenCategoryRepository>();
builder.Services.AddScoped<IRecipeDetailsRepository, RecipeDetailsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
