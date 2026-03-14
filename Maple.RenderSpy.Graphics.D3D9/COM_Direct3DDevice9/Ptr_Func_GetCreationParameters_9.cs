using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::GetCreationParameters 函数指针 (VTable 索引 9)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetCreationParameters_9(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, D3DDEVICE_CREATION_PARAMETERS*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, D3DDEVICE_CREATION_PARAMETERS*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, D3DDEVICE_CREATION_PARAMETERS* pParameters) => _proc(pThis, pParameters);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
