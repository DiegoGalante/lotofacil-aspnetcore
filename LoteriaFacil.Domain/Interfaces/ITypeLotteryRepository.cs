using LoteriaFacil.Domain.Models;
using System;

namespace LoteriaFacil.Domain.Interfaces
{
    public interface ITypeLotteryRepository : IRepository<TypeLottery>
    {
        //getbyid já vem por padrão
        TypeLottery GetByName(string name = "Loto Fácil");
    }
}
