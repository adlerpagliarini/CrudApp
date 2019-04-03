using AutoMapper;
using Crud.App.Application.AutoMapper;
using Crud.App.Application.Interfaces;
using Crud.App.Application.Services;
using Crud.App.Domain.Core.Notifications;
using Crud.App.Domain.Interfaces;
using Crud.App.Infra.CrossCutting.AspNetFilters;
using Crud.App.Infra.Data.Context;
using Crud.App.Infra.Data.Repository;
using Crud.App.Infra.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Crud.App.Domain.Usuarios.Service;

namespace Crud.App.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP NET - Tratamento de erros com filtros
            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<GlobalExceptionHandlingFilter>();

            // Application
            AutoMapperConfiguration.Configure();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            // Domain - Serviços
            services.AddScoped<IUsuarioService, UsuarioService>();

            // Domain - Notificacoes
            services.AddScoped<IDomainNotification, DomainNotification>();

            // Infra - Data
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CrudAppContext>();
        }
    }
}
