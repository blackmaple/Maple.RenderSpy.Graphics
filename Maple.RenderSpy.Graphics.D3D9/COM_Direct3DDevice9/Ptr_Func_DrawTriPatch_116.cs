using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 绘制三角形补丁
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_DrawTriPatch_116(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<float>, Maple.UnmanagedExtensions.UnsafeOut<global::Windows.Win32.Graphics.Direct3D9.D3DTRIPATCH_INFO>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<float>, Maple.UnmanagedExtensions.UnsafeOut<global::Windows.Win32.Graphics.Direct3D9.D3DTRIPATCH_INFO>, COM_HRESULT>)ptr;

        public const string Name = "DrawTriPatch";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint Handle, Maple.UnmanagedExtensions.UnsafeRef<float> pNumSegs, Maple.UnmanagedExtensions.UnsafeOut<global::Windows.Win32.Graphics.Direct3D9.D3DTRIPATCH_INFO> pTriPatchInfo) => _proc(pThis, Handle, pNumSegs, pTriPatchInfo);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
