using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::CreateOffscreenPlainSurface 函数指针 (VTable 索引 36)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateOffscreenPlainSurface_36(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, D3DFORMAT, D3DPOOL, void**, HANDLE*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, D3DFORMAT, D3DPOOL, void**, HANDLE*, int>)ptr;

        public const string Name = "CreateOffscreenPlainSurface";

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Width, uint Height, D3DFORMAT Format, D3DPOOL Pool, void** ppSurface, HANDLE* pSharedHandle) => _proc(pThis, Width, Height, Format, Pool, ppSurface, pSharedHandle);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
