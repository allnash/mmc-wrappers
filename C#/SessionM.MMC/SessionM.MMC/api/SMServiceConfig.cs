using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SessionM.MMC.API
{
    public class SMServiceConfig
    {
        private static SMServiceConfig instance;
        private string serverUrl;
        private string apiKey;
        private string apiSecret;

        private SMServiceConfig()
        {
            XElement xml = XElement.Load("SMServiceConfig.xml");

            serverUrl = xml.Elements("configuration").First().Element("ServerUrl").Value;
            apiKey    = xml.Elements("configuration").First().Element("ApiKey").Value;
            apiSecret = xml.Elements("configuration").First().Element("ApiSecret").Value;
        }

        public static SMServiceConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SMServiceConfig();
                }
                return instance;
            }
        }

        public string ServerUrl
        {
            get
            {
                return serverUrl;
            }
        }

        public string ApiKey
        {
            get
            {
                return apiKey;
            }
        }

        public string ApiSecret
        {
            get
            {
                return apiSecret;
            }
        }

        public void Refresh()
        {
            instance = new SMServiceConfig();
        }
    }
}
