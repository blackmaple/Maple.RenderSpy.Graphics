using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9
{
    /// <summary>
    /// 封装 IDirect3D9::GetAdapterCount 函数指针 (VTable 索引 4)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetAdapterCount_4(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint>)ptr;

        public uint Invoke(COM_PTR_IUNKNOWN pThis) => _proc(pThis); 
        
        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}