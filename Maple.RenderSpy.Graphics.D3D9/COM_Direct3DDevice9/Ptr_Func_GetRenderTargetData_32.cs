using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::GetRenderTargetData 函数指针 (VTable 索引 32)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetRenderTargetData_32(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, void*, void*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, void*, void*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, void* pRenderTarget, void* pDestSurface) => _proc(pThis, pRenderTarget, pDestSurface);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
