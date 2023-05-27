using Microsoft.EntityFrameworkCore;
using TWTask.Data;
using TWTask.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=TWTaskDb;Integrated Security=True;";
builder.Services.AddDbContext<TWTaskDbContext>(op => op.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(Program));

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
app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapRazorPages();
app.Run();
app.UseStaticFiles();