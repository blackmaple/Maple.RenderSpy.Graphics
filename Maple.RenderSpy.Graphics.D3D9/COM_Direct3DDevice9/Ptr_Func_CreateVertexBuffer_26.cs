using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::CreateVertexBuffer 函数指针 (VTable 索引 26)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateVertexBuffer_26(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, uint, D3DPOOL, void**, HANDLE*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, uint, D3DPOOL, void**, HANDLE*, int>)ptr;

        public const string Name = "CreateVertexBuffer";

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Length, uint Usage, uint FVF, D3DPOOL Pool, void** ppVertexBuffer, HANDLE* pSharedHandle) => _proc(pThis, Length, Usage, FVF, Pool, ppVertexBuffer, pSharedHandle);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
