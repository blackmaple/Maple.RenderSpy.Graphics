using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace Maple.RenderSpy.Graphics.D3D9.TempWindow
{
    internal unsafe sealed class D3D9TempWindow : IDisposable
    {
 
        HWND WindowHandle;

        public D3D9TempWindow()
        {

            char* className = stackalloc char[32] {
                    'D', '3', 'D', '9', 'T', 'e', 'm', 'p',
                    'W', 'i', 'n', 'd', 'o', 'w', 'C', 'l',
                    'a', 's', 's', '\0', '\0', '\0', '\0', '\0',
                    '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0'  };

            var wc = new WNDCLASSEXW
            {
                cbSize = (uint)Unsafe.SizeOf<WNDCLASSEXW>(),
                style = WNDCLASS_STYLES.CS_OWNDC,// CS_HREDRAW | CS_VREDRAW
                lpfnWndProc = &DefWindowProc,
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = PInvoke.GetModuleHandle(new Windows.Win32.Foundation.PCWSTR()),
                hIcon = HICON.Null,
                hCursor = HCURSOR.Null,
                hbrBackground = Windows.Win32.Graphics.Gdi.HBRUSH.Null, // COLOR_WINDOW + 1 的转换
                lpszMenuName = new Windows.Win32.Foundation.PCWSTR(),
                lpszClassName = new Windows.Win32.Foundation.PCWSTR(className),
                hIconSm = HICON.Null,
            };

            if (PInvoke.RegisterClassEx(in wc) != 0)
            {
                WindowHandle = PInvoke.CreateWindowEx(0, wc.lpszClassName, new PCWSTR(), WINDOW_STYLE.WS_OVERLAPPEDWINDOW, 0, 0, 1, 1, HWND.Null, HMENU.Null, wc.hInstance, default);
            }

        }


        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        internal static LRESULT DefWindowProc(HWND hWnd, uint uMsg, WPARAM wParam, LPARAM lParam)
        {
            return PInvoke.DefWindowProc(hWnd, uMsg, wParam, lParam);
        }

        public void Dispose()
        {
            if (!this.WindowHandle.IsNull)
            {
                PInvoke.DestroyWindow(this.WindowHandle);
                this.WindowHandle = HWND.Null;
            }
        }
    }
}
