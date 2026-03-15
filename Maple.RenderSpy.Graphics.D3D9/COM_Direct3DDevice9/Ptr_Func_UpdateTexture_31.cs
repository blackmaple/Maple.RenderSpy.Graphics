using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::UpdateTexture 函数指针 (VTable 索引 31)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_UpdateTexture_31(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, void*, void*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, void*, void*, int>)ptr;

        public const string Name = "UpdateTexture";

        public int Invoke(COM_PTR_IUNKNOWN pThis, void* pSourceTexture, void* pDestinationTexture) => _proc(pThis, pSourceTexture, pDestinationTexture);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
