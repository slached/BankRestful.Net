using hangi_kredi_restful.Data;
using hangi_kredi_restful.Mapping;
using hangi_kredi_restful.Repository;
using hangi_kredi_restful.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// db connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// rabbitmq connection
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});



// Add services and repository to the dependency container.
/*
| `AddScoped`    | Genellikle web uygulamalarýnda kullanýlýr. Her HTTP request için bir instance.    |
| `AddSingleton` | Uygulama ömrü boyunca bir kere oluþturulur.                                       |
| `AddTransient` | Her ihtiyaç duyulduðunda (her injection'da) yeniden oluþturulur.                  |
 */
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<ILoanService, LoanService>();

builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();

// Auto mapper for bank entities and DTOs
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
