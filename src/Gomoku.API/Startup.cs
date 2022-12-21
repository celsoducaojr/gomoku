using FluentValidation;
using Gomoku.Domain;
using Gomoku.Domain.ChainPatterns;
using Gomoku.Domain.IRepositories;
using Gomoku.Domain.Players;
using Gomoku.Infrastructure.Repositories;
using Gomoku.Middleware;
using Gomoku.Pipeline.Handlers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;


namespace Gomoku
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(
                 options =>
                 {
                     options.JsonSerializerOptions.PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance;
                 }); 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gomoku", Version = "v1" });
            });

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Register Domains
            services.AddSingleton<IBoard, Board>();
            services.AddTransient<Game>();
            services.AddTransient<IPlayer1, Player1>();
            services.AddTransient<IPlayer2, Player2>();
            services.AddTransient<IHorizontalChainPattern, HorizontalChainPattern>();
            services.AddTransient<IVerticalChainPattern, VerticalChainPattern>();
            services.AddTransient<IForwardDiagonalChainPattern, ForwardDiagonalChainPattern>();
            services.AddTransient<IBackwardDiagonalChainPattern, BackwardDiagonalChainPattern>();

            // Register Infrastructure - database implementation example
            services.AddSingleton<IGameRepository, GameRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gomoku v1"));
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandling>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
