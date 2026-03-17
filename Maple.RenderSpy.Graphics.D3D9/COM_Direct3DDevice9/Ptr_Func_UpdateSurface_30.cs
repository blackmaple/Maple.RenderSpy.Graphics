using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;
using Maple.UnmanagedExtensions;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 更新表面
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_UpdateSurface_30(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
 
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT>, nint, UnsafeRef<global::System.Drawing.Point>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT>, nint, UnsafeRef<global::System.Drawing.Point>, COM_HRESULT>)ptr;
         
        public const string Name = "UpdateSurface";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> pThis, nint pSourceSurface, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT> pSourceRect, nint pDestinationSurface, UnsafeRef<global::System.Drawing.Point> pDestPoint) => _proc(pThis, pSourceSurface, pSourceRect, pDestinationSurface, pDestPoint);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
