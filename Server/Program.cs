using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineShop.Server;
using OnlineShop.Server.DataAccess;
using OnlineShop.Server.Services;
using System.Collections.Generic;
using System.Text;

const string debugBlazorApp = "_debugBlazorApp";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<OnlineShopContext>();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Shop.Api", Version = "v1"});

    // Set the comments path for the Swagger JSON and UI.
    // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // c.IncludeXmlComments(xmlPath);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: debugBlazorApp,
        policy  =>
        {
            policy.WithOrigins("http://localhost:7207");
        });
});

string securityPrivateKey = builder.Configuration.GetValue<string>("Auth:PrivateKey");
var secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityPrivateKey));
builder.Services.AddSingleton(secKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "blazor.app",
                ValidAudience = "blazor.users",
                IssuerSigningKey = secKey
            };
        }
    );

var mappingConfig = TypeAdapterConfig.GlobalSettings.Default.Config;
IList<IRegister> registers = mappingConfig.Scan(typeof(MappingConfig).Assembly);

foreach (var register in registers) 
    mappingConfig.Apply(register);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPriceRepository, PriceRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop.API");
        }
    );
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

if (app.Environment.IsDevelopment()) 
    app.UseCors(debugBlazorApp);

app.MapRazorPages();
app.MapFallbackToFile("index.html");
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();


bool migrateDb = builder.Configuration.GetValue<bool>("MigrateDB");
if (migrateDb)
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<OnlineShopContext>();
        if (!context.Database.CanConnect())
            Console.WriteLine("Can't connect to DB");

        try
        {
            bool created = context.Database.EnsureCreated();
            Console.WriteLine($"DB bootstrapped={created}");
        }
        catch (Exception e)
        {
            Console.WriteLine("Migration error");
            Console.WriteLine(e);
            throw;
        }
    }
}

app.Run();