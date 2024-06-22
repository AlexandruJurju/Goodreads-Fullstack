using Goodreads;
using Goodreads.Business;
using Goodreads.DataAccess;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAuthorization();
    builder.Services.AddControllers();

    builder.Services.AddDataAccess(builder.Configuration);
    builder.Services.AddBusiness();
    builder.Services.AddConfiguration();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(c =>
    {
        c.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    
    app.Run();
}