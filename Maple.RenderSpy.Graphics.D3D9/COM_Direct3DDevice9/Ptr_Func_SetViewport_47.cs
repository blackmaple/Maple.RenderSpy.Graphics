using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::SetViewport 函数指针 (VTable 索引 47)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetViewport_47(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, D3DVIEWPORT9*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, D3DVIEWPORT9*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, D3DVIEWPORT9* pViewport) => _proc(pThis, pViewport);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
