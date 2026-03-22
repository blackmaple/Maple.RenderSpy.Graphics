using Maple.RenderSpy.Graphics.COM;
using Maple.UnmanagedExtensions;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Gdi;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 设置调色板条目
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetPaletteEntries_71(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, UnsafeRef<global::Windows.Win32.Graphics.Gdi.PALETTEENTRY>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, UnsafeRef<global::Windows.Win32.Graphics.Gdi.PALETTEENTRY>, COM_HRESULT>)ptr;

        public const string Name = "SetPaletteEntries";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint PaletteNumber, UnsafeRef<global::Windows.Win32.Graphics.Gdi.PALETTEENTRY> pEntries) => _proc(pThis, PaletteNumber, pEntries);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
