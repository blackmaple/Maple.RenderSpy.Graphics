using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 拉伸矩形
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_StretchRect_34(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        // 原函数指针: private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, nint, RECT*, nint, RECT*, D3DTEXTUREFILTERTYPE, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, nint, RECT*, nint, RECT*, D3DTEXTUREFILTERTYPE, int>)ptr;
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, nint, nint, nint, D3DTEXTUREFILTERTYPE, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, nint, nint, nint, D3DTEXTUREFILTERTYPE, COM_HRESULT>)ptr;

        public const string Name = "StretchRect";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> pThis, nint pSourceSurface, nint pSourceRect, nint pDestSurface, nint pDestRect, D3DTEXTUREFILTERTYPE Filter) => _proc(pThis, pSourceSurface, pSourceRect, pDestSurface, pDestRect, Filter);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
