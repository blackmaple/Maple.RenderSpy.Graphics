using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 绘制用户指针图元
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_DrawPrimitiveUP_83(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        // 原函数指针: private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, D3DPRIMITIVETYPE, uint, nint, uint, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, D3DPRIMITIVETYPE, uint, nint, uint, int>)ptr;
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DPRIMITIVETYPE, uint, nint, uint, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DPRIMITIVETYPE, uint, nint, uint, COM_HRESULT>)ptr;

        public const string Name = "DrawPrimitiveUP";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> pThis, D3DPRIMITIVETYPE PrimitiveType, uint PrimitiveCount, nint pVertexStreamZeroData, uint VertexStreamZeroStride) => _proc(pThis, PrimitiveType, PrimitiveCount, pVertexStreamZeroData, VertexStreamZeroStride);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
