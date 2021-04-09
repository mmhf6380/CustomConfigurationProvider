using CustomConfigurationProvider.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace CustomConfigurationProvider.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly ConfigContext ctx;
        private readonly IConfiguration configuration;

        public ConfigurationController(ConfigContext context, IConfiguration configuration)
        {
            ctx = context;
            this.configuration = configuration;
        }

        [HttpPost("Create Config")]
        public IActionResult Post(string key, string value)
        {
            var config = new DBConfig
            {
                Key = key.ToLower(),
                Value = value
            };
            ctx.DBConfigs.Add(config);
            ctx.SaveChanges();
            return Ok();
        }


        [HttpGet("Get Config")]
        public string Get(string key)
        {
            return configuration.GetValue<string>(key.ToLower());
        }

        [HttpGet("Get All Config")]
        public List<KeyValuePair<string,string>> Get()
        {
            return configuration.AsEnumerable().ToList();
        }
    }
}
