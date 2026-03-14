using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::SetLight 函数指针 (VTable 索引 51)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetLight_51(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DLIGHT9*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DLIGHT9*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Index, D3DLIGHT9* pLight) => _proc(pThis, Index, pLight);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
