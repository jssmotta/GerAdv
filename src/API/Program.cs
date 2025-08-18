using MenphisSI;
using MenphisSI.DB;
using MenphisSI.GerAdv.HealthCheck;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Web;
using System.Globalization;
using System.Security.Authentication;


var logger = MenphisSI.WebApi.BaseCommon.Helpers.ProgramNLog.ConfigureNLog();


try
{

    logger.Info("Iniciado WebApi");

    var builder = WebApplication.CreateBuilder(args);



    if (builder.Environment.IsDevelopment())
    {
        builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables(); 
    }
    else
    {
        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables(); ;
    }

    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


    //var uris = builder.Configuration["AppSettings:ValidUris"]?.ToString() ?? "";
    //if (uris.IsEmpty())
    //{
    //    throw new Exception("AppSettings:ValidUris não configurado");
    //}

    builder.Host.UseNLog();

    // Add services to the container.
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddScoped<IUserService, UserService>(); 

    //builder.Services.AddSingleton<MenphisSI.DB.ITokenService, TokenService>();

    builder.Services.AddResponseCompression(options =>
    {
        options.EnableForHttps = true;
        options.Providers.Add<BrotliCompressionProvider>();
        options.Providers.Add<GzipCompressionProvider>();
    });

    var settings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();

    MenphisSI.GerEntityTools.Apis.UriApi.InitializeConfiguration(builder.Configuration);
    MenphisSI.GerEntityTools.Helper.Token.InitializeConfiguration(builder.Configuration);

    MenphisSI.GerAdv.Services.AddServices.Add(builder);

    MenphisSI.GerAdv.Validations.AddServices.Add(builder);
    MenphisSI.GerAdv.Readers.AddServices.Add(builder);
    MenphisSI.GerAdv.Writers.AddServices.Add(builder);
    MenphisSI.GerAdv.Entity.AddServices.Add(builder);

    MenphisSI.GerAdv.Serialization.AddServices.Add(builder);

    // AppSettingsMediator.AddMediatorConfig(builder);
     
    AppSettingsHealthCheck.Add(builder); // Add HealthCheck
    AppSettingsHealthCheck.Add(builder, logger, settings); // Add HealthCheck
    //AppSettingsHealthCheck.AddHealthCheck(builder);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddApiVersioning(options =>
    {
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
    });

    builder.Services.AddAuthorization();
    builder.Services.AddMemoryCache();
    builder.Services.AddHybridCache();


    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ConfigureHttpsDefaults(httpsOptions =>
        {
            httpsOptions.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13;
        });
    });


    builder.Services.AddControllers()
       .AddJsonOptions(options =>
       {
           options.JsonSerializerOptions.PropertyNamingPolicy = null;
           options.JsonSerializerOptions.DictionaryKeyPolicy = null;
       });

    //builder.Services.AddCors(options =>
    //{
    //    options.AddPolicy("AllowSpecificOrigins",
    //        builder =>
    //        { 
    //            builder.WithOrigins(
    //                    Uris.WebClientsUri)
    //                    .AllowAnyHeader()
    //                    .AllowAnyMethod();
    //        });
    //});

    string[] corsSites = builder.Configuration.GetSection("AppSettings:CORS:AllowedOrigins").Get<string[]>() ?? [];

#if (DEBUG)
    var listCors = new List<string>() { "http://localhost:3000" };   
#else
    var listCors = new List<string>();
#endif

    listCors.AddRange(corsSites);

    if (System.Diagnostics.Debugger.IsAttached)
    {
        listCors.Add("http://localhost:3000");
    }

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigins",
            builder =>
            {
                builder.WithOrigins([.. listCors])
                        .AllowAnyHeader()
                        .AllowAnyMethod();
            });
    });

    var swaggerVersion = builder.Configuration["Swagger:Version"]?.ToString() ?? "v1";

    builder.Services.AddSwaggerGen(swagger =>
    {
        //This is to generate the Default UI of Swagger Documentation
        swagger.SwaggerDoc(swaggerVersion, new OpenApiInfo
        {
            Version = swaggerVersion,
            Title = "JWT Token Authentication API",
            Description = "Medical System.NET 9 Web API"
        });
        // To Enable authorization using Swagger (JWT)
        swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        });
        swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    Array.Empty<string>()
                }
            });
    });


    var key = Encoding.ASCII.GetBytes(builder.Configuration["AppSettings:Secret"] ?? "");
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

    var app = builder.Build();

    //EndpointRegistration.AddApiServices(app);

    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    //{
    //    app.MapOpenApi();
    //    app.UseSwagger();
    //    app.UseSwaggerUI(c =>
    //    {
    //        c.SwaggerEndpoint($"/swagger/{swaggerVersion}/swagger.json", $"Medical System.NET API {swaggerVersion}");
    //        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    //        c.DefaultModelsExpandDepth(-1);
    //    });
    //}
    //else
    //{
    //    app.UseSwagger();
    //    app.UseSwaggerUI(c =>
    //    {
    //        c.SwaggerEndpoint($"/swagger/{swaggerVersion}/swagger.json", $"Medical System.NET API {swaggerVersion}");
    //        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    //        c.DefaultModelsExpandDepth(-1);
    //    });
    //}




    app.UseHttpsRedirection();
    app.UseResponseCompression();
    //app.UseCors("AllowSpecificOrigins");
    app.UseCors("AllowAllOrigins");

    app.UseAuthentication();
    app.UseMiddleware<JwtMiddleware>();
    app.UseAuthorization();

    AppSettingsHealthCheck.Use(app);

    app.MapControllers();


    var cultureInfo = new CultureInfo("pt-BR");
    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

    app.MapGet("/",
        (context) =>
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
#if (!DEBUG)
            logger.Info($"Redirecionado para Menphis - IP: {ipAddress}");
#endif
            context.Response.Redirect("https://menphis.com.br/?ur=apiadv");
            return Task.CompletedTask;
        }
  ).ShortCircuit(200);

    app.MapGet("/api/v1/",
          (context) =>
          {
              var ipAddress = context.Connection.RemoteIpAddress?.ToString();
#if (!DEBUG)
            logger.Info($"Redirecionado para Menphis - IP: {ipAddress}");
#endif
              context.Response.Redirect("https://menphis.com.br/?urapiadvi");
              return Task.CompletedTask;
          }
  ).ShortCircuit(200);

    /*
    var sqlCommands = @"alter table PreClientes ADD cliAssCPF2[nvarchar](11) NULL;
update PreClientes Set cliAssCPF=cliAssCPF2;
alter table PreClientes drop column cliAssCPF;
alter table PreClientes ADD cliAssCPF[nvarchar](11) NULL;
update PreClientes Set cliAssCPF=cliAssCPF2;
alter table PreClientes drop column cliAssCPF2;";

    using var oCnn = Configuracoes.GetConnectionByUriRw("IBRADV");
    foreach (var commandText in sqlCommands.Split(";", StringSplitOptions.RemoveEmptyEntries))
    {
        ConfiguracoesDBT.ExecuteSqlCreate(commandText, oCnn);
    }
    */
    app.Run();
}
catch (Exception exception)
{

    logger.Error(exception, "Stopped program because of exception");

    throw;
}
finally
{
    LogManager.Shutdown();
}

