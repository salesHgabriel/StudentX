using Companyx.Companyx.Studentx.Core;
using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Infrastructure;
using Companyx.Studentx.API.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
        "JWT Authorization Header - to use with Bearer Authentication.\r\n\r\n" +
        "Add 'Bearer' [space] and enter with token in field below.\r\n\r\n" +
        "Sample (report without quotes): 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });

    o.AddSecurityRequirement(new OpenApiSecurityRequirement
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

builder.Services.AddProjectCore();
builder.Services.AddProjectInfrastructure(builder.Configuration);

var app = builder.Build();

DomainEvents.Initialize(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();

        foreach (var groupName in descriptions.Select(description => description.GroupName))
        {
            var url = $"/swagger/{groupName}/swagger.json";
            var name = groupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });

    app.ApplyMigrations();

    // TODO: Uncomment if you want to seed initial data
    // if first build, you need create tables and after uncomment
    //app.SeedFakeData();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();