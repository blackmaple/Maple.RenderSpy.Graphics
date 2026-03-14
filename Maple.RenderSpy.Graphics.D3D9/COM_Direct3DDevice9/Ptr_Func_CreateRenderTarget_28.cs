using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::CreateRenderTarget 函数指针 (VTable 索引 28)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateRenderTarget_28(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, D3DFORMAT, D3DMULTISAMPLE_TYPE, uint, int, void**, HANDLE*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, D3DFORMAT, D3DMULTISAMPLE_TYPE, uint, int, void**, HANDLE*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Width, uint Height, D3DFORMAT Format, D3DMULTISAMPLE_TYPE MultiSample, uint MultisampleQuality, int Lockable, void** ppSurface, HANDLE* pSharedHandle) => _proc(pThis, Width, Height, Format, MultiSample, MultisampleQuality, Lockable, ppSurface, pSharedHandle);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
