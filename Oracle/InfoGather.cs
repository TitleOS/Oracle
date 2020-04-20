using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DLLIMPORTS;

namespace Oracle
{
    public static class InfoGather
    {
        public static string GetSOCID()
        {
            int outBufSize = 0x10;
            int outBufMemSize = 0x10;
            int inBuffSize = 0;
            Int32 lpBytesReturned = 0;
            IntPtr pMemoryAddress = IntPtr.Zero;
            IntPtr lpInBuffer = Marshal.AllocHGlobal(inBuffSize);
            IntPtr outBuf = Marshal.AllocHGlobal(outBufMemSize);
            uint ioctlcall = 0x221008;
            string lpDeviceName = @"\\.\pspsra";

            IntPtr handle = DllImports.CreateFile
                   (lpDeviceName,
                   0xC0000000,
                   3,
                   0,
                   3,
                   DllImports.ACCESS_MASK.UNSPECIFIED,
                   0);
            bool status = DllImports.DeviceIoControl
           (
               handle,         // HANDLE
               ioctlcall,       // IOCTL   
               IntPtr.Zero,    // inBuffer
               (uint)inBuffSize,              // inBufferSize
               outBuf,         // outBuffer
               outBufSize,    // outBuffer Size
               lpBytesReturned,       // bytesReturned
               0               // lpOverlapped
           );
            byte[] managedArray = new byte[outBufSize];
            Marshal.Copy(outBuf, managedArray, 0, outBufSize);
            Array.Reverse(managedArray, 0, managedArray.Length);
            string buffer = "";
            buffer = BitConverter.ToString(managedArray);
            buffer = buffer.Replace("-", "");
            Marshal.ReAllocCoTaskMem(outBuf, outBufSize);
            return buffer;
        }
        public static string GetConsoleRegion()
        {
            int outBufSize = 0x1;
            int outBufMemSize = 0x1;
            int inBuffSize = 0;
            Int32 lpBytesReturned = 0;
            IntPtr pMemoryAddress = IntPtr.Zero;
            IntPtr lpInBuffer = Marshal.AllocHGlobal(inBuffSize);
            IntPtr outBuf = Marshal.AllocHGlobal(outBufMemSize);
            uint ioctlcall = 0x221014;
            string lpDeviceName = @"\\.\pspsra";

            IntPtr handle = DllImports.CreateFile
                   (lpDeviceName,
                   0xC0000000,
                   3,
                   0,
                   3,
                   DllImports.ACCESS_MASK.UNSPECIFIED,
                   0);
            bool status = DllImports.DeviceIoControl
           (
               handle,         // HANDLE
               ioctlcall,       // IOCTL   
               IntPtr.Zero,    // inBuffer
               (uint)inBuffSize,              // inBufferSize
               outBuf,         // outBuffer
               outBufSize,    // outBuffer Size
               lpBytesReturned,       // bytesReturned
               0               // lpOverlapped
           );
            byte[] managedArray = new byte[outBufSize];
            Marshal.Copy(outBuf, managedArray, 0, outBufSize);
            string buffer = "";
            foreach (byte thing in managedArray)
            {

                buffer += thing.ToString();
            }
            Marshal.ReAllocCoTaskMem(outBuf, outBufSize);
            if (buffer == "0")
            {
                return "ROW (Rest of World)";
            }
            else
            {
                return "China";
            }
        }

        public static string GetSerialNumber()
        {
            int outBufSize = 0xC;
            int outBufMemSize = 0xC;
            int inBuffSize = 0;
            Int32 lpBytesReturned = 0;
            IntPtr pMemoryAddress = IntPtr.Zero;
            IntPtr lpInBuffer = Marshal.AllocHGlobal(inBuffSize);
            IntPtr outBuf = Marshal.AllocHGlobal(outBufMemSize);
            uint ioctlcall = 0x221024;
            string lpDeviceName = @"\\.\pspsra";

            IntPtr handle = DllImports.CreateFile
                   (lpDeviceName,
                   0xC0000000,
                   3,
                   0,
                   3,
                   DllImports.ACCESS_MASK.UNSPECIFIED,
                   0);
            bool status = DllImports.DeviceIoControl
           (
               handle,         // HANDLE
               ioctlcall,       // IOCTL   
               IntPtr.Zero,    // inBuffer
               (uint)inBuffSize,              // inBufferSize
               outBuf,         // outBuffer
               outBufSize,    // outBuffer Size
               lpBytesReturned,       // bytesReturned
               0               // lpOverlapped
           );
            byte[] managedArray = new byte[outBufSize];
            Marshal.Copy(outBuf, managedArray, 0, outBufSize);
            //Array.Reverse(managedArray, 0, managedArray.Length);
            string buffer = "";
            buffer = BitConverter.ToString(managedArray);
            buffer = buffer.Replace("-", "");
            buffer = HexString2Ascii(buffer);
            Marshal.ReAllocCoTaskMem(outBuf, outBufSize);
            return buffer;
        }

        public static byte[] DumpCCCert()
        {
            int outBufSize = 0x400;
            int outBufMemSize = 0x400;
            int inBuffSize = 0;
            Int32 lpBytesReturned = 0;
            IntPtr pMemoryAddress = IntPtr.Zero;
            IntPtr lpInBuffer = Marshal.AllocHGlobal(inBuffSize);
            IntPtr outBuf = Marshal.AllocHGlobal(outBufMemSize);
            uint ioctlcall = 0x222004;
            string lpDeviceName = @"\\.\pspsra";

            IntPtr handle = DllImports.CreateFile
                   (lpDeviceName,
                   0xC0000000,
                   3,
                   0,
                   3,
                   DllImports.ACCESS_MASK.UNSPECIFIED,
                   0);
            bool status = DllImports.DeviceIoControl
           (
               handle,         // HANDLE
               ioctlcall,       // IOCTL   
               IntPtr.Zero,    // inBuffer
               (uint)inBuffSize,              // inBufferSize
               outBuf,         // outBuffer
               outBufSize,    // outBuffer Size
               lpBytesReturned,       // bytesReturned
               0               // lpOverlapped
           );
            byte[] managedArray = new byte[outBufSize];
            Marshal.Copy(outBuf, managedArray, 0, outBufSize);
            //Array.Reverse(managedArray, 0, managedArray.Length);
            Marshal.ReAllocCoTaskMem(outBuf, outBufSize);
            return managedArray;
        }

        public static byte[] DumpCPCert()
        {
            int outBufSize = 0x400;
            int outBufMemSize = 0x400;
            int inBuffSize = 0;
            Int32 lpBytesReturned = 0;
            IntPtr pMemoryAddress = IntPtr.Zero;
            IntPtr lpInBuffer = Marshal.AllocHGlobal(inBuffSize);
            IntPtr outBuf = Marshal.AllocHGlobal(outBufMemSize);
            uint ioctlcall = 0x222018;
            string lpDeviceName = @"\\.\pspsra";

            IntPtr handle = DllImports.CreateFile
                   (lpDeviceName,
                   0xC0000000,
                   3,
                   0,
                   3,
                   DllImports.ACCESS_MASK.UNSPECIFIED,
                   0);
            bool status = DllImports.DeviceIoControl
           (
               handle,         // HANDLE
               ioctlcall,       // IOCTL   
               IntPtr.Zero,    // inBuffer
               (uint)inBuffSize,              // inBufferSize
               outBuf,         // outBuffer
               outBufSize,    // outBuffer Size
               lpBytesReturned,       // bytesReturned
               0               // lpOverlapped
           );
            byte[] managedArray = new byte[outBufSize];
            Marshal.Copy(outBuf, managedArray, 0, outBufSize);
            //Array.Reverse(managedArray, 0, managedArray.Length);
            Marshal.ReAllocCoTaskMem(outBuf, outBufSize);
            return managedArray;
        }

        private static string HexString2Ascii(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }

        public static string GetPSPAP()
        {
            int outBufSize = 0x41C;
            int outBufMemSize = 0x41C;
            int inBuffSize = 0x41C;
            Int32 lpBytesReturned = 0;
            IntPtr pMemoryAddress = IntPtr.Zero;
            IntPtr lpInBuffer = Marshal.AllocHGlobal(inBuffSize);
            IntPtr outBuf = Marshal.AllocHGlobal(outBufMemSize);
            uint ioctlcall = 0x2200D0;
            string lpDeviceName = @"\\.\pspsra";

            IntPtr handle = DllImports.CreateFile
                   (lpDeviceName,
                   0xC0000000,
                   3,
                   0,
                   3,
                   DllImports.ACCESS_MASK.UNSPECIFIED,
                   0);
            bool status = DllImports.DeviceIoControl
           (
               handle,         // HANDLE
               ioctlcall,       // IOCTL   
               lpInBuffer,    // inBuffer
               (uint)inBuffSize,              // inBufferSize
               outBuf,         // outBuffer
               outBufSize,    // outBuffer Size
               lpBytesReturned,       // bytesReturned
               0               // lpOverlapped
           );
            byte[] managedArray = new byte[outBufSize];
            Marshal.Copy(outBuf, managedArray, 0, outBufSize);
            Array.Reverse(managedArray, 0, managedArray.Length);
            if (status)
            {
                return "Succeeded";
            }
            else
            {
                return "Failure Win32 Error (" + Marshal.GetLastWin32Error().ToString() + ")";
            }
        }

        public static string GetCapabiltiesCount()
        {
            int outBufSize = 2;
            int outBufMemSize = 2;
            int inBuffSize = 0;
            Int32 lpBytesReturned = 0;
            IntPtr pMemoryAddress = IntPtr.Zero;
            IntPtr lpInBuffer = Marshal.AllocHGlobal(inBuffSize);
            IntPtr outBuf = Marshal.AllocHGlobal(outBufMemSize);
            uint ioctlcall = 0x221038;
            string lpDeviceName = @"\\.\pspsra";

            IntPtr handle = DllImports.CreateFile
                   (lpDeviceName,
                   0xC0000000,
                   3,
                   0,
                   3,
                   DllImports.ACCESS_MASK.UNSPECIFIED,
                   0);
            bool status = DllImports.DeviceIoControl
           (
               handle,         // HANDLE
               ioctlcall,       // IOCTL   
               IntPtr.Zero,    // inBuffer
               (uint)inBuffSize,              // inBufferSize
               outBuf,         // outBuffer
               outBufSize,    // outBuffer Size
               lpBytesReturned,       // bytesReturned
               0               // lpOverlapped
           );
            byte[] managedArray = new byte[outBufSize];
            Marshal.Copy(outBuf, managedArray, 0, outBufSize);
            string buffer = "";
            foreach (byte thing in managedArray)
            {
                buffer += thing.ToString();
            }
            Marshal.ReAllocCoTaskMem(outBuf, outBufSize);
            if(buffer == "80")
            {
                return "02";

            }
            else
            {
                return buffer;

            }
        }

        public static string PowerTest()
        {
            int outBufSize = 0x8C;
            int outBufMemSize = 0x8C;
            int inBuffSize = 0x8C;
            Int32 lpBytesReturned = 0;
            IntPtr pMemoryAddress = IntPtr.Zero;
            IntPtr lpInBuffer = Marshal.AllocHGlobal(inBuffSize);
            IntPtr outBuf = Marshal.AllocHGlobal(outBufMemSize);
            uint ioctlcall = 0x220010;
            string lpDeviceName = @"\\.\pspsra";

            IntPtr handle = DllImports.CreateFile
                   (lpDeviceName,
                   0xC0000000,
                   3,
                   0,
                   3,
                   DllImports.ACCESS_MASK.UNSPECIFIED,
                   0);
            bool status = DllImports.DeviceIoControl
           (
               handle,         // HANDLE
               ioctlcall,       // IOCTL   
               lpInBuffer,    // inBuffer
               (uint)inBuffSize,              // inBufferSize
               outBuf,         // outBuffer
               outBufSize,    // outBuffer Size
               lpBytesReturned,       // bytesReturned
               0               // lpOverlapped
           );
            byte[] managedArray = new byte[outBufSize];
            Marshal.Copy(outBuf, managedArray, 0, outBufSize);
            if (status)
            {
                return "Succeeded";
            }
            else
            {
                return "Failure Win32 Error (" + Marshal.GetLastWin32Error().ToString() + ")";
            }
        }

        public static string GenerateWritableXVDKey()
        {
            int outBufSize = 0x18;
            int outBufMemSize = 0x18;
            int inBuffSize = 0x18;
            Int32 lpBytesReturned = 0;
            IntPtr pMemoryAddress = IntPtr.Zero;
            IntPtr lpInBuffer = Marshal.AllocHGlobal(inBuffSize);
            IntPtr outBuf = Marshal.AllocHGlobal(outBufMemSize);
            uint ioctlcall = 0x22204C;
            string lpDeviceName = @"\\.\pspsra";

            IntPtr handle = DllImports.CreateFile
                   (lpDeviceName,
                   0xC0000000,
                   3,
                   0,
                   3,
                   DllImports.ACCESS_MASK.UNSPECIFIED,
                   0);
            bool status = DllImports.DeviceIoControl
           (
               handle,         // HANDLE
               ioctlcall,       // IOCTL   
               lpInBuffer,    // inBuffer
               (uint)inBuffSize,              // inBufferSize
               outBuf,         // outBuffer
               outBufSize,    // outBuffer Size
               lpBytesReturned,       // bytesReturned
               0               // lpOverlapped
           );
            byte[] managedArray = new byte[outBufSize];
            Marshal.Copy(outBuf, managedArray, 0, outBufSize);
            if (status)
            {
                return "Succeeded";
            }
            else
            {
                return "Failure Win32 Error (" + Marshal.GetLastWin32Error().ToString() + ")";
            }
        }

        public static string DeleteWritableXVDKey()
        {
            int outBufSize = 0x18;
            int outBufMemSize = 0x18;
            int inBuffSize = 0;
            Int32 lpBytesReturned = 0;
            IntPtr pMemoryAddress = IntPtr.Zero;
            IntPtr lpInBuffer = Marshal.AllocHGlobal(inBuffSize);
            IntPtr outBuf = Marshal.AllocHGlobal(outBufMemSize);
            uint ioctlcall = 0x222078;
            string lpDeviceName = @"\\.\pspsra";

            IntPtr handle = DllImports.CreateFile
                   (lpDeviceName,
                   0xC0000000,
                   3,
                   0,
                   3,
                   DllImports.ACCESS_MASK.UNSPECIFIED,
                   0);
            bool status = DllImports.DeviceIoControl
           (
               handle,         // HANDLE
               ioctlcall,       // IOCTL   
               lpInBuffer,    // inBuffer
               (uint)inBuffSize,              // inBufferSize
               outBuf,         // outBuffer
               outBufSize,    // outBuffer Size
               lpBytesReturned,       // bytesReturned
               0               // lpOverlapped
           );
            byte[] managedArray = new byte[outBufSize];
            Marshal.Copy(outBuf, managedArray, 0, outBufSize);
            if (status)
            {
                return "Succeeded";
            }
            else
            {
                return "Failure Win32 Error (" + Marshal.GetLastWin32Error().ToString() + ")";
            }
        }

        public static string AuthorizeXvd()
        {
            int outBufSize = 0x1018;
            int outBufMemSize = 0x1018;
            int inBuffSize = 0x1018;
            Int32 lpBytesReturned = 0;
            IntPtr pMemoryAddress = IntPtr.Zero;
            IntPtr lpInBuffer = Marshal.AllocHGlobal(inBuffSize);
            IntPtr outBuf = Marshal.AllocHGlobal(outBufMemSize);
            uint ioctlcall = 0x222020;
            string lpDeviceName = @"\\.\pspsra";

            IntPtr handle = DllImports.CreateFile
                   (lpDeviceName,
                   0xC0000000,
                   3,
                   0,
                   3,
                   DllImports.ACCESS_MASK.UNSPECIFIED,
                   0);
            bool status = DllImports.DeviceIoControl
           (
               handle,         // HANDLE
               ioctlcall,       // IOCTL   
               lpInBuffer,    // inBuffer
               (uint)inBuffSize,              // inBufferSize
               outBuf,         // outBuffer
               outBufSize,    // outBuffer Size
               lpBytesReturned,       // bytesReturned
               0               // lpOverlapped
           );
            byte[] managedArray = new byte[outBufSize];
            Marshal.Copy(outBuf, managedArray, 0, outBufSize);
            if (status)
            {
                return "Succeeded";
            }
            else
            {
                return "Failure Win32 Error (" + Marshal.GetLastWin32Error().ToString() + ")";
            }
        }

        public static string GetDynamic(int outbuffersize, int inbuffersize, uint ioctrladdress)
        {
            int outBufSize = outbuffersize;
            int outBufMemSize = outbuffersize;
            int inBuffSize = inbuffersize;
            Int32 lpBytesReturned = 0;
            IntPtr pMemoryAddress = IntPtr.Zero;
            IntPtr lpInBuffer = Marshal.AllocHGlobal(inBuffSize);
            IntPtr outBuf = Marshal.AllocHGlobal(outBufMemSize);
            uint ioctlcall = ioctrladdress;
            string lpDeviceName = @"\\.\pspsra";

            IntPtr handle = DllImports.CreateFile
                   (lpDeviceName,
                   0xC0000000,
                   3,
                   0,
                   3,
                   DllImports.ACCESS_MASK.UNSPECIFIED,
                   0);
            bool status = DllImports.DeviceIoControl
           (
               handle,         // HANDLE
               ioctlcall,       // IOCTL   
               IntPtr.Zero,    // inBuffer
               (uint)inBuffSize,              // inBufferSize
               outBuf,         // outBuffer
               outBufSize,    // outBuffer Size
               lpBytesReturned,       // bytesReturned
               0               // lpOverlapped
           );
            byte[] managedArray = new byte[outBufSize];
            Marshal.Copy(outBuf, managedArray, 0, outBufSize);
            string buffer = "";
            foreach (byte thing in managedArray)
            {

                buffer += thing.ToString();
            }
            Marshal.ReAllocCoTaskMem(outBuf, outBufSize);
            return buffer;
        }

       

    }
}
