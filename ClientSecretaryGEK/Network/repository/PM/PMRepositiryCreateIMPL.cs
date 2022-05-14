using ClientSecretaryGEK.Network.repository.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.repository.PM
{
    internal class PMRepositiryCreateIMPL : PMRepositotyCreate
    {
        Service<PMTableCreate> serviceCreate;
        public PMTableCreate _Create()
        {
            return serviceCreate.Create();
        }
        public PMRepositiryCreateIMPL (Service<PMTableCreate> serviceCreate) { this.serviceCreate = serviceCreate; }
    }
}
