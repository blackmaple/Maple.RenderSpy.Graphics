using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 获取显示模式
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetDisplayMode_8(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DDISPLAYMODE>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DDISPLAYMODE>, COM_HRESULT>)ptr;

        public const string Name = "GetDisplayMode";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint iSwapChain, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DDISPLAYMODE> pMode) => _proc(pThis, iSwapChain, pMode);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
