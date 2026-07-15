using Agriculture.Persistence;
using Agriculture.Application;
using DotNetEnv;
using Microsoft.OpenApi.Models;

Env.Load();

// Tìm file .env từ thư mục hiện tại, leo dần lên thư mục cha
// → hoạt động dù chạy từ VS (bin/Debug/...) hay dotnet run (src/Restaurant.API/)
var searchDir = Directory.GetCurrentDirectory();
while (searchDir is not null)
{
    var envPath = Path.Combine(searchDir, ".env");
    if (File.Exists(envPath)) { Env.Load(envPath); break; }
    searchDir = Directory.GetParent(searchDir)?.FullName;
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant API", Version = "v1" });

    // Cấu hình nút Authorize cho Swagger UI
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Nhập 'Bearer [space] token_của_bạn' vào ô bên dưới.\r\n\r\nVí dụ: 'Bearer eyJhbGci...'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/api/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
{
    var endpoints = endpointSources.SelectMany(es => es.Endpoints);
    return endpoints.OfType<RouteEndpoint>().Select(e => new
    {
        Method = e.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault()?.HttpMethods.FirstOrDefault(),
        Route = e.RoutePattern.RawText
    });
});

app.MapControllers();

app.Run();
