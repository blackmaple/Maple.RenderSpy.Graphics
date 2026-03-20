using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 设置伽马斜坡
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetGammaRamp_21(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DGAMMARAMP>, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DGAMMARAMP>, void>)ptr;

        public const string Name = "SetGammaRamp";

        public void Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint iSwapChain, uint Flags, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DGAMMARAMP> pRamp) => _proc(pThis, iSwapChain, Flags, pRamp);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
