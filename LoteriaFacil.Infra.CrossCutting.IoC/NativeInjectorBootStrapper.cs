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
            services.AddScoped<ITypeLotteryAppService, TypeLotteryAppService>();// novo #TypeLottery
            services.AddScoped<ILotteryAppService, LotteryAppService>();// novo #Lottery
            services.AddScoped<IPersonLotteryAppService, PersonLotteryAppService>();// novo #PersonLottery

            services.AddScoped<IUtilitiesAppService, UtilitiesAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<INotificationHandler<PersonRegisteredEvent>, PersonEventHandler>(); // - novo #Person
            services.AddScoped<INotificationHandler<PersonUpdatedEvent>, PersonEventHandler>(); // - novo #Person
            services.AddScoped<INotificationHandler<PersonRemovedEvent>, PersonEventHandler>(); // - novo #Person

            services.AddScoped<INotificationHandler<ConfigurationRegisteredEvent>, ConfigurationEventHandler>(); // - novo #Configuration
            services.AddScoped<INotificationHandler<ConfigurationUpdatedEvent>, ConfigurationEventHandler>(); // - novo #Configuration

            services.AddScoped<INotificationHandler<TypeLotteryRegisteredEvent>, TypeLotteryEventHandler>(); // - novo #TypeLottery
            services.AddScoped<INotificationHandler<TypeLotteryUpdatedEvent>, TypeLotteryEventHandler>(); // - novo #TypeLottery
            services.AddScoped<INotificationHandler<TypeLotteryUpdatedEvent>, TypeLotteryEventHandler>(); // - novo #TypeLottery

            services.AddScoped<INotificationHandler<LotteryRegisteredEvent>, LotteryEventHandler>(); // - novo #Lottery
            services.AddScoped<INotificationHandler<LotteryUpdatedEvent>, LotteryEventHandler>(); // - novo #Lottery
            services.AddScoped<INotificationHandler<LotteryUpdatedEvent>, LotteryEventHandler>(); // - novo #Lottery

            services.AddScoped<INotificationHandler<PersonLotteryRegisteredEvent>, PersonLotteryEventHandler>(); // - novo #PersonLottery
            services.AddScoped<INotificationHandler<PersonLotteryUpdatedEvent>, PersonLotteryEventHandler>(); // - novo #PersonLottery
            services.AddScoped<INotificationHandler<PersonLotteryUpdatedEvent>, PersonLotteryEventHandler>(); // - novo #PersonLottery

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewPersonCommand, bool>, PersonCommandHandler>(); // - novo #Person
            services.AddScoped<IRequestHandler<UpdatePersonCommand, bool>, PersonCommandHandler>(); // - novo #Person
            services.AddScoped<IRequestHandler<RemovePersonCommand, bool>, PersonCommandHandler>(); // - novo #Person

            services.AddScoped<IRequestHandler<RegisterNewConfigurationCommand, bool>, ConfigurationCommandHandler>(); // - novo #Configuration
            services.AddScoped<IRequestHandler<UpdateConfigurationCommand, bool>, ConfigurationCommandHandler>(); // - novo #Configuration

            services.AddScoped<IRequestHandler<RegisterNewTypeLotteryCommand, bool>, TypeLotteryCommandHandler>(); // - novo #TypeLottery
            services.AddScoped<IRequestHandler<UpdateTypeLotteryCommand, bool>, TypeLotteryCommandHandler>(); // - novo #TypeLottery
            services.AddScoped<IRequestHandler<RemoveTypeLotteryCommand, bool>, TypeLotteryCommandHandler>(); // - novo #TypeLottery

            services.AddScoped<IRequestHandler<RegisterNewLotteryCommand, bool>, LotteryCommandHandler>(); // - novo #Lottery
            services.AddScoped<IRequestHandler<UpdateLotteryCommand, bool>, LotteryCommandHandler>(); // - novo #Lottery
            services.AddScoped<IRequestHandler<RemoveLotteryCommand, bool>, LotteryCommandHandler>(); // - novo #Lottery

            services.AddScoped<IRequestHandler<RegisterNewPersonLotteryCommand, bool>, PersonLotteryCommandHandler>(); // - novo #PersonLottery
            services.AddScoped<IRequestHandler<UpdatePersonLotteryCommand, bool>, PersonLotteryCommandHandler>(); // - novo #PersonLottery
            services.AddScoped<IRequestHandler<RemovePersonLotteryCommand, bool>, PersonLotteryCommandHandler>(); // - novo #PersonLottery


            // Infra - Data
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>(); // - novo #Person
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>(); // - novo #Configuration
            services.AddScoped<ITypeLotteryRepository, TypeLotteryRepository>(); // - novo #TypeLottery
            services.AddScoped<ILotteryRepository, LotteryRepository>(); // - novo #Lottery
            services.AddScoped<IPersonLotteryRepository, PersonLotteryRepository>(); // - novo #PersonLottery

            services.AddScoped<IJsonDashboardRepository, JsonDashboardRepository>(); // - novo #JsonDashboard
            services.AddScoped<IPersonGameRepository, PersonGameRepository>(); // - novo #GamePerson

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
