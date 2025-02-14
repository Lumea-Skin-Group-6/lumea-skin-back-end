using BusinessObject;
using DAL.DBContext;
using DAL.DTO.ShiftDTO;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Repository;
using Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
var shiftEntity = modelBuilder.EntitySet<ShiftResponseDTO>("Shifts").EntityType;
shiftEntity.HasKey(a => a.Name);

builder.Services.AddControllers().AddOData(
    option => option.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null)
    .AddRouteComponents(
        routePrefix: "odata",
        model: modelBuilder.GetEdmModel())
    );

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    }); ;

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IShiftRepository, ShiftRepository>();
builder.Services.AddScoped<IShiftService, ShiftService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
