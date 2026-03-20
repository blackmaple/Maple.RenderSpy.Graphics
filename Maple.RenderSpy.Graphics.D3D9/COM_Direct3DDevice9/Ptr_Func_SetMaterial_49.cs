using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 设置材质
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetMaterial_49(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DMATERIAL9>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DMATERIAL9>, COM_HRESULT>)ptr;

        public const string Name = "SetMaterial";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DMATERIAL9> pMaterial) => _proc(pThis, pMaterial);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
