using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 获取纹理阶段状态
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetTextureStageState_66(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DTEXTURESTAGESTATETYPE, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DTEXTURESTAGESTATETYPE, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT>)ptr;

        public const string Name = "GetTextureStageState";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> pThis, uint Stage, global::Windows.Win32.Graphics.Direct3D9.D3DTEXTURESTAGESTATETYPE Type, Maple.UnmanagedExtensions.UnsafeRef<int> pValue) => _proc(pThis, Stage, Type, pValue);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
