using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9
{
    /// <summary>
    /// 封装 IDirect3D9::CheckDepthStencilMatch 函数指针 (VTable 索引 12)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CheckDepthStencilMatch_12(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DDEVTYPE, D3DFORMAT, D3DFORMAT, D3DFORMAT, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DDEVTYPE, D3DFORMAT, D3DFORMAT, D3DFORMAT, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Adapter, D3DDEVTYPE DeviceType, D3DFORMAT AdapterFormat, D3DFORMAT RenderTargetFormat, D3DFORMAT DepthStencilFormat) => _proc(pThis, Adapter, DeviceType, AdapterFormat, RenderTargetFormat, DepthStencilFormat);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}