using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::CreateStateBlock 函数指针 (VTable 索引 59)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateStateBlock_59(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, D3DSTATEBLOCKTYPE, void**, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, D3DSTATEBLOCKTYPE, void**, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, D3DSTATEBLOCKTYPE Type, void** ppSB) => _proc(pThis, Type, ppSB);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
