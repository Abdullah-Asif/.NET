using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestConfig.Services
{
    public class AdvanceDatabaseService : IDatabaseService
    {
        public string GetName()
        {
            return "Advance Service";
        }
    }
}
