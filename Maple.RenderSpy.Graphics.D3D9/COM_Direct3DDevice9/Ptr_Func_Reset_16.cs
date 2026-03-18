using Maple.RenderSpy.Graphics.D3D;
using Maple.UnmanagedExtensions;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::Reset 函数指针 (VTable 索引 16)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct Ptr_Func_Reset_16(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT> _proc = 
            (delegate* unmanaged[Stdcall]< COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT>)ptr;

        public const string Name = "Reset";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> pThis, nint pPresentationParameters) => _proc(pThis, pPresentationParameters);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
