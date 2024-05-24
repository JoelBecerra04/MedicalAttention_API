using MedicalAttention_API.Repository;
using MedicalAttention_API.Repository.IRepository;
using Npgsql;
using System.Data;


namespace MedicalAttention_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IDbConnection>((sp) =>
                    new NpgsqlConnection(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<IPayerRepository, PayerRepository>();
            services.AddScoped<IPatientDetailRepository, PatientDetailRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoins =>
            {
                endpoins.MapControllers();
            });

        }

    }
}
