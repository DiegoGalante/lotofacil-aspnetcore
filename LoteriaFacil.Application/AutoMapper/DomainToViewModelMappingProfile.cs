using AutoMapper;
using LoteriaFacil.Application.ViewModels;
using LoteriaFacil.Domain.Models;

namespace LoteriaFacil.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Person, PersonViewModel>(); //novo - #Person
            CreateMap<Configuration, ConfigurationViewModel>(); //novo - #Configuration
            CreateMap<TypeLottery, TypeLotteryViewModel>(); //novo - #TypeLottery
            CreateMap<Lottery, LotteryViewModel>(); //novo - #Lottery
            CreateMap<PersonLottery, PersonLotteryViewModel>(); //novo - #PersonLotteryLottery
        }
    }
}
