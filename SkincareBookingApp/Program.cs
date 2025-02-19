using DAL.DBContext;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Service;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using Service.Services;
using SkincareBookingApp.Helpers;
using DAL.DTOs.ResponseModel;

var builder = WebApplication.CreateBuilder(args);
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<ExpertiseResponseModel>("Expertises");
modelBuilder.EntitySet<ServiceResponseModel>("Services");

builder.Services.AddControllers().AddOData(options =>
    options.Select().Filter().OrderBy()
        .Expand().Count().SetMaxTop(null)
        .AddRouteComponents("odata", modelBuilder.GetEdmModel()));

var shiftEntity = modelBuilder.EntitySet<ShiftResponseDTO>("Shifts").EntityType;
shiftEntity.HasKey(a => a.Name);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });


//Configure Scoped
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IShiftRepository, ShiftRepository>();
builder.Services.AddScoped<IExpertiseService, ExpertiseService>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IExpertiseRepository, ExpertiseRepository>();
builder.Services.AddScoped<IExpertiseService, ExpertiseService>();

builder.Services.AddScoped<IShiftService, ShiftService>();

builder.Services.AddScoped<ISlotRepository, SlotRepository>();
builder.Services.AddScoped<ISlotService, SlotService>();



//builder.Services.AddSingleton(new RedisCacheService(builder.Configuration["Redis:ConnectionString"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .ToDictionary(
                    e => e.Key,
                    e => e.Value.Errors.Select(error => error.ErrorMessage).ToArray()
                );

            var response = new
            {
                http_status = StatusCodes.Status400BadRequest,
                time_stamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                message = "Validation Error",
                errors
            };

            return new BadRequestObjectResult(response);
        };
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition =
            System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });
//End

builder.Services.AddDbContext<AppDbContext>();
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Skincare Booking API", Version = "v1" });
    c.TagActionsBy(api => new[] { api.GroupName });
    c.DocInclusionPredicate((name, api) => true);
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });

    c.OperationFilter<AddAuthHeaderOperationFilter>();
});


var app = builder.Build();
app.UseExceptionHandler(_ => { });

app.UseRouting();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors(options =>
    options.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod());
app.Run();
