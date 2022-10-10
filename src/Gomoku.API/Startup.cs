using FluentValidation;
using FluentValidation.AspNetCore;
using Gomoku.Domain;
using Gomoku.Domain.Chains;
using Gomoku.Domain.Players;
using Gomoku.Domain.Repositories;
using Gomoku.Infrastructure;
using Gomoku.Middleware;
using Gomoku.Pipeline.Handlers;
using Gomoku.Pipeline.Handlers.PlaceStone;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


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
            services.AddSingleton<IPlayer1, Player1>();
            services.AddSingleton<IPlayer2, Player2>();
            services.AddTransient<IHorizontalChain, HorizontalChain>();
            services.AddTransient<IVerticalChain, VerticalChain>();
            services.AddTransient<IForwardDiagonalChain, ForwardDiagonalChain>();
            services.AddTransient<IBackwardDiagonalChain, BackwardDiagonalChain>();

            // Register Infrastructure
            services.AddTransient<IChainRepo, ChainRepo>();
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
