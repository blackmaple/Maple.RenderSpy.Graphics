using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 绘制图元
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_DrawPrimitive_81(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, global::Windows.Win32.Graphics.Direct3D9.D3DPRIMITIVETYPE, uint, uint, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, global::Windows.Win32.Graphics.Direct3D9.D3DPRIMITIVETYPE, uint, uint, COM_HRESULT>)ptr;

        public const string Name = "DrawPrimitive";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, global::Windows.Win32.Graphics.Direct3D9.D3DPRIMITIVETYPE PrimitiveType, uint StartVertex, uint PrimitiveCount) => _proc(pThis, PrimitiveType, StartVertex, PrimitiveCount);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
