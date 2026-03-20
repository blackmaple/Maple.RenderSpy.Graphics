using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 获取纹理
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetTexture_64(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT>)ptr;

        public const string Name = "GetTexture";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint Stage, Maple.UnmanagedExtensions.UnsafeOut<nint> ppTexture) => _proc(pThis, Stage, ppTexture);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
