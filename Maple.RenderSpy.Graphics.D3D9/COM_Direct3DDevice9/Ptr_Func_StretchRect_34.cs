using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::StretchRect 函数指针 (VTable 索引 34)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_StretchRect_34(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, void*, RECT*, void*, RECT*, D3DTEXTUREFILTERTYPE, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, void*, RECT*, void*, RECT*, D3DTEXTUREFILTERTYPE, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, void* pSourceSurface, RECT* pSourceRect, void* pDestSurface, RECT* pDestRect, D3DTEXTUREFILTERTYPE Filter) => _proc(pThis, pSourceSurface, pSourceRect, pDestSurface, pDestRect, Filter);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
