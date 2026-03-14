using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 设置纹理阶段状态
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetTextureStageState_67(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Direct3D9.D3DTEXTURESTAGESTATETYPE, uint, int> _proc = (delegate* unmanaged[Stdcall]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Direct3D9.D3DTEXTURESTAGESTATETYPE, uint, int>)ptr;

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
