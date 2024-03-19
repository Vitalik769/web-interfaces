using SwaggerTest.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title  = "New Swagger",
            Description =  "New Swagger Document",
            Version = "v1"
        });
});
// AddSingleton registers a service for a container of deposits as one single instance throughout the entire life cycle of the application
builder.Services.AddSingleton<IUserTestService, UserTestService>();

builder.Services.AddSingleton<ITaskTestService, TaskTestService>();

builder.Services.AddSingleton<IQuoteTestService, QuoteTestService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
    options.DocumentTitle = "My Swagger";
});

app.Run();
