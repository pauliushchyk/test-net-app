using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using testnetapp.Data;
using testnetapp.Data.Interfaces.Repositories;
using testnetapp.Data.Interfaces.Services;
using testnetapp.Data.Models;
using testnetapp.Data.Repositories;
using testnetapp.Data.Services;

namespace test_net_app
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<ApplicationContext>(options =>
                {
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
                }, ServiceLifetime.Scoped);

            services.AddScoped<IRepository<Book>, Repository<Book>>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            services.AddScoped<IService<Book>, Service<Book>>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ITagService, TagService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
