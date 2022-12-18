using CatalogService.API.Services;
using CatalogService.API.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddLogging();
builder.Services.AddControllers();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<IItemService, ItemService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfileService));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
