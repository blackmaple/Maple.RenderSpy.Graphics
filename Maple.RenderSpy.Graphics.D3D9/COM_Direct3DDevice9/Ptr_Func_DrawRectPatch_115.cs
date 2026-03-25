using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 绘制矩形补丁
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_DrawRectPatch_115(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<float>, Maple.UnmanagedExtensions.UnsafeOut<global::Windows.Win32.Graphics.Direct3D9.D3DRECTPATCH_INFO>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<float>, Maple.UnmanagedExtensions.UnsafeOut<global::Windows.Win32.Graphics.Direct3D9.D3DRECTPATCH_INFO>, COM_HRESULT>)ptr;

        public const string Name = "DrawRectPatch";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint Handle, Maple.UnmanagedExtensions.UnsafeRef<float> pNumSegs, Maple.UnmanagedExtensions.UnsafeOut<global::Windows.Win32.Graphics.Direct3D9.D3DRECTPATCH_INFO> pRectPatchInfo) => _proc(pThis, Handle, pNumSegs, pRectPatchInfo);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
