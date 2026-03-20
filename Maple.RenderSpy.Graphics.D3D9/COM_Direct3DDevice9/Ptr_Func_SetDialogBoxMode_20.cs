using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 设置对话框模式
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetDialogBoxMode_20(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        // 原函数指针: private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, int, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, int, int>)ptr;
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, int, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, int, COM_HRESULT>)ptr;

        public const string Name = "SetDialogBoxMode";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, int bEnableDialogs) => _proc(pThis, bEnableDialogs);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
