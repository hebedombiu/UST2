using UnistreamTest2.Application.Services;
using UnistreamTest2.Dal.Repositories;
using UnistreamTest2.Dal.Services;
using UnistreamTest2.Host.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(config => {
    config.Filters.Add<ExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDb, MemoryDb>();

builder.Services.AddTransient<IRepository, Repository>();

builder.Services.AddScoped<IEntityService, EntityService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();