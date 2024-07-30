
using Microsoft.EntityFrameworkCore;
using NTierSchool.BLL.Interfaces;
using NTierSchool.BLL.Services;
using NTierSchool.DAL.Concrete;
using NTierSchool.DAL.Repositories;
using NTierSchool.Entity.Context;
using NTierSchool.Entity.Models;

namespace NTierSchool.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDB") + ";TrustServerCertificate=True"));

            // Repository ve Servisler için Dependency Injection (Baðýmlýlýk tanýmlamasý)
            builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(BaseService<>));
            builder.Services.AddScoped<IRepository<School>, GenericRepository<School>>();
            builder.Services.AddScoped<IRepository<Class>, GenericRepository<Class>>();
            builder.Services.AddScoped<IRepository<Teacher>, GenericRepository<Teacher>>();
            builder.Services.AddScoped<IRepository<Student>, GenericRepository<Student>>();
            //builder.Services.AddScoped<BaseService<School>>();
            //builder.Services.AddScoped<BaseService<Class>>();
            //builder.Services.AddScoped<BaseService<Teacher>>();
            builder.Services.AddScoped<BaseService<Student>>();

            builder.Services.AddScoped<IClassService, ClassService>();
            builder.Services.AddScoped<IClassRepository, ClassRepository>();

            builder.Services.AddScoped<ISchoolService, SchoolService>();
            builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();

            builder.Services.AddScoped<ITeacherService, TeacherService>();
            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

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
