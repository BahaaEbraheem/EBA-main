using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Services.Seeding
{
    public interface ISeedTestDataService
    {

        void Seed(string typeName, int totalSeed);

    }
}
