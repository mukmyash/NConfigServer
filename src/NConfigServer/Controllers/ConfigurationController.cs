using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace NConfigServer.Controllers
{
    [Route("")]
    public class ConfigurationController : Controller
    {
        public static Dictionary<string, IConfiguration> Configs = new Dictionary<string, IConfiguration>();
        
        [HttpGet("{projectName}/{env?}")]
        public IActionResult Index(string projectName,string env="base",bool isReload = false)
        {
            var key = $"{projectName}:{env}";
            IConfiguration result;
            if (!isReload && Configs.ContainsKey(key))
            {
                result = Configs[key];
            }
            else
            {
                Configs.Remove(key);
                result = BuildConfig(projectName, env);
                Configs.Add(key, result);
            }

            return Ok(result.AsEnumerable());
        }



        private IConfiguration BuildConfig(string projectName, string env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"Resources/Configurations/{projectName}/base.json", true)
            .AddJsonFile($"Resources/Configurations/{projectName}/{env}.json", true)
            .AddXmlFile($"Resources/Configurations/{projectName}/base.xml", true)
            .AddXmlFile($"Resources/Configurations/{projectName}/{env}.xml", true);

            return builder.Build();
        }
    }
}