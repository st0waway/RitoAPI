using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using RitoAPI.Middleware;
using RitoAPI.Models;
using RitoAPI.Services;
using Serilog;

namespace RitoAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IConfiguration _configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			// Register the Swagger generator, defining 1 or more Swagger documents
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
				//Resolve conflicting paths.
				//c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
			});

			var userConfig = _configuration.GetSection("UserConfig");
			services.Configure<UserConfig>(userConfig);
			services.AddSingleton<SummonerService>();
			services.AddSingleton<ChampionService>();
			services.AddSingleton<ChampionMasteryService>();
			services.AddSingleton<LeagueExpService>();
			services.AddSingleton<SpectatorService>();
			services.AddSingleton<MatchService>();
			services.AddSingleton<LolRankedService>();
			services.AddSingleton<LolStatusService>();
			services.AddSingleton<ClashService>();
			services.AddSingleton<AccountService>();
			services.AddSingleton<LastMatchesService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseDeveloperExceptionPage();

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
			// specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			app.UseRequestResponseLogging();

			app.UseHttpsRedirection();

			app.UseSerilogRequestLogging();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
