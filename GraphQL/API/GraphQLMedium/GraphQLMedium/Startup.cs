using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQLMedium.GraphQL.GraphTypes;
using GraphQLMedium.GraphQL.Queries;
using GraphQLMedium.GraphQL.Schema;
using GraphQLMedium.repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphQLMedium
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
            services.AddSingleton<IDependencyResolver>(s => new 
                FuncDependencyResolver(s.GetRequiredService));
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<ISchema, CustomerSchema>();
            services.AddSingleton<CustomerQuery>();
            services.AddSingleton<CustomerType>();  
            services.AddGraphQL();
            
            services.AddCors();

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseWebSockets();


            app.UseDeveloperExceptionPage();
            // add http for Schema at default url /graphql
            app.UseGraphQL<ISchema>("/graphql");
            // use graphql-playground at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground"
            });
        }
    }
}
