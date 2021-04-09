using CustomConfigurationProvider.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace CustomConfigurationProvider.Helpers
{
    public class DBConfigurationProvider : ConfigurationProvider
    {
        private readonly Action<DbContextOptionsBuilder> optionsAction;
        public DBConfigurationProvider(Action<DbContextOptionsBuilder> _optionsAction)
        {
            optionsAction = _optionsAction;
        }
        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<ConfigContext>();
            optionsAction(builder);

            using (var ctx = new ConfigContext(builder.Options))
            {
                ctx.Database.EnsureCreated();

                if (ctx.DBConfigs.Any())
                    Data = ctx.DBConfigs.ToDictionary(c => c.Key, c => c.Value);
            }
        }
    }
}
