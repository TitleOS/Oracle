using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DLLIMPORTS
{
    public class DllImports
    {
        public const uint GENERIC_READ = 0x80000000;
        public const uint GENERIC_WRITE = 0x40000000;
        public const uint OPEN_EXISTING = 3;

        [DllImport("KernelBase.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("KernelBase.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("KernelBase.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("KernelBase")]
        public static extern IntPtr VirtualAlloc(IntPtr lpStartAddr,
                 UInt32 size, AllocationType flAllocationType, MemoryProtection flProtect);

        [DllImport("msvcrt.dll", EntryPoint = "memset", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern IntPtr MemSet(IntPtr dest, int c, int byteCount);

        [DllImport("KernelBase.dll", SetLastError = true)]
        public static extern UInt32 GetProcessHeaps(
        UInt32 NumberOfHeaps,
        IntPtr[] ProcessHeaps);

        [DllImport("KernelBase.dll", SetLastError = false)]
        public static extern IntPtr HeapAlloc(IntPtr hHeap, HeapAllocFlags dwFlags, int dwBytes);

        [DllImport("KernelBase")]
        public static extern IntPtr CreateThread(

          UInt32 lpThreadAttributes,
          UInt32 dwStackSize,
          UInt32 lpStartAddress,
          IntPtr param,
          UInt32 dwCreationFlags,
          ref UInt32 lpThreadId

          );

        [DllImport("KernelBase")]
        public static extern UInt32 WaitForSingleObject(

          IntPtr hHandle,
          UInt32 dwMilliseconds
          );


        [DllImport("KernelBase.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public static extern unsafe IntPtr CreateFile
        (
            string FileName,                 // file name
            UInt32 DesiredAccess,       // access mode
            uint ShareMode,                  // share mode
            uint SecurityAttributes,         // Security Attributes
            uint CreationDisposition,        // how to create
            ACCESS_MASK FlagsAndAttributes,         // file attributes
            int hTemplateFile                // handle to template file
        );

        [DllImport("KernelBase", SetLastError = true)]
        static extern unsafe bool ReadFile
        (
            IntPtr hFile,      // handle to file
            void* pBuffer,            // data buffer
            uint NumberOfBytesToRead,  // number of bytes to read
            uint* pNumberOfBytesRead,  // number of bytes read
            int Overlapped            // overlapped buffer
        );

        [DllImport("KernelBase", SetLastError = true)]
        static extern unsafe bool CloseHandle
        (
            System.IntPtr hObject // handle to object
        );


        [DllImport("KernelBase.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static unsafe extern bool DeviceIoControl(
          IntPtr hDevice,
          uint dwIoControlCode,
          IntPtr lpInBuffer,
          uint nInBufferSize,
          IntPtr OutBuffer,
          int nOutBufferSize,
          long pBytesReturned,
          uint pOverlapped
            );


        [DllImport("XVIO", CharSet = CharSet.Auto, SetLastError = true)]
        public static unsafe extern bool XvioInitialize(
          int _XVIO_SERVICE_ID,            // ServiceId
          Int64 PartitionId,               // PartitionId
          Int32 _XVIO_INIT_FLAGS           // Flags
          );

        [DllImport("XVIO", CharSet = CharSet.Auto, SetLastError = true)]
        public static unsafe extern bool XvioCreateRingBuffer(
          int _XVIO_SERVICE_ID,            // ServiceId
          Int64 PartitionId,               // PartitionId
          Int16 _XVIO_INIT_FLAGS,          // Flags
          uint IncomingPageCount,
          uint OutgoingPageCount,
          IntPtr _XVIO_RING_CONTEXT
          );

        [DllImport("XVIO", CharSet = CharSet.Auto, SetLastError = true)]
        public static unsafe extern bool XvioWriteRingBuffer(
          Int64 ringBufferContext,            // Buffer Context
          string data,                      // Write data
          Int64 a3,          
          Int64 a4,
          Int64 Timeouta
          );

        [DllImport("XVIO", CharSet = CharSet.Auto, SetLastError = true)]
        public static unsafe extern bool XvioGetRingBufferContext(
          Int64 ringBufferContext,            // Buffer Context
          string data,                      
          Int64 a3,         
          Int64 a4,
          Int64 Timeouta
          );

        [Flags]
        public enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        [Flags]
        public enum MemoryProtection
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }

        [Flags]
        public enum HeapAllocFlags : uint
        {
            HEAP_NO_FLAGS_ZERO = 0x00000000,
            HEAP_GENERATE_EXCEPTIONS = 0x00000004,
            HEAP_NO_SERIALIZE = 0x00000001,
            HEAP_ZERO_MEMORY = 0x00000008
        }

        [Flags]
        public enum ACCESS_MASK : uint
        {
            UNSPECIFIED = 0x00000000,
            DELETE = 0x00010000,
            READ_CONTROL = 0x00020000,
            WRITE_DAC = 0x00040000,
            WRITE_OWNER = 0x00080000,
            SYNCHRONIZE = 0x00100000,

            STANDARD_RIGHTS_REQUIRED = 0x000F0000,

            STANDARD_RIGHTS_READ = 0x00020000,
            STANDARD_RIGHTS_WRITE = 0x00020000,
            STANDARD_RIGHTS_EXECUTE = 0x00020000,

            STANDARD_RIGHTS_ALL = 0x001F0000,

            SPECIFIC_RIGHTS_ALL = 0x0000FFFF,

            ACCESS_SYSTEM_SECURITY = 0x01000000,

            MAXIMUM_ALLOWED = 0x02000000,

            GENERIC_READ = 0x80000000,
            GENERIC_WRITE = 0x40000000,
            GENERIC_EXECUTE = 0x20000000,
            FILE_FLAG_OVERLAPPED = 0x40000000,
            GENERIC_ALL = 0x10000000,

            DESKTOP_READOBJECTS = 0x00000001,
            DESKTOP_CREATEWINDOW = 0x00000002,
            DESKTOP_CREATEMENU = 0x00000004,
            DESKTOP_HOOKCONTROL = 0x00000008,
            DESKTOP_JOURNALRECORD = 0x00000010,
            DESKTOP_JOURNALPLAYBACK = 0x00000020,
            DESKTOP_ENUMERATE = 0x00000040,
            DESKTOP_WRITEOBJECTS = 0x00000080,
            DESKTOP_SWITCHDESKTOP = 0x00000100,

            WINSTA_ENUMDESKTOPS = 0x00000001,
            WINSTA_READATTRIBUTES = 0x00000002,
            WINSTA_ACCESSCLIPBOARD = 0x00000004,
            WINSTA_CREATEDESKTOP = 0x00000008,
            WINSTA_WRITEATTRIBUTES = 0x00000010,
            WINSTA_ACCESSGLOBALATOMS = 0x00000020,
            WINSTA_EXITWINDOWS = 0x00000040,
            WINSTA_ENUMERATE = 0x00000100,
            WINSTA_READSCREEN = 0x00000200,

            WINSTA_ALL_ACCESS = 0x0000037F
        }

        [Flags]
        public enum OpenFileStyle : uint
        {
            OF_CANCEL = 0x00000800,  // Ignored. For a dialog box with a Cancel button, use OF_PROMPT.
            OF_CREATE = 0x00001000,  // Creates a new file. If file exists, it is truncated to zero (0) length.
            OF_DELETE = 0x00000200,  // Deletes a file.
            OF_EXIST = 0x00004000,  // Opens a file and then closes it. Used to test that a file exists
            OF_PARSE = 0x00000100,  // Fills the OFSTRUCT structure, but does not do anything else.
            OF_PROMPT = 0x00002000,  // Displays a dialog box if a requested file does not exist 
            OF_READ = 0x00000000,  // Opens a file for reading only.
            OF_READWRITE = 0x00000002,  // Opens a file with read/write permissions.
            OF_REOPEN = 0x00008000,  // Opens a file by using information in the reopen buffer.
            OF_FILE_NORMAL = 0x00000080,

            // For MS-DOS–based file systems, opens a file with compatibility mode, allows any process on a 
            // specified computer to open the file any number of times.
            // Other efforts to open a file with other sharing modes fail. This flag is mapped to the 
            // FILE_SHARE_READ|FILE_SHARE_WRITE flags of the CreateFile function.
            OF_SHARE_COMPAT = 0x00000000,

            // Opens a file without denying read or write access to other processes.
            // On MS-DOS-based file systems, if the file has been opened in compatibility mode
            // by any other process, the function fails.
            // This flag is mapped to the FILE_SHARE_READ|FILE_SHARE_WRITE flags of the CreateFile function.
            OF_SHARE_DENY_NONE = 0x00000040,

            // Opens a file and denies read access to other processes.
            // On MS-DOS-based file systems, if the file has been opened in compatibility mode,
            // or for read access by any other process, the function fails.
            // This flag is mapped to the FILE_SHARE_WRITE flag of the CreateFile function.
            OF_SHARE_DENY_READ = 0x00000030,

            // Opens a file and denies write access to other processes.
            // On MS-DOS-based file systems, if a file has been opened in compatibility mode,
            // or for write access by any other process, the function fails.
            // This flag is mapped to the FILE_SHARE_READ flag of the CreateFile function.
            OF_SHARE_DENY_WRITE = 0x00000020,

            // Opens a file with exclusive mode, and denies both read/write access to other processes.
            // If a file has been opened in any other mode for read/write access, even by the current process,
            // the function fails.
            OF_SHARE_EXCLUSIVE = 0x00000010,

            // Verifies that the date and time of a file are the same as when it was opened previously.
            // This is useful as an extra check for read-only files.
            OF_VERIFY = 0x00000400,

            // Opens a file for write access only.
            OF_WRITE = 0x00000001
        }
    }

}