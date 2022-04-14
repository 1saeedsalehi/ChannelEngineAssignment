﻿using AutoMapper;
using ChannelEngine.Core;
using ChannelEngine.Services;
using ChannelEngine.Services.HttpClients;
using ChannelEngine.Services.Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ChannelEngine.Api;

public class Startup
{

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        Environment = env;
    }

    public IConfiguration Configuration { get; }

    public IWebHostEnvironment Environment { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        Console.WriteLine(Environment.EnvironmentName);

        // ASP.NET Core & 3rd parties
        services.AddControllers();
        services.AddCors();
        services.AddHttpContextAccessor();
        services.AddAutoMapper(typeof(DefaultMappingProfile).Assembly);
        services.AddHealthChecks();

        services.AddHttpContextAccessor();

        services.AddApiVersioning(setup =>
        {
            setup.DefaultApiVersion = new ApiVersion(1, 0);
            setup.AssumeDefaultVersionWhenUnspecified = true;
            setup.ReportApiVersions = true;
        });

        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });

        

        // Swagger
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(AppConsts.ApiVersion, new() { Title = AppConsts.ApiTitle, Version = AppConsts.ApiVersion });

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var commentsFileName = $"{AppDomain.CurrentDomain.FriendlyName}.Xml";
            var commentsFile = Path.Combine(baseDirectory, commentsFileName);
            if (File.Exists(commentsFile))
            {
                options.IncludeXmlComments(commentsFile);
            }
        });



        //Adds services required for using options.
        services.AddOptions();
        services.AddCors();
        

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddSingleton(Configuration);
        services.Configure<Settings>(Configuration);


        //Register Services in DI
        services.AddTransient<OrderService>();

        services.AddHttpClient<OrderHttpClient>(client =>
        {
            client.BaseAddress = new Uri(Configuration["ChannelEngine:BaseUrl"]);
        });

    }

    public void Configure(IApplicationBuilder app,
        IWebHostEnvironment env,
        IMapper mapper,
        IApiVersionDescriptionProvider provider)
    {

        mapper.ConfigurationProvider.AssertConfigurationIsValid();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }


        app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResultStatusCodes =
                {
                        [Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Healthy] = StatusCodes.Status200OK,
                        [Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded] = StatusCodes.Status503ServiceUnavailable,
                        [Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                }
            });

        });


        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        });

    }
}
