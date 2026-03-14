using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::GetBackBuffer 函数指针 (VTable 索引 18)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetBackBuffer_18(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, D3DBACKBUFFER_TYPE, void**, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, D3DBACKBUFFER_TYPE, void**, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint iSwapChain, uint iBackBuffer, D3DBACKBUFFER_TYPE Type, void** ppBackBuffer) => _proc(pThis, iSwapChain, iBackBuffer, Type, ppBackBuffer);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
