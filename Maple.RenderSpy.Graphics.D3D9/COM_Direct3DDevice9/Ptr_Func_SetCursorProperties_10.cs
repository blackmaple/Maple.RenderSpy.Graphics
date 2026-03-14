using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::SetCursorProperties 函数指针 (VTable 索引 10)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetCursorProperties_10(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, void*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, void*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint XHotSpot, uint YHotSpot, void* pCursorBitmap) => _proc(pThis, XHotSpot, YHotSpot, pCursorBitmap);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
