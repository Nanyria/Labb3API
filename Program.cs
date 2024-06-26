using AutoMapper;
using Labb3API.Data;
using Labb3API.Services;
using Microsoft.EntityFrameworkCore;
using SUT23TeknikButikModels;
using SUT23TeknikButikModels.Connections;

namespace Labb3API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.
                Serialization.ReferenceHandler.IgnoreCycles;
            });

            //builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IPersonAndInterests<InterestDto>, InterestRepository>();
            builder.Services.AddScoped<IPersonAndInterests<PersonDto>, PersonRepository>();
            builder.Services.AddScoped<IPersonAndInterests<LinkDto>, LinkRepo>();
            builder.Services.AddScoped<ICombinationTables<PersonInterests>, PersonalInterestRepository>();
            builder.Services.AddScoped<ICombinationTables<InterestLinks>, InterestLinksRepo>();
            
            //EF till SQL
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(typeof(MappingProfile));
            var app = builder.Build();

            var mapper = app.Services.GetRequiredService<IMapper>();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();






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
        }
    }
}
