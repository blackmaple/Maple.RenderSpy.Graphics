using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::GetRenderState 函数指针 (VTable 索引 58)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetRenderState_58(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, global::Windows.Win32.Graphics.Direct3D9.D3DRENDERSTATETYPE, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, global::Windows.Win32.Graphics.Direct3D9.D3DRENDERSTATETYPE, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT>)ptr;

        public const string Name = "GetRenderState";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, global::Windows.Win32.Graphics.Direct3D9.D3DRENDERSTATETYPE State, Maple.UnmanagedExtensions.UnsafeRef<int> pValue) => _proc(pThis, State, pValue);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
