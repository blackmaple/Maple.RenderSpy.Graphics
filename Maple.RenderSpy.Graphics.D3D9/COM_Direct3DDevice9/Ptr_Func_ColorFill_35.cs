using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::ColorFill 函数指针 (VTable 索引 35)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_ColorFill_35(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, void*, RECT*, uint, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, void*, RECT*, uint, int>)ptr;

        public const string Name = "ColorFill";

        public int Invoke(COM_PTR_IUNKNOWN pThis, void* pSurface, RECT* pRect, uint color) => _proc(pThis, pSurface, pRect, color);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
