using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::SetClipStatus 函数指针 (VTable 索引 62)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetClipStatus_62(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, D3DCLIPSTATUS9*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, D3DCLIPSTATUS9*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, D3DCLIPSTATUS9* pClipStatus) => _proc(pThis, pClipStatus);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
