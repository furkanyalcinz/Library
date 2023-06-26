using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI/"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("SqlServer")!;
            }
        }
        static public string SecretKey
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI/"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetSection("AppSettings:SecretKey").Value!;
            }
        }
        static public string Issurer
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI/"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetSection("AppSettings:Issurer").Value!;
            }
        }
        static public double ExpirationMinutes
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI/"));
                configurationManager.AddJsonFile("appsettings.json");
                return double.Parse(configurationManager.GetSection("AppSettings:ExpirationMinutes").Value!);
            }
        }
    }
}
