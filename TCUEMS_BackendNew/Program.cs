using Microsoft.OpenApi.Models;
using System.Data.SqlClient;
using System.Data;
using TCUEMS_BackendNew.Data;
using TCUEMS_BackendNew.Models;

var builder = WebApplication.CreateBuilder(args);

// Ū�� CORS �]�w
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var corsSettings = builder.Configuration.GetSection("CorsSettings").Get<CorsSettings>();

// ��Ʈw�s�u�r��
var connectionString = "Data Source=.;Initial Catalog=SemesterWarning;Integrated Security=true;";

builder.Services.AddScoped<IDbConnection>(c => new SqlConnection(connectionString));
builder.Services.AddTransient<ISemesterWarningRepository, SemesterWarningRepository>(provider =>
    new SemesterWarningRepository(provider.GetRequiredService<IDbConnection>().ConnectionString));

builder.Services.AddLogging(); // �K�[�o�@��H�ҥΤ�x

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Semester Warning API"));
}

// �B�z CORS ���D
app.UseCors(builder => builder.WithOrigins(corsSettings?.AllowedOrigins)
                              .AllowAnyHeader()
                              .AllowAnyMethod());

app.UseAuthorization();

app.UseMiddleware<LoggingMiddleware>();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
