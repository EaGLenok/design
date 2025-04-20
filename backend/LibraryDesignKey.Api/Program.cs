using MediatR;
using FluentValidation;
using AutoMapper;
using LibraryDesignKey.Api.Middleware;
using LibraryDesignKey.Infrastructure.Persistence;
using LibraryDesignKey.Shared.Settings;
using LibraryDesingKey.Application;
using LibraryDesingKey.Application.CQRS.Behaviors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<StorageSettings>(builder.Configuration.GetSection("Storage"));
builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<ApplicationAssembly>());

builder.Services.AddValidatorsFromAssemblyContaining<ApplicationAssembly>();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddSingleton<IBookRepository, BookRepositoryJson>();
builder.Services.AddSingleton<IMemberRepository, MemberRepositoryJson>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.MapControllers();
app.Run();