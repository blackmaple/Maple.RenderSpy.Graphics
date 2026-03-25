using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 设置采样器状态
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetSamplerState_69(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DSAMPLERSTATETYPE, uint, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DSAMPLERSTATETYPE, uint, COM_HRESULT>)ptr;

        public const string Name = "SetSamplerState";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint Sampler, global::Windows.Win32.Graphics.Direct3D9.D3DSAMPLERSTATETYPE Type, uint Value) => _proc(pThis, Sampler, Type, Value);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
