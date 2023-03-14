using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Students.Domain.Common;
using Students.Infrastructure.Persistence.DBContext;
using Students.Infrastructure.Persistence.UnitOfWork;
using Students.Presentation.Common.Hubs;

namespace Students.Presentation;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        #region Mvc Options

        services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize);

        services.AddMvc()
            .AddMvcOptions(options => options.EnableEndpointRouting = false);

        #endregion

        #region Context Options

        services.AddDbContext<StudentsDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("StudentsConnection"));
        });

        #endregion

        #region Options

        services.AddSignalR();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddSwaggerGen();
        //Todo: Add MassTransit

        #endregion

        #region DI

        services.AddTransient<IUnitOfWork, UnitOfWork>();

        #endregion
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();

        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();
        else
            app.UseHsts();

        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapHub<UsersListHub>("/usersListHub");
        });


        app.UseMvc(routes =>
        {
            routes.MapRoute(
                "Default", "{controller=UsersList}/{action=Index}"
            );
        });

        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json0", "Student Api"); });
    }
}