using Microsoft.EntityFrameworkCore;
using week3_hw;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<VirtualPetsDbContext>(options => 
                                                        options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}


