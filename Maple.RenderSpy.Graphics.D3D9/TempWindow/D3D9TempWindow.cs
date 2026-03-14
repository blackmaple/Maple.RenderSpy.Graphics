using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using Windows.Win32;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.TempWindow
{
    internal unsafe struct D3D9TempWindow(HWND hwnd) : IDisposable
    {
        private HWND _WindowHandle = hwnd;

        public void Dispose()
        {
            var hWnd = this._WindowHandle;
            this._WindowHandle = HWND.Null;
            if (!hWnd.IsNull)
            {
                PInvoke.DestroyWindow(hWnd);
            }
        }

        public readonly override string ToString()
        {
            return (new nint(this._WindowHandle.Value)).ToString("X8");
        }

        public static implicit operator nint(D3D9TempWindow x) => new  (x._WindowHandle.Value);
        public static implicit operator void*(D3D9TempWindow x) => x._WindowHandle;
        public static implicit operator bool(D3D9TempWindow x) => !x._WindowHandle.IsNull;
        public static implicit operator HWND(D3D9TempWindow x) => x._WindowHandle;

    }
}
