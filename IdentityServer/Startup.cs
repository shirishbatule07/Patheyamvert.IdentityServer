using IdentityServer.Services;
using IdentityServer.Storage.Data;
using IdentityServer.Storage.Models;
using IdentityServer4.Configuration;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using IdentityServer.Storage;

namespace IdentityServer
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSingleton(Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            

            services.AddMvc();
            services.AddHttpContextAccessor();
            services.AddCors(core => core.AddPolicy("CORSPolicy", b =>
            {
                b.AllowAnyOrigin();
                b.AllowAnyMethod();
                b.AllowAnyHeader();
            }));

            services.AddScoped<IPasswordHasher<ApplicationUser>, CryptoGraphy>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddAspNetUserStore<ApplicationUser>()
                .AddDefaultTokenProviders();
            services.AddTransient<IRoleStore<IdentityRole>, RoleStore>();

            IIdentityServerBuilder builder = services.AddIdentityServer(options =>
            {
                //TODO: add custom serilog sink? http://docs.identityserver.io/en/release/topics/events.html#custom-sinks
                options.Events = new EventsOptions
                {
                    RaiseErrorEvents = true,
                    RaiseFailureEvents = true,
                    RaiseInformationEvents = true,
                    RaiseSuccessEvents = true
                };

                options.Endpoints = new EndpointsOptions
                {
                    EnableCheckSessionEndpoint = false
                };
            })
                .AddInMemoryIdentityResources(Configuration?.GetSection("IdentityServer:IdentityResources"))
                .AddInMemoryApiResources(Configuration?.GetSection("IdentityServer:ApiResources"))
                .AddInMemoryClients(Configuration?.GetSection("IdentityServer:Clients"))
                .AddAspNetIdentity<ApplicationUser>()
                .AddProfileService<ProfileService>()
                .AddValidationKey(Configuration.GetSection("Certificates:ValidationKeyCertificateDistinguishedName").Value)
                .AddSigningCredential(Configuration.GetSection("Certificates:SigningCredentialCertificateDistinguishedName").Value);

            services.AddTransient<IProfileService, ProfileService>();

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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseIdentity();
            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvcWithDefaultRoute();
        }
    }
}
