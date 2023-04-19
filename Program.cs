using ViberWalkTracker.DAL;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ViberWalkTracker.BLL;
using Newtonsoft.Json;
using ViberWalkTracker.ViberModels;
using Microsoft.AspNetCore.Routing.Tree;
using ViberWalkTracker.ViberModels.DeliveryModels;
using System.Reflection;

namespace ViberWalkTracker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<WalkContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddTransient<ViberApiService>();

            builder.Services.AddTransient<WalkRepository>();

            builder.Services.AddTransient(s =>
                new WalkService(s.GetRequiredService<WalkRepository>(), s.GetRequiredService<IMapper>()));

            builder.Services.AddTransient<UserRepository>();

            builder.Services.AddTransient(s =>
                new UserService(s.GetRequiredService<UserRepository>()));

            builder.Services.AddControllers();

            var app = builder.Build();


            app.UseHttpsRedirection();

            app.MapControllers();


            app.Run();

        }
    }
}