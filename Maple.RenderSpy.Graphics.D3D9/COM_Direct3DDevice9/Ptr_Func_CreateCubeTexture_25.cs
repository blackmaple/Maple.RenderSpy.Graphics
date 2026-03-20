using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 创建立方体纹理
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateCubeTexture_25(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, uint, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, global::Windows.Win32.Graphics.Direct3D9.D3DPOOL, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, uint, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, global::Windows.Win32.Graphics.Direct3D9.D3DPOOL, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, COM_HRESULT>)ptr;

        public const string Name = "CreateCubeTexture";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint EdgeLength, uint Levels, uint Usage, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT Format, global::Windows.Win32.Graphics.Direct3D9.D3DPOOL Pool, Maple.UnmanagedExtensions.UnsafeOut<nint> ppCubeTexture, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE> pSharedHandle) => _proc(pThis, EdgeLength, Levels, Usage, Format, Pool, ppCubeTexture, pSharedHandle);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
