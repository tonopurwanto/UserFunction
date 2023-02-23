using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFunction.Services;

namespace UserFunction.Domain
{
    public static class DIContainer
    {
        private static readonly IServiceProvider _instance = Build();

        public static IServiceProvider Instance => _instance;

        private static IServiceProvider Build()
        {
            var service = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

            service.AddSingleton<IProfileService, ProfileService>();

            return service.BuildServiceProvider();
        }
    }
}
