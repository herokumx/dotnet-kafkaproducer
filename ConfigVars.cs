using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FXProducer
{
    public sealed class ConfigVars
    {
        public string KafkaTopic = string.Empty;
        public string EnpointUrl = string.Empty;
        private ConfigVars()
        {
            EnpointUrl = Environment.GetEnvironmentVariable("HTTP_ENDPOINT_URL");
            KafkaTopic = Environment.GetEnvironmentVariable("KAFKA_TOPIC");

            //for local testing
            //KafkaTopic = "FX-VIP";
            //EnpointUrl = "http://fx-kafka.herokuapp.com/api/messages";
        }
        public static ConfigVars Instance { get { return ConfigVarInstance.Instance; } }

        private class ConfigVarInstance
        {
            static ConfigVarInstance()
            {
            }

            internal static readonly ConfigVars Instance = new ConfigVars();
        }
    }
}
