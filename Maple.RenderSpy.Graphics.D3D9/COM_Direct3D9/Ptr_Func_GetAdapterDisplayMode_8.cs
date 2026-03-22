using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9
{
    /// <summary>
    /// 封装 IDirect3D9::GetAdapterDisplayMode 函数指针 (VTable 索引 8)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetAdapterDisplayMode_8(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DDISPLAYMODE*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DDISPLAYMODE*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Adapter, D3DDISPLAYMODE* pMode) => _proc(pThis, Adapter, pMode);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}