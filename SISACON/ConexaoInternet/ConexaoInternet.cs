using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.ConexaoInternet
{
    public static class ConexaoInternet
    {
        public static bool VerificarConexao()
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send("www.google.com");

                if (reply != null && reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}