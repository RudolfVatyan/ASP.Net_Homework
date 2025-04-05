using ASP.Net_Homework.Repositories.Interfaces;
using ASP.Net_Homework.Repositories.Services;   

namespace ASP.Net_Homework
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
            builder.Services.AddHttpClient();
            builder.Services.Configure<PostsApiSettings>(builder.Configuration.GetSection("PostsApiSettings"));
            builder.Services.Configure<UsersApiSettings>(builder.Configuration.GetSection("UsersApiSettings"));
            builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            builder.Services.AddScoped<IPostRepository, PostService>();
            builder.Services.AddScoped<IUserRepository, UserService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
           
            app.UseSwagger();
            app.UseSwaggerUI();
           

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
