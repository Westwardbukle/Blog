using Blog.Database.Abstraction;
using Blog.Database.Repository;
using BlogAPI.Extentions;
using BlogCore.Abstract;
using BlogCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureAppOptions(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.ConfigureSwagger();

builder.Services.ConfigureAuthentication(builder.Configuration);

builder.Services.ConfigureDbContext(builder.Configuration);

builder.Services.ConfigureMapper();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.AddHttpContextAccessor();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(
        /*opt =>
        {
            foreach (var description in  provider.ApiVersionDescriptions)
            {
                opt.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        }*/
    );
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();