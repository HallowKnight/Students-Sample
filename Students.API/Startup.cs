using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Students.Application.Lessons.Commands.CreateLesson;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.AggregatesModel.RoleAggregate;
using Students.Domain.AggregatesModel.SchoolAggregate;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;
using Students.Domain.Events;
using Students.Infrastructure.Persistence.DBContext;
using Students.Infrastructure.Persistence.UnitOfWork;
using Students.Infrastructure.Repository.Lessons.Commands;
using Students.Infrastructure.Repository.Lessons.Queries;
using Students.Infrastructure.Repository.Roles.Commnds;
using Students.Infrastructure.Repository.Roles.Queries;
using Students.Infrastructure.Repository.Schools.Commands;
using Students.Infrastructure.Repository.Schools.Queries;
using Students.Infrastructure.Repository.Users.Commands;
using Students.Infrastructure.Repository.Users.Queries;
using Students.Presentation.Hubs;

namespace Students.Presentation
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
            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            //     .AddJsonOptions(options=>options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize);

            services.AddMvc()
                .AddMvcOptions(options => options.EnableEndpointRouting = false);
            
            services.AddSignalR();
            
            
            
            services.AddDbContext<StudentsDbContext>(options=>
            {
                options.UseSqlServer(Configuration.GetConnectionString("StudentsConnection"));
            });
            services.AddMediatR(typeof(CreateLessonCommand).GetTypeInfo().Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            
            services.AddTransient<ILessonQueries, LessonQueries>();
            services.AddTransient<ILessonCommands, LessonCommands>();
            
            services.AddTransient<IUserQueries, UserQueries>();
            services.AddTransient<IUserCommands, UserCommands>();

            services.AddTransient<IRoleCommands, RoleCommands>();
            services.AddTransient<IRoleQueries, RoleQueries>();

            services.AddTransient<ISchoolQueries,SchoolQueries>();
            services.AddTransient<ISchoolCommands, SchoolCommands>();
            
            
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

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
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json0", "Student Api");
            });
            
            
        }
    }
}
