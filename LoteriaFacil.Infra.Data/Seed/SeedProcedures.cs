using LoteriaFacil.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Infra.Data.Seed
{
    public static class SeedProcedures
    {
        public static void Seed(LoteriaFacilContext loteriaFacilContext)
        {
            SeedProcedureSP_CHECK_GAME.Seed(loteriaFacilContext);
        }
    }
}
