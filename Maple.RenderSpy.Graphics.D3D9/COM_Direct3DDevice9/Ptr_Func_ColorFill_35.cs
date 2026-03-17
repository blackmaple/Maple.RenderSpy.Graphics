using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 颜色填充
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_ColorFill_35(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT>, uint, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT>, uint, COM_HRESULT>)ptr;

        public const string Name = "ColorFill";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> pThis, nint pSurface, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT> pRect, uint color) => _proc(pThis, pSurface, pRect, color);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
