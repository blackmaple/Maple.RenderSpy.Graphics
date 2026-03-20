using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::SetRenderState 函数指针 (VTable 索引 57)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetRenderState_57(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, global::Windows.Win32.Graphics.Direct3D9.D3DRENDERSTATETYPE, uint, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, global::Windows.Win32.Graphics.Direct3D9.D3DRENDERSTATETYPE, uint, COM_HRESULT>)ptr;

        public const string Name = "SetRenderState";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, global::Windows.Win32.Graphics.Direct3D9.D3DRENDERSTATETYPE State, uint Value) => _proc(pThis, State, Value);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
