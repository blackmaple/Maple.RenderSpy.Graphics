using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 获取像素着色器浮点常量
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetPixelShaderConstantF_110(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, float*, uint, int> _proc = (delegate* unmanaged[Stdcall]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, float*, uint, int>)ptr;

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
