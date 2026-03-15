using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 绘制索引用户指针图元
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_DrawIndexedPrimitiveUP_84(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D9.D3DPRIMITIVETYPE, uint, uint, uint, void*, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, void*, uint, int> _proc = (delegate* unmanaged[Stdcall]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D9.D3DPRIMITIVETYPE, uint, uint, uint, void*, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, void*, uint, int>)ptr;

        public const string Name = "DrawIndexedPrimitiveUP";

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
