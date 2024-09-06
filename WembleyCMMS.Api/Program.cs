using Microsoft.IdentityModel.Tokens;
using WembleyCMMS.Domain.SeedWork;
using WembleyCMMS.Infrastructure;
using WembleyCMMS.Api.Application.Mapping;
using WembleyCMMS.Infrastructure.Repositories;
using WembleyCMMS.Domain.AggregateModels.PersonAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Domain.AggregateModels.TimeSeriesObjectAggregate;
using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;
using WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate;
using WembleyCMMS.Domain.AggregateModels.InspectionReportAggregate;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .WithOrigins("localhost", "http://localhost:5173", "https://web-thaiduong-mes.vercel.app", "https://web-wembley-mes.vercel.app")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{   
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("WembleyCMMS.Api"));
    options.EnableSensitiveDataLogging();
}); 
    
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = builder.Configuration.GetValue("Authority", "");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(typeof(ModelToViewModelProfile));
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<ModelToViewModelProfile>();
    cfg.RegisterServicesFromAssemblyContaining<ApplicationDbContext>();
    cfg.RegisterServicesFromAssemblyContaining<Entity>();
});

builder.Services.AddScoped<IEquipmentClassRepository, EquipmentClassRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IMaintenanceRequestRepository, MaintenanceRequestRepository>();
builder.Services.AddScoped<IMaterialInforRepository, MaterialInforRepository>();
builder.Services.AddScoped<ICauseRepository, CauseRepository>();
builder.Services.AddScoped<ICorrectionRepository, CorrectionRepository>();
builder.Services.AddScoped<IMaintenanceResponseRepository, MaintenanceResponseRepository>();
builder.Services.AddScoped<IEquipmentMaterialRepository, EquipmentMaterialRepository>();
builder.Services.AddScoped<ITimeSeriesObjectRepository, TimeSeriesObjectRepository>();
builder.Services.AddScoped<IPerformanceIndexRepository, PerformanceIndexRepository>();
builder.Services.AddScoped<IWorkingTimeRepository, WorkingTimeRepository>();
builder.Services.AddScoped<IInspectionReportRepository, InspectionReportRepository>();

var app = builder.Build();

app.UseCors("AllowAll");

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
