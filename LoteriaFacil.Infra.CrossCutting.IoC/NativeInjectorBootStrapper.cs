//using LoteriaFacil.Application.Interfaces;
//using LoteriaFacil.Application.Services;
//using LoteriaFacil.Domain.CommandHandlers;
//using LoteriaFacil.Domain.Commands;
using LoteriaFacil.Domain.Core.Bus;
using LoteriaFacil.Domain.Core.Events;
using LoteriaFacil.Domain.Core.Notifications;
//using LoteriaFacil.Domain.EventHandlers;
//using LoteriaFacil.Domain.Events;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Infra.CrossCutting.Bus;
using LoteriaFacil.Infra.CrossCutting.Identity.Authorization;
using LoteriaFacil.Infra.CrossCutting.Identity.Models;
using LoteriaFacil.Infra.CrossCutting.Identity.Services;
using LoteriaFacil.Infra.Data.Context;
using LoteriaFacil.Infra.Data.EventSourcing;
using LoteriaFacil.Infra.Data.Repository;
using LoteriaFacil.Infra.Data.Repository.EventSourcing;
using LoteriaFacil.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LoteriaFacil.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            //services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            //services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            //services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, bool>, CustomerCommandHandler>();
            //services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
            //services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LoteriaFacilContext>();
            //services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
