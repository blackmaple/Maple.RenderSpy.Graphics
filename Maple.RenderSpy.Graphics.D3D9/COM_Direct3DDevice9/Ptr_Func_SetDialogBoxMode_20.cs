using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::SetDialogBoxMode 函数指针 (VTable 索引 20)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetDialogBoxMode_20(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, int, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, int, int>)ptr;

        public const string Name = "SetDialogBoxMode";

        public int Invoke(COM_PTR_IUNKNOWN pThis, int bEnableDialogs) => _proc(pThis, bEnableDialogs);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
