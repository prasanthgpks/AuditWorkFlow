using AuditWorkFlow.Razor.Repositories;
using AuditWorkFlow.Razor.Data;
using AuditWorkFlow.Razor.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AuditDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuditWf")));
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
