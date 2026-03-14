using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::SetDepthStencilSurface 函数指针 (VTable 索引 39)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetDepthStencilSurface_39(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, void*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, void*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, void* pNewZStencil) => _proc(pThis, pNewZStencil);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
