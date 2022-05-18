using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLib
{
    interface IRequest
    {
        String Request(string cmd);
    }

    class DbRequest : IRequest
    {
        public string Request(string cmd) => $"DB result for command [{cmd}]";
    }

    class DbProxy : IRequest
    {
        private IRequest _read_DB;

        public DbProxy() => _read_DB = new DbRequest();

        public DbProxy(IRequest read_BD) => _read_DB = read_BD;
        
        public string Request(string cmd)
        {
            if (cmd.Contains("GET"))
                return _read_DB.Request(cmd);
            else
                return "Command blocked on proxy";
        }
    }


    public class Proxy
    {
        public void Show()
        {
            IRequest request = new DbRequest();
            String cmd = "GET ALL DATA";
            String cmd2 = "DETE ALL DATA";

            Console.WriteLine(request.Request(cmd));
            Console.WriteLine(request.Request(cmd2));

            request = new DbProxy();
            Console.WriteLine(request.Request(cmd));
            Console.WriteLine(request.Request(cmd2));
        }
    }
}
