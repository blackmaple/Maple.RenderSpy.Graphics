using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 获取光栅状态
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetRasterStatus_19(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DRASTER_STATUS>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DRASTER_STATUS>, COM_HRESULT>)ptr;

        public const string Name = "GetRasterStatus";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint iSwapChain, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DRASTER_STATUS> pRasterStatus) => _proc(pThis, iSwapChain, pRasterStatus);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
