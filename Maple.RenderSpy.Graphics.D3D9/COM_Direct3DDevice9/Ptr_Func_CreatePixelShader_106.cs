using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 创建像素着色器
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreatePixelShader_106(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint*, void**, int> _proc = (delegate* unmanaged[Stdcall]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint*, void**, int>)ptr;

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
