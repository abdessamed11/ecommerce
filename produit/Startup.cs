using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using produit.Data;
using produit.Helpers;
using produit.ModelAuth;
using produit.Repositorie;
using produit.services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace produit
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //readonly string MyAllowspicificorigin = "_MyAllowspicificorigin";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(o => o.UseSqlite("Data source=produit.db"));


            services.AddIdentity<User, IdentityRole>(conf =>
            {
                conf.Password.RequiredLength = 4;
                conf.Password.RequireUppercase = false;
                conf.Password.RequireNonAlphanumeric = false;
                conf.Password.RequiredUniqueChars = 0;
                conf.Password.RequireDigit = false;
                conf.SignIn.RequireConfirmedAccount = false;
                conf.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddScoped<ICatégorieRepository, CatégorieRepository>();
            services.AddScoped<IProduitRepository, ProduitRepository>();
            services.AddScoped<IPanierRepository, PanierRepository>();
            services.AddScoped<ICommandeRepository, CommandeRepository>();
            services.AddScoped<IImageRepository, ImageRepository>(); 
            services.AddScoped<IlistProduitRepository, ListProduitRepository>();



            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(
                     Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(c =>
                {
                    c.RequireHttpsMetadata = false;
                    c.SaveToken = false;
                    c.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                    };
                });

            services.Configure<JWT>(Configuration.GetSection("JWT"));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "produit", Version = "v1" });
            });

            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy",
                    builder => builder

                    .AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                    
                    
                    );
            });

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "produit v1"));
            }


            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
            //    RequestPath = new PathString("/StaticFiles")
            //});

           
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseCors("_MyAllowspicificorigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
