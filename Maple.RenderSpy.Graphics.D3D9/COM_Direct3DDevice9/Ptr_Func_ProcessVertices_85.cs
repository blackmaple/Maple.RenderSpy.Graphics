using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 处理顶点
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_ProcessVertices_85(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        // 原函数指针: private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, uint, nint, nint, uint, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, uint, nint, nint, uint, int>)ptr;
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, uint, nint, nint, uint, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, uint, nint, nint, uint, COM_HRESULT>)ptr;

        public const string Name = "ProcessVertices";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint SrcStartIndex, uint DestIndex, uint VertexCount, nint pDestBuffer, nint pVertexDeclaration, uint Flags) => _proc(pThis, SrcStartIndex, DestIndex, VertexCount, pDestBuffer, pVertexDeclaration, Flags);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
