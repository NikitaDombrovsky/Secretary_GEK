using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.repository.net
{
    internal interface Service <T>
    {
        List<T> Start();
        //List<T> Create();
        //T Create();
        //void Create(string token, string method, string index, string name);
    }
}
