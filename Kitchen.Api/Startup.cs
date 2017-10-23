using System.Text;
using AutoMapper;
using Kitchen.CommonModel.DataModel;
using Kitchen.CommonModel.Identity;
using Kitchen.CoreService.Service;
using Kitchen.Data;
using Kitchen.DesignControlAspect;
using Kitchen.Repository.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;


namespace Kitchen.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddSingleton(Configuration);
            services.AddDbContext<ControlContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"),
                t => t.MigrationsAssembly("Kitchen.Api")));
            services.AddDbContext<MainContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"),
                t => t.MigrationsAssembly("Kitchen.Api")));


            services.AddAutoMapper(typeof(Kitchen.CommonModel.AutoMapperConfiguration.Config));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ControlContext>();
            services.AddAuthorization();
            
            //services.Configure<IdentityOptions>(config =>
            //{
            //    config.Cookies.ApplicationCookie.Events =
            //      new CookieAuthenticationEvents()
            //      {
            //          OnRedirectToLogin = (ctx) =>
            //          {
            //              if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
            //              {
            //                  ctx.Response.StatusCode = 401;
            //              }

            //              return Task.CompletedTask;
            //          },
            //          OnRedirectToAccessDenied = (ctx) =>
            //          {
            //              if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
            //              {
            //                  ctx.Response.StatusCode = 403;
            //              }

            //              return Task.CompletedTask;
            //          }
            //      };
            //});

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    //options.Authority = "ieisys.com";
                    //options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        ValidAudience = Configuration["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["Tokens:Issuer"]
                    };
                });
            //ValidIssuer = Configuration["Tokens:Issuer"],
            //        ValidAudience = Configuration["Tokens:Audience"],
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
            //        ValidateLifetime = true

            //services.AddScoped<IMongoClient, MongoClient>();
            //services.AddScoped<MDBMongoConnectionSetting, MDBMongoConnectionSetting>();

            //services.AddScoped<MDBArticleCommentRepository<MDBArticleComment>, MDBArticleCommentRepository<MDBArticleComment>>();
            //services.AddScoped<MDBItemRatingRepository<MDBItemRating>, MDBItemRatingRepository<MDBItemRating>>();




            //services.AddScoped<MDBArticleCommentService<MDBArticleComment>, MDBArticleCommentService<MDBArticleComment>>();
            //services.AddScoped<MDBItemRatingService, MDBItemRatingService>();



            services.AddScoped<ProfileRepository, ProfileRepository>();
            services.AddScoped<RecipeRepository, RecipeRepository>();
            services.AddScoped<IngredientRepository, IngredientRepository>();
            //services.AddScoped<AddressRepository, AddressRepository>();


            services.AddScoped<ProfileService, ProfileService>();
            services.AddScoped<RecipeService, RecipeService>();
            services.AddScoped<IngredientService, IngredientService>();
            //services.AddScoped<ItemRepository, ItemRepository>();
            //services.AddScoped<ItemService, ItemService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            //app.UseIdentity();
            app.UseAuthentication();
            //app.UseJwtBearerAuthentication(new JwtBearerOptions()
            //{
                
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true,
            //    TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidIssuer = Configuration["Tokens:Issuer"],
            //        ValidAudience = Configuration["Tokens:Audience"],
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
            //        ValidateLifetime = true
            //    }
            //});
            app.UseStaticFiles();
            app.UseMvc();

            // seed
            //DbInitializer.Initialize(context);
        }
    }
}
