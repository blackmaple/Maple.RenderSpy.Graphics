using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::CreateTexture 函数指针 (VTable 索引 23)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateTexture_23(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, uint, uint, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, global::Windows.Win32.Graphics.Direct3D9.D3DPOOL, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, uint, uint, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, global::Windows.Win32.Graphics.Direct3D9.D3DPOOL, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, COM_HRESULT>)ptr;

        public const string Name = "CreateTexture";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint Width, uint Height, uint Levels, uint Usage, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT Format, global::Windows.Win32.Graphics.Direct3D9.D3DPOOL Pool, Maple.UnmanagedExtensions.UnsafeOut<nint> ppTexture, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE> pSharedHandle) => _proc(pThis, Width, Height, Levels, Usage, Format, Pool, ppTexture, pSharedHandle);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
