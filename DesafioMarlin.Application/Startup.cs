using DesafioMarlin.Infraestructure.Data.Context;
using DesafioMarlin.Infraestructure.Data.Interfaces;
using DesafioMarlin.Infraestructure.Data.Respositories;
using DesafioMarlin.Service.Interfaces;
using DesafioMarlin.Service.Services;
using DesafioMarlin.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace DesafioMarlin.Application
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

            services.AddControllers();

            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Secret").ToString());
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });


            services.AddDbContext<SqlServerContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

            services.AddTransient<IHashService, HashService>();
            services.AddTransient<ITokenService, TokenService>();

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IAlunoRepository, AlunoRepository>();
            services.AddTransient<ITurmaRepository, TurmaRepository>();

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IAlunoService, AlunoService>();
            services.AddTransient<ITurmaService, TurmaService>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesafioMarlin.Application", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = " Insira Bearer [espaço] e logo depois o token JWT no campo abaixo."
                });
                
                c.AddSecurityRequirement(new OpenApiSecurityRequirement 
                { 
                    {
                        new OpenApiSecurityScheme 
                        { 
                            Reference = new OpenApiReference 
                            { 
                                Type = ReferenceType.SecurityScheme, 
                                Id = "Bearer" 
                            } 
                        }, 
                        new string[] {} 
                    } 
                }); 

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DesafioMarlin.Application v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
