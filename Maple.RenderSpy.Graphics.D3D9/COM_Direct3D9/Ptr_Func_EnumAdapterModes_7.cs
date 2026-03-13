using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9
{
    /// <summary>
    /// 封装 IDirect3D9::EnumAdapterModes 函数指针 (VTable 索引 7)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_EnumAdapterModes_7(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DFORMAT, uint, D3DDISPLAYMODE*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DFORMAT, uint, D3DDISPLAYMODE*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Adapter, D3DFORMAT Format, uint Mode, D3DDISPLAYMODE* pMode) => _proc(pThis, Adapter, Format, Mode, pMode);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}