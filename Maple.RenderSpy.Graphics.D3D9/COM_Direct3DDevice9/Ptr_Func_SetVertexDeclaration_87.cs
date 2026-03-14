using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 设置顶点声明
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetVertexDeclaration_87(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, int> _proc = (delegate* unmanaged[Stdcall]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, int>)ptr;

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
