var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();



var app = builder.Build();

app.UseCors(options =>
{
  options.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader();
});

app.MapOpenApi();
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
