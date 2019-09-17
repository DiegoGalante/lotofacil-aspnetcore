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
            CreateMap<Type_Lottery, Type_LotteryViewModel>(); //novo - #Type_Lottery
            CreateMap<Lottery, LotteryViewModel>(); //novo - #Lottery
            CreateMap<Person_Lottery, Person_LotteryViewModel>(); //novo - #Person_LotteryLottery
        }
    }
}
