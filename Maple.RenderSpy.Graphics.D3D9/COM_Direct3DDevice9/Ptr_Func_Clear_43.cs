using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::Clear 函数指针 (VTable 索引 43)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_Clear_43(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DRECT*, uint, uint, float, uint, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DRECT*, uint, uint, float, uint, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Count, D3DRECT* pRects, uint Flags, uint Color, float Z, uint Stencil) => _proc(pThis, Count, pRects, Flags, Color, Z, Stencil);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
