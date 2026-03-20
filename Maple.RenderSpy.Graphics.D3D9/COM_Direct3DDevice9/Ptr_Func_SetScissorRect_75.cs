using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 设置剪裁矩形
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetScissorRect_75(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT>, COM_HRESULT>)ptr;

        public const string Name = "SetScissorRect";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT> pRect) => _proc(pThis, pRect);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
