using Microsoft.EntityFrameworkCore;
using PeabuxAssessment.Data;
using PeabuxAssessment.Implementation;
using PeabuxAssessment.Interface;

namespace PeabuxAssessment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<AppDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DBConn")));
            
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.WithOrigins().AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true)
                   .AllowCredentials().Build();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowCredentials()
                .AllowAnyMethod());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}