using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::UpdateSurface 函数指针 (VTable 索引 30)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_UpdateSurface_30(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, void*, RECT*, void*, System.Drawing.Point*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, void*, RECT*, void*, System.Drawing.Point*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, void* pSourceSurface, RECT* pSourceRect, void* pDestinationSurface, System.Drawing.Point* pDestPoint) => _proc(pThis, pSourceSurface, pSourceRect, pDestinationSurface, pDestPoint);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
