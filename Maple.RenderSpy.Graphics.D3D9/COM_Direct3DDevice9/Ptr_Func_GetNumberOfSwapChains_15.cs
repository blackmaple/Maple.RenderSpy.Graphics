using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::GetNumberOfSwapChains 函数指针 (VTable 索引 15)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetNumberOfSwapChains_15(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint>)ptr;

        public uint Invoke(COM_PTR_IUNKNOWN pThis) => _proc(pThis);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
