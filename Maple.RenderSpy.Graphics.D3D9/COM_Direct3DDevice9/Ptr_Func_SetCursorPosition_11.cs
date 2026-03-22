using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 设置光标位置
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetCursorPosition_11(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        // 原函数指针: private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, int, int, uint, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, int, int, uint, void>)ptr;
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, int, int, uint, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, int, int, uint, void>)ptr;

        public const string Name = "SetCursorPosition";

        public void Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, int X, int Y, uint Flags) => _proc(pThis, X, Y, Flags);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
