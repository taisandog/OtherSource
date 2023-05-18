using System;
using System.Drawing;
using System.Runtime.InteropServices;


namespace Buffalo.Win32Kernel.Win32
{

    
    public struct COPYDATASTRUCT
    {
        public IntPtr dwData;
        public int cbData;
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpData;

    }
    
}

