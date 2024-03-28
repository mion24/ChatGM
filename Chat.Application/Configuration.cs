using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application
{
    public class Configuration
    {
        public static SecretsConfiguration Secrets { get; set; } = new SecretsConfiguration();
        public static DatabaseConfiguration Database { get; set; } = new DatabaseConfiguration();

        #region Classes
        public class DatabaseConfiguration
        {
            public string ConnectionString { get; set; } = string.Empty;
        }
        public class SecretsConfiguration
        {
            public string ApiKey { get; set; } = string.Empty;
            public string JwtPrivateKey { get; set; } = string.Empty;
        }
        #endregion
    }
}
