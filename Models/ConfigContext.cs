using Microsoft.EntityFrameworkCore;

namespace CustomConfigurationProvider.Models
{
    public class ConfigContext : DbContext
    {
        public ConfigContext(DbContextOptions options) : base(options) { }
        public DbSet<DBConfig> DBConfigs { get; set; }
    }
}
