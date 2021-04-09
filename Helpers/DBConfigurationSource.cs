using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CustomConfigurationProvider.Helpers
{
    public class DBConfigurationSource : IConfigurationSource
    {

        private readonly Action<DbContextOptionsBuilder> optionsAction;
        public DBConfigurationSource(Action<DbContextOptionsBuilder> _optionsAction)
        {
            optionsAction = _optionsAction;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder) =>
            new DBConfigurationProvider(optionsAction);
    }
}
