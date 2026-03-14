using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 获取索引缓冲区
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetIndices_105(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void**, int> _proc = (delegate* unmanaged[Stdcall]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void**, int>)ptr;

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
