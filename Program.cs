using leave_a_comment_api.Data;
using leave_a_comment_api.Extensions;
using leave_a_comment_api.Model;
using leave_a_comment_api.Repository;
using leave_a_comment_api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using leave_a_comment_api.ActionFilter;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

// Configure the database context to use SQLite
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CommentDbContext>(options =>
    options.UseSqlite(connectionString));

// Register the CommentRepository and CommentService
builder.Services.AddScoped<CommentRepository>();
builder.Services.AddScoped<CommentService>();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();

// Add Swagger services using the extension method
var apiKeyHeaderName = builder.Configuration["Swagger:ApiKeyHeaderName"];
builder.Services.AddSwaggerDocumentation(apiKeyHeaderName);


builder.Services.AddSingleton(new ApiKeyAuthAttribute(builder.Configuration));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


 

