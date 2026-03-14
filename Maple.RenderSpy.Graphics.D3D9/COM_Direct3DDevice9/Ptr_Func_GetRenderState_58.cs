using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::GetRenderState 函数指针 (VTable 索引 58)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetRenderState_58(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, D3DRENDERSTATETYPE, uint*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, D3DRENDERSTATETYPE, uint*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, D3DRENDERSTATETYPE State, uint* pValue) => _proc(pThis, State, pValue);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
