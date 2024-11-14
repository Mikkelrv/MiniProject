using ThriftShopAPI.Controllers;
using ThriftShopAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var serviceCollection = new ServiceCollection();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserRepo, UserRepo>();
builder.Services.AddSingleton<IItemsRepo, ItemsRepo>();
builder.Services.AddSingleton<IImgurRepo, ImgurRepo>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddHttpClient<IImgurRepo, ImgurRepo>();




var configuration = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json")
	.Build();
serviceCollection.AddSingleton<IConfiguration>(configuration);


var app = builder.Build();
app.UseCors("AllowBlazorApp");

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
