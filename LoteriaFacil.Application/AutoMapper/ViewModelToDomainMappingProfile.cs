using AutoMapper;
using LoteriaFacil.Application.ViewModels;
using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {

            //novo - #Person
            CreateMap<PersonViewModel, RegisterNewPersonCommand>()
                .ConstructUsing(c => new RegisterNewPersonCommand(c.Name, c.Email, c.Password, c.DtRegister, c.Active));
            //novo - #Person
            CreateMap<PersonViewModel, UpdatePersonCommand>()
                .ConstructUsing(c => new UpdatePersonCommand(c.Id, c.Name, c.Email, c.Password, c.DtRegister, c.Active));

            //novo - #Configuration
            CreateMap<ConfigurationViewModel, RegisterNewConfigurationCommand>()
                .ConstructUsing(c => new RegisterNewConfigurationCommand(c.Calcular_Dezenas_Sem_Pontuacao, c.Enviar_Email_Manualmente, c.Enviar_Email_Automaticamente, c.Checar_Jogo_Online, c.Valor_Minimo_Para_Envio_Email));
            //novo - #Configuration
            CreateMap<ConfigurationViewModel, UpdateConfigurationCommand>()
                .ConstructUsing(c => new UpdateConfigurationCommand(c.Id, c.Calcular_Dezenas_Sem_Pontuacao, c.Enviar_Email_Manualmente, c.Enviar_Email_Automaticamente, c.Checar_Jogo_Online, c.Valor_Minimo_Para_Envio_Email));

            //novo - #Type_Lottery
            CreateMap<Type_LotteryViewModel, RegisterNewType_LotteryCommand>()
                .ConstructUsing(c => new RegisterNewType_LotteryCommand(c.Name, c.Tens_Min, c.Bet_Min, c.Hit_Min, c.Hit_Max));
            //novo - #Type_Lottery
            CreateMap<Type_LotteryViewModel, UpdateType_LotteryCommand>()
                .ConstructUsing(c => new UpdateType_LotteryCommand(c.Id, c.Name, c.Tens_Min, c.Bet_Min, c.Hit_Min, c.Hit_Max));
            //novo - #Type_Lottery
            CreateMap<Type_LotteryViewModel, RemoveType_LotteryCommand>()
                .ConstructUsing(c => new RemoveType_LotteryCommand(c.Id));

            //novo - #Lottey
            CreateMap<LotteryViewModel, RegisterNewLotteryCommand>()
                .ConstructUsing(c => new RegisterNewLotteryCommand(c.Concurse, c.DtConcurse, c.Game, c.Hit15, c.Hit14, c.Hit13, c.Hit12, c.Hit11, c.Shared15, c.Shared14, c.Shared13, c.Shared12, c.Shared11, c.DtNextConcurse, c.Type_Lottery));
            //novo - #Lottery
            CreateMap<LotteryViewModel, UpdateLotteryCommand>()
                .ConstructUsing(c => new UpdateLotteryCommand(c.Id, c.Concurse, c.DtConcurse, c.Game, c.Hit15, c.Hit14, c.Hit13, c.Hit12, c.Hit11, c.Shared15, c.Shared14, c.Shared13, c.Shared12, c.Shared11, c.DtNextConcurse, c.Type_Lottery));
            //novo - #Lottery
            CreateMap<LotteryViewModel, RemoveLotteryCommand>()
                .ConstructUsing(c => new RemoveLotteryCommand(c.Id));

            //novo - #Person_Lottery
            CreateMap<Person_LotteryViewModel, RegisterNewPerson_LotteryCommand>()
                .ConstructUsing(c => new RegisterNewPerson_LotteryCommand(c.Concurse, c.Game, c.Hits, c.Ticket_Amount, c.Game_Checked, c.Game_Register, c.Lottery, c.Person));
            //novo - #Person_Lottery
            CreateMap<Person_LotteryViewModel, UpdatePerson_LotteryCommand>()
                .ConstructUsing(c => new UpdatePerson_LotteryCommand(c.Id, c.Concurse, c.Game, c.Hits, c.Ticket_Amount, c.Game_Checked, c.Lottery, c.Person));
            //novo - #Person_Lottery
            CreateMap<Person_LotteryViewModel, RemovePerson_LotteryCommand>()
                .ConstructUsing(c => new RemovePerson_LotteryCommand(c.Id));
        }
    }
}
