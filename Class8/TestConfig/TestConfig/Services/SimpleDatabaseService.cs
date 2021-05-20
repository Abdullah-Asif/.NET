using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestConfig.Services;
using Autofac;
namespace TestConfig.Services
{
    public class SimpleDatabaseService : IDatabaseService
    {
        private IDriverService _driverService;
        public SimpleDatabaseService(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public string GetName()
        {
            return "Simple Service";
        }
    }
}
