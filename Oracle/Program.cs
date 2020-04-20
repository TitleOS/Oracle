using System;
using System.IO;

namespace Oracle
{
    class Program
    {
        

        static void Main(string[] args)
        {
            bool DumpCert = false;
            try
            {
                if (args[0].ToString() == "-certdump")
                {
                    DumpCert = true;
                }

            }
            catch { }
            
            Console.WriteLine($"Oracle for SystemOS RS3");
            Console.WriteLine("====================================");
            Console.WriteLine($"OS Version: {BuildLabEx()}");
            Console.WriteLine($"SOCID: {InfoGather.GetSOCID()}");
            Console.WriteLine($"Serial Number: {InfoGather.GetSerialNumber()}");
            Console.WriteLine($"Capabilties Count: {InfoGather.GetCapabiltiesCount()}");
            Console.WriteLine($"Console Region: {InfoGather.GetConsoleRegion()}");
            Console.WriteLine($"Power Test: {InfoGather.PowerTest()}");
            Console.WriteLine($"PSPAPStatus: {InfoGather.GetPSPAP()}");
            Console.WriteLine($"Authorize XVD: {InfoGather.AuthorizeXvd()}");
            Console.WriteLine($"Generate Writable XVD Key: {InfoGather.GenerateWritableXVDKey()}");
            Console.WriteLine($"Delete Writable XVD Key: {InfoGather.DeleteWritableXVDKey()}");
            DumpCerts();
        }

        public static string BuildLabEx()
        {
            string buildlabex = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion", "BuildLabEx", "Could not access BuildLabEx").ToString();
            return buildlabex;
        }

        public static void DumpCerts()
        {
            byte[] CPCert = InfoGather.DumpCPCert();
            BinaryWriter binaryWriter = new BinaryWriter(File.Open(Environment.CurrentDirectory + "\\cpcert.bin", FileMode.OpenOrCreate));
            binaryWriter.Write(CPCert, 0, CPCert.Length);
            binaryWriter.Close();
            Console.WriteLine($"Dumped Capability Cert to {Environment.CurrentDirectory}\\cpcert.bin");
            byte[] CCCert = InfoGather.DumpCCCert();
            BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(Environment.CurrentDirectory + "\\cccert.bin", FileMode.OpenOrCreate));
            binaryWriter2.Write(CCCert, 0, CCCert.Length);
            binaryWriter2.Close();
            Console.WriteLine($"Dumped Console Cert to {Environment.CurrentDirectory}\\cccert.bin");
        }
    }
}
