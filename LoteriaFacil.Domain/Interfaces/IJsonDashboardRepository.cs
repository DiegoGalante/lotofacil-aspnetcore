using LoteriaFacil.Domain.Models;

namespace LoteriaFacil.Domain.Interfaces
{
   public  interface IJsonDashboardRepository : IRepository<JsonDashboard>
    {
        JsonDashboard GetFunctionJsonDashBoard(int concurse = 0);
    }
}
