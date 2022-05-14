using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.repository
{
    internal interface PMRepository
    {
        List<PMTable> Execute();
        //void _Create(string token, string method, string index, string name);

    }
}
