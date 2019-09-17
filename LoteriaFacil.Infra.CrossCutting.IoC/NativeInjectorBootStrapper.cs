using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Application.Services;
using LoteriaFacil.Domain.CommandHandlers;
using LoteriaFacil.Domain.Commands;
using LoteriaFacil.Domain.Core.Bus;
using LoteriaFacil.Domain.Core.Events;
using LoteriaFacil.Domain.Core.Notifications;
using LoteriaFacil.Domain.EventHandlers;
using LoteriaFacil.Domain.Events;
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
            services.AddScoped<IPersonAppService, PersonAppService>(); // - novo #Person
            services.AddScoped<IConfigurationAppService, ConfigurationAppService>(); // - novo #Configuration
            services.AddScoped<IType_LotteryAppService, Type_LotteryAppService>();// novo #Type_Lottery
            services.AddScoped<ILotteryAppService, LotteryAppService>();// novo #Lottery
            services.AddScoped<IPerson_LotteryAppService, Person_LotteryAppService>();// novo #Person_Lottery

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<INotificationHandler<PersonRegisteredEvent>, PersonEventHandler>(); // - novo #Person
            services.AddScoped<INotificationHandler<PersonUpdatedEvent>, PersonEventHandler>(); // - novo #Person
            services.AddScoped<INotificationHandler<PersonRemovedEvent>, PersonEventHandler>(); // - novo #Person

            services.AddScoped<INotificationHandler<ConfigurationRegisteredEvent>, ConfigurationEventHandler>(); // - novo #Configuration
            services.AddScoped<INotificationHandler<ConfigurationUpdatedEvent>, ConfigurationEventHandler>(); // - novo #Configuration

            services.AddScoped<INotificationHandler<Type_LotteryRegisteredEvent>, Type_LotteryEventHandler>(); // - novo #Type_Lottery
            services.AddScoped<INotificationHandler<Type_LotteryUpdatedEvent>, Type_LotteryEventHandler>(); // - novo #Type_Lottery
            services.AddScoped<INotificationHandler<Type_LotteryUpdatedEvent>, Type_LotteryEventHandler>(); // - novo #Type_Lottery

            services.AddScoped<INotificationHandler<LotteryRegisteredEvent>, LotteryEventHandler>(); // - novo #Lottery
            services.AddScoped<INotificationHandler<LotteryUpdatedEvent>, LotteryEventHandler>(); // - novo #Lottery
            services.AddScoped<INotificationHandler<LotteryUpdatedEvent>, LotteryEventHandler>(); // - novo #Lottery

            services.AddScoped<INotificationHandler<Person_LotteryRegisteredEvent>, Person_LotteryEventHandler>(); // - novo #Person_Lottery
            services.AddScoped<INotificationHandler<Person_LotteryUpdatedEvent>, Person_LotteryEventHandler>(); // - novo #Person_Lottery
            services.AddScoped<INotificationHandler<Person_LotteryUpdatedEvent>, Person_LotteryEventHandler>(); // - novo #Person_Lottery

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewPersonCommand, bool>, PersonCommandHandler>(); // - novo #Person
            services.AddScoped<IRequestHandler<UpdatePersonCommand, bool>, PersonCommandHandler>(); // - novo #Person
            services.AddScoped<IRequestHandler<RemovePersonCommand, bool>, PersonCommandHandler>(); // - novo #Person

            services.AddScoped<IRequestHandler<RegisterNewConfigurationCommand, bool>, ConfigurationCommandHandler>(); // - novo #Configuration
            services.AddScoped<IRequestHandler<UpdateConfigurationCommand, bool>, ConfigurationCommandHandler>(); // - novo #Configuration

            services.AddScoped<IRequestHandler<RegisterNewType_LotteryCommand, bool>, Type_LotteryCommandHandler>(); // - novo #Type_Lottery
            services.AddScoped<IRequestHandler<UpdateType_LotteryCommand, bool>, Type_LotteryCommandHandler>(); // - novo #Type_Lottery
            services.AddScoped<IRequestHandler<RemoveType_LotteryCommand, bool>, Type_LotteryCommandHandler>(); // - novo #Type_Lottery

            services.AddScoped<IRequestHandler<RegisterNewLotteryCommand, bool>, LotteryCommandHandler>(); // - novo #Lottery
            services.AddScoped<IRequestHandler<UpdateLotteryCommand, bool>, LotteryCommandHandler>(); // - novo #Lottery
            services.AddScoped<IRequestHandler<RemoveLotteryCommand, bool>, LotteryCommandHandler>(); // - novo #Lottery

            services.AddScoped<IRequestHandler<RegisterNewPerson_LotteryCommand, bool>, Person_LotteryCommandHandler>(); // - novo #Person_Lottery
            services.AddScoped<IRequestHandler<UpdatePerson_LotteryCommand, bool>, Person_LotteryCommandHandler>(); // - novo #Person_Lottery
            services.AddScoped<IRequestHandler<RemovePerson_LotteryCommand, bool>, Person_LotteryCommandHandler>(); // - novo #Person_Lottery


            // Infra - Data
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>(); // - novo #Person
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>(); // - novo #Configuration
            services.AddScoped<IType_LotteryRepository, Type_LotteryRepository>(); // - novo #Type_Lottery
            services.AddScoped<ILotteryRepository, LotteryRepository>(); // - novo #Lottery
            services.AddScoped<IPerson_LotteryRepository, Person_LotteryRepository>(); // - novo #Person_Lottery

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LoteriaFacilContext>();

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
