using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 设置流源频率
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetStreamSourceFreq_102(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        // 原函数指针: private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, int>)ptr;
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, COM_HRESULT>)ptr;

        public const string Name = "SetStreamSourceFreq";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint StreamNumber, uint Divider) => _proc(pThis, StreamNumber, Divider);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
