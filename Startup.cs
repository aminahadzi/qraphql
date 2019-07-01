using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dwsGraph.Models;
using dwsGraph.Mutations;
using dwsGraph.Queries;
using dwsGraph.Repositories;
using dwsGraph.Schema;
using dwsGraph.Types;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace dwsGraph
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
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer("Server=DESKTOP-OVG7VB9;Database=Library;Trusted_Connection=True;"));


            services.AddTransient<IBookRepository, BookRepository>();
            services.AddSingleton<BookQuery>();
            services.AddSingleton<BookMutation>();
            services.AddSingleton<BookType>();
            services.AddSingleton<BookInputType>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new BookSchema(new FuncDependencyResolver(type => sp.GetService(type))));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            app.UseGraphiQl("/graphql");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
