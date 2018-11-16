using System;
using System.Net;
using System.Runtime.InteropServices;

namespace ClientSharp
{
    public sealed class NativeMethods
    {
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        private static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);

        private NativeMethods() { }

        public static string GetMacAddress(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
            {
                throw new ArgumentNullException("ipAddress");
            }

            IPAddress IP = IPAddress.Parse(ipAddress);
            byte[] macAddr = new byte[6];
            uint macAddrLen = (uint)macAddr.Length;

            SendARP((int)IP.Address, 0, macAddr, ref macAddrLen);

            string[] str = new string[(int)macAddrLen];

            for (int i = 0; i < macAddrLen; i++)
            {
                str[i] = macAddr[i].ToString("x2");
            }

            return string.Join(":", str).ToUpper();
        }
    }
}

