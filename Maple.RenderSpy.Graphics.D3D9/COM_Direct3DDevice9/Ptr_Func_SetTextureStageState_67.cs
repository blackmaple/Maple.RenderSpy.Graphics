using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 设置纹理阶段状态
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetTextureStageState_67(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DTEXTURESTAGESTATETYPE, uint, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DTEXTURESTAGESTATETYPE, uint, COM_HRESULT>)ptr;

        public const string Name = "SetTextureStageState";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint Stage, global::Windows.Win32.Graphics.Direct3D9.D3DTEXTURESTAGESTATETYPE Type, uint Value) => _proc(pThis, Stage, Type, Value);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
