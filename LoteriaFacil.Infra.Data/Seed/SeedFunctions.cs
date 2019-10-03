using LoteriaFacil.Infra.Data.Context;

namespace LoteriaFacil.Infra.Data.Seed
{
    public static class SeedFunctions
    {
        public static void Seed(LoteriaFacilContext loteriaFacilContext)
        {
            SeedFunctionInitCap.Seed(loteriaFacilContext);
            SeedFunctionJogoConcurso.Seed(loteriaFacilContext);
            SeedFunctionJogoPessoa.Seed(loteriaFacilContext);
            SeedFunctionJsonDashboard.Seed(loteriaFacilContext);
        }
    }
}
