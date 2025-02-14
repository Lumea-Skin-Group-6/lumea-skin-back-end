using BusinessObject;
using DAL.DBContext;
using DAL.DTO.Expertise;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<ExpertiseDTO>("Expertises");

builder.Services.AddControllers().AddOData(options =>
    options.Select().Filter().OrderBy()
    .Expand().Count().SetMaxTop(null)
    .AddRouteComponents("odata", modelBuilder.GetEdmModel()));

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExpertiseRepository, ExpertiseRepository>();
builder.Services.AddScoped<IExpertiseService, ExpertiseService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
