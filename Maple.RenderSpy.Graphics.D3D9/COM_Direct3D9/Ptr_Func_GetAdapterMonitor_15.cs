using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9
{
    /// <summary>
    /// 封装 IDirect3D9::GetAdapterMonitor 函数指针 (VTable 索引 15)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetAdapterMonitor_15(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, void*> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, void*>)ptr;

        public void* Invoke(COM_PTR_IUNKNOWN pThis, uint Adapter) => _proc(pThis, Adapter);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}