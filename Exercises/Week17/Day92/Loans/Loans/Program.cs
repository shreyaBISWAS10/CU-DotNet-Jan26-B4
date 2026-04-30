
using FluentValidation;
using FluentValidation.AspNetCore;
using Loans.Data;
using Loans.Middleware;
using Loans.Repositories;
using Loans.Services;
using Loans.Validators;
using Loans.Models;
using Loans.DTOs;
using Microsoft.EntityFrameworkCore;
using Serilog;
using AutoMapper;

namespace Loans
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LoanApplication, LoanResponseDto>();
                cfg.CreateMap<LoanRequestDto, LoanApplication>();
            });


            builder.Services.AddValidatorsFromAssemblyContaining<LoanRequestValidator>();
            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddScoped<ILoanRepository, LoanRepository>();
            // Add services to the container.

            Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

            builder.Host.UseSerilog();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
         
            var app = builder.Build();
            app.UseMiddleware<ExceptionMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
           

            app.MapControllers();

            app.Run();
        }
    }
}
