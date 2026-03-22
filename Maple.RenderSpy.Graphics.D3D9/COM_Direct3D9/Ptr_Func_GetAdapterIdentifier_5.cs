using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9
{
    /// <summary>
    /// 封装 IDirect3D9::GetAdapterIdentifier 函数指针 (VTable 索引 5)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetAdapterIdentifier_5(nint ptr)
    {
        //D3DADAPTER_IDENTIFIER9
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, void*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, void*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Adapter, uint Flags, void* pIdentifier) => _proc(pThis, Adapter, Flags, pIdentifier);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}