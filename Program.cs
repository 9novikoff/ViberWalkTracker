using ViberWalkTracker.DAL;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ViberWalkTracker.BLL;

namespace ViberWalkTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<WalkContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<WalkRepository>();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddTransient(s =>
                new WalkService(s.GetRequiredService<WalkRepository>(), s.GetRequiredService<IMapper>()));

            builder.Services.AddControllers();

            var app = builder.Build();


            app.UseHttpsRedirection();

            app.MapControllers();


            app.Run();
        }
    }
}