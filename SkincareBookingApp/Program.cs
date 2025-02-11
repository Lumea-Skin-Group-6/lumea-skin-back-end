using DAL.DBContext;
using Microsoft.OpenApi.Models;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

//Configure Scoped
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddControllers();
//End

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Skincare Booking API", Version = "v1" });
    c.TagActionsBy(api => new[] { api.GroupName });
    c.DocInclusionPredicate((name, api) => true);
});


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