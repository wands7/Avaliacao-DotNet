using AvaliacaoDotNet.Application.Services;
using AvaliacaoDotNet.Domain.Interfaces;
using AvaliacaoDotNet.Infrastructure.Data;
using AvaliacaoDotNet.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<PessoaService>();
builder.Services.AddIdentityCore<IdentityUser>();
builder.Services.AddSingleton<IUserStore<IdentityUser>, InMemoryUserStore>(); // Adiciona o store em mem�ria
builder.Services.AddIdentityCore<IdentityUser>()
    .AddDefaultTokenProviders();

// Configura��es de autentica��o JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Para facilitar o desenvolvimento local, em produ��o, sempre use HTTPS.
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("chave-secreta-super-segura-que-tem-32-caracteres!")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();
builder.Services.AddDataProtection();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var user = new IdentityUser { UserName = "admin", Email = "admin@email.com" };

    var result = await userManager.CreateAsync(user, "admin");
     
    if (result.Succeeded)
    {
        Console.WriteLine("Usu�rio admin criado com sucesso!");
    }
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();