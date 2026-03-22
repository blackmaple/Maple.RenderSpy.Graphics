using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 获取后台缓冲区
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetBackBuffer_18(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, global::Windows.Win32.Graphics.Direct3D9.D3DBACKBUFFER_TYPE, Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, global::Windows.Win32.Graphics.Direct3D9.D3DBACKBUFFER_TYPE, Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT>)ptr;

        public const string Name = "GetBackBuffer";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint iSwapChain, uint iBackBuffer, global::Windows.Win32.Graphics.Direct3D9.D3DBACKBUFFER_TYPE Type, Maple.UnmanagedExtensions.UnsafeOut<nint> ppBackBuffer) => _proc(pThis, iSwapChain, iBackBuffer, Type, ppBackBuffer);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
