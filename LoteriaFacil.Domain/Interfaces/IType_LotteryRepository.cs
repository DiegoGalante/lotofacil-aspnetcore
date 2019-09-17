using LoteriaFacil.Domain.Models;
using System;

namespace LoteriaFacil.Domain.Interfaces
{
    public interface IType_LotteryRepository : IRepository<Type_Lottery>
    {
        //getbyid já vem por padrão
        Type_Lottery GetByName(string name = "Loto Fácil");
    }
}
