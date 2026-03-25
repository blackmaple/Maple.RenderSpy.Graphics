using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9
{
    /// <summary>
    /// 封装 IDirect3D9::RegisterSoftwareDevice 函数指针 (VTable 索引 3)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_RegisterSoftwareDevice_3(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, nint, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, nint, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, nint pInitializeFunction) => _proc(pThis, pInitializeFunction);


        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}