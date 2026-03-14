using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::SetClipPlane 函数指针 (VTable 索引 55)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetClipPlane_55(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, float*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, float*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Index, float* pPlane) => _proc(pThis, Index, pPlane);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
