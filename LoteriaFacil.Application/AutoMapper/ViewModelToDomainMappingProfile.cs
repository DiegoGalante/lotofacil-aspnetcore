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

            //novo - #TypeLottery
            CreateMap<TypeLotteryViewModel, RegisterNewTypeLotteryCommand>()
                .ConstructUsing(c => new RegisterNewTypeLotteryCommand(c.Name, c.Tens_Min, c.Bet_Min, c.Hit_Min, c.Hit_Max));
            //novo - #TypeLottery
            CreateMap<TypeLotteryViewModel, UpdateTypeLotteryCommand>()
                .ConstructUsing(c => new UpdateTypeLotteryCommand(c.Id, c.Name, c.Tens_Min, c.Bet_Min, c.Hit_Min, c.Hit_Max));
            //novo - #TypeLottery
            CreateMap<TypeLotteryViewModel, RemoveTypeLotteryCommand>()
                .ConstructUsing(c => new RemoveTypeLotteryCommand(c.Id));

            //novo - #Lottey
            CreateMap<LotteryViewModel, RegisterNewLotteryCommand>()
                .ConstructUsing(c => new RegisterNewLotteryCommand(c.Concurse, c.DtConcurse, c.Game, c.Hit15, c.Hit14, c.Hit13, c.Hit12, c.Hit11, c.Shared15, c.Shared14, c.Shared13, c.Shared12, c.Shared11, c.DtNextConcurse, c.TypeLottery));
            //novo - #Lottery
            CreateMap<LotteryViewModel, UpdateLotteryCommand>()
                .ConstructUsing(c => new UpdateLotteryCommand(c.Id, c.Concurse, c.DtConcurse, c.Game, c.Hit15, c.Hit14, c.Hit13, c.Hit12, c.Hit11, c.Shared15, c.Shared14, c.Shared13, c.Shared12, c.Shared11, c.DtNextConcurse, c.TypeLottery));
            //novo - #Lottery
            CreateMap<LotteryViewModel, RemoveLotteryCommand>()
                .ConstructUsing(c => new RemoveLotteryCommand(c.Id));

            //novo - #PersonLottery
            CreateMap<PersonLotteryViewModel, RegisterNewPersonLotteryCommand>()
                .ConstructUsing(c => new RegisterNewPersonLotteryCommand(c.Concurse, c.Game, c.Hits, c.Ticket_Amount, c.Game_Checked, c.Game_Register, c.Lottery, c.Person));
            //novo - #PersonLottery
            CreateMap<PersonLotteryViewModel, UpdatePersonLotteryCommand>()
                .ConstructUsing(c => new UpdatePersonLotteryCommand(c.Id, c.Concurse, c.Game, c.Hits, c.Ticket_Amount, c.Game_Checked, c.Lottery, c.Person));
            //novo - #PersonLottery
            CreateMap<PersonLotteryViewModel, RemovePersonLotteryCommand>()
                .ConstructUsing(c => new RemovePersonLotteryCommand(c.Id));
        }
    }
}
