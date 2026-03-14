using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::CreateIndexBuffer 函数指针 (VTable 索引 27)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateIndexBuffer_27(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, D3DFORMAT, D3DPOOL, void**, HANDLE*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, D3DFORMAT, D3DPOOL, void**, HANDLE*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Length, uint Usage, D3DFORMAT Format, D3DPOOL Pool, void** ppIndexBuffer, HANDLE* pSharedHandle) => _proc(pThis, Length, Usage, Format, Pool, ppIndexBuffer, pSharedHandle);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
