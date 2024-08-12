
using Assessment5.Entities;
using Assessment5.Repositories;

namespace Assessment5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<PODbContext>();
            builder.Services.AddTransient < ISupplierAsyncRepository, SupplierAsyncRepository > ();
            builder.Services.AddTransient < IItemAsyncRepository, ItemAsyncRepository > ();
            builder.Services.AddTransient < IPOMasterAsyncRepository, POMasterAsyncRepository > ();

            builder.Services.AddControllers();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
