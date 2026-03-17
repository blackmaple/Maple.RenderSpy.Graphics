using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 绘制索引用户指针图元
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_DrawIndexedPrimitiveUP_84(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, global::Windows.Win32.Graphics.Direct3D9.D3DPRIMITIVETYPE, uint, uint, uint, nint, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, nint, uint, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, global::Windows.Win32.Graphics.Direct3D9.D3DPRIMITIVETYPE, uint, uint, uint, nint, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, nint, uint, COM_HRESULT>)ptr;

        public const string Name = "DrawIndexedPrimitiveUP";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> pThis, global::Windows.Win32.Graphics.Direct3D9.D3DPRIMITIVETYPE PrimitiveType, uint MinVertexIndex, uint NumVertices, uint PrimitiveCount, nint pIndexData, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT IndexDataFormat, nint pVertexStreamZeroData, uint VertexStreamZeroStride) => _proc(pThis, PrimitiveType, MinVertexIndex, NumVertices, PrimitiveCount, pIndexData, IndexDataFormat, pVertexStreamZeroData, VertexStreamZeroStride);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
