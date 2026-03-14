using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::GetDisplayMode 函数指针 (VTable 索引 8)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetDisplayMode_8(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DDISPLAYMODE*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DDISPLAYMODE*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint iSwapChain, D3DDISPLAYMODE* pMode) => _proc(pThis, iSwapChain, pMode);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
