using Microsoft.EntityFrameworkCore;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using CVBuilder.Services.Implementations;
using CVBuilder.Services;

namespace CVBuilder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddScoped<ITemplateService, TemplateService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ISkillService, SkillService>();
            builder.Services.AddScoped<ILanguageService, LanguageService>();
            builder.Services.AddScoped<IEducationService, EducationService>();
            builder.Services.AddScoped<IPersonalInfoService, PersonalInfoService>();
            builder.Services.AddScoped<ICertificateService, CertificateService>();
            //builder.Services.AddScoped<IResumeService, ResumeService>();
            builder.Services.AddScoped<IWorkExperienceService, WorkExperienceService>();
            builder.Services.AddScoped<IRegisterUser, RegisterUser>();

            builder.Services.AddControllers();

            builder.Services.AddDbContext<CvdatabaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn"));
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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