using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9
{
    /// <summary>
    /// 封装 IDirect3D9::GetAdapterIdentifier 函数指针 (VTable 索引 5)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetAdapterIdentifier_5(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, D3DADAPTER_IDENTIFIER9*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, D3DADAPTER_IDENTIFIER9*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Adapter, uint Flags, D3DADAPTER_IDENTIFIER9* pIdentifier) => _proc(pThis, Adapter, Flags, pIdentifier);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}