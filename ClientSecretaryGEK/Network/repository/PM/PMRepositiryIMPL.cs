﻿using ClientSecretaryGEK.Network.repository.net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.repository
{
    internal class PMRepositiryIMPL : PMRepository
    {
        Service<PMTable> service;
        Service<PMTableCreate> serviceCreate;
        public PMTableCreate _Create()
        {
            return serviceCreate.Create();
        }
        public List<PMTable> Execute()
        {
            return service.Start();
        }
        public PMRepositiryIMPL(Service<PMTable> service) { this.service = service; }


    }
}