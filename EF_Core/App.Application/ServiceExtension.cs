using App.Application.Interfaces;
using App.Application.Interfaces.Impl;
using App.Application.Services;
using App.Application.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace App.Application
{
    public static class ServiceExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ISalaryService, SalaryService>();
            services.AddScoped<IProjectEmployeeService, ProjectEmployeeService>();
        }
    }
}