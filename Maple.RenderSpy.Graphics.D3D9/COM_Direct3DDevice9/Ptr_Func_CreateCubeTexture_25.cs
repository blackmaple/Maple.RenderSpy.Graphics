using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::CreateCubeTexture 函数指针 (VTable 索引 25)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateCubeTexture_25(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, uint, D3DFORMAT, D3DPOOL, void**, HANDLE*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, uint, D3DFORMAT, D3DPOOL, void**, HANDLE*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint EdgeLength, uint Levels, uint Usage, D3DFORMAT Format, D3DPOOL Pool, void** ppCubeTexture, HANDLE* pSharedHandle) => _proc(pThis, EdgeLength, Levels, Usage, Format, Pool, ppCubeTexture, pSharedHandle);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
