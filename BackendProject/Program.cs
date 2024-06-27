using BackendProject.DependencyInjection;
using BackendProject.Shared.Exceptions.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerConfigs(builder.Configuration);
builder.Services.AddDataBaseConfigs(builder.Configuration);
builder.Services.AddAPIClients(builder.Configuration);
builder.Services.AddMassTransit();
builder.Services.AddMediatr();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAbstractComponents();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AnotherPolicy",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var descriptions = app.DescribeApiVersions();

    foreach (var description in descriptions)
    {
        var url = $"/swagger/{description.GroupName}/swagger.json";
        var name = description.GroupName.ToUpperInvariant();
        options.SwaggerEndpoint(url, name);
    }
});


app.UseHttpsRedirection();
app.UseCors();
app.UseStaticFiles();
app.UseMiddleware<ErrorMiddleWare>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();