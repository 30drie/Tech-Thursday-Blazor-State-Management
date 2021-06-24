using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRazorPages();
			services.AddServerSideBlazor();

			/*

			https://docs.microsoft.com/en-us/dotnet/core/compatibility/aspnet-core/5.0/blazor-protectedbrowserstorage-moved

			If upgrading from ASP.NET Core 5.0 RC1, complete the following steps:

			Remove the Microsoft.AspNetCore.Components.ProtectedBrowserStorage package reference from the project.
			Replace using Microsoft.AspNetCore.Components.ProtectedBrowserStorage; with using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;.
			Remove the call to AddProtectedBrowserStorage from your Startup class.


			If upgrading from ASP.NET Core 5.0 Preview 8, complete the following steps:

			Remove the Microsoft.AspNetCore.Components.Web.Extensions package reference from the project.
			Replace using Microsoft.AspNetCore.Components.Web.Extensions; with using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;.
			Remove the call to AddProtectedBrowserStorage from your Startup class.

			*/
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapBlazorHub();
				endpoints.MapFallbackToPage("/_Host");
			});
		}
	}
}
