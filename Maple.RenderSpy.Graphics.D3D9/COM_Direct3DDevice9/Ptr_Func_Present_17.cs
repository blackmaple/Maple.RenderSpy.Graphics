using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Gdi;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::Present 函数指针 (VTable 索引 17)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_Present_17(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT>, nint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Gdi.RGNDATA>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT>, nint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Gdi.RGNDATA>, COM_HRESULT>)ptr;

        public const string Name = "Present";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> pThis, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT> pSourceRect, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT> pDestRect, nint hDestWindowOverride, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Gdi.RGNDATA> pDirtyRegion) => _proc(pThis, pSourceRect, pDestRect, hDestWindowOverride, pDirtyRegion);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
