using AdventureWork.Entities;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication3.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<AdventureWorkContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("AdventureworkConnectionString"))
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("data Employee", async (AdventureWorkContext db) =>
{
    var Employee = db.Employee 
    .ToList();

   

    return Employee;


});
app.MapGet("data Department", async (AdventureWorkContext db) =>
{
    var department = db.Department
    .ToList();
    return department;


});
app.MapPost("update", async (AdventureWorkContext db) =>
{
    Employee employee= await db.Employee.FirstAsync(e => e.BusinessEntityID == 6);

    var rejectedState = await db.Employee.FirstAsync(a => a.JobTitle == "Senior Mechanical Engineer");

    await db.SaveChangesAsync();

    return employee;
});

app.MapPost("create", async (AdventureWorkContext db) =>
{
    var department = new Department()
    {
       Name = "Mechanical Engineering",
       GroupName = "Engineering3",
       ModifiedDate = DateTime.Now,

    };

    db.Department.Add(department);

    await db.SaveChangesAsync();

    return department;
});
app.MapDelete("delete", async (AdventureWorkContext db) =>
{
    var employee = await db.Employee
    .FirstAsync(u => u.BusinessEntityID==289);

    db.Employee.Remove(employee);

    await db.SaveChangesAsync();
});
app.Run();

