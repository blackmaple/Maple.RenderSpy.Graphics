using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;
using Maple.RenderSpy.Graphics.COM;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 创建索引缓冲区
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateIndexBuffer_27(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, global::Windows.Win32.Graphics.Direct3D9.D3DPOOL, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, global::Windows.Win32.Graphics.Direct3D9.D3DPOOL, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, COM_HRESULT>)ptr;

        public const string Name = "CreateIndexBuffer";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint Length, uint Usage, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT Format, global::Windows.Win32.Graphics.Direct3D9.D3DPOOL Pool, Maple.UnmanagedExtensions.UnsafeOut<nint> ppIndexBuffer, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE> pSharedHandle) => _proc(pThis, Length, Usage, Format, Pool, ppIndexBuffer, pSharedHandle);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
