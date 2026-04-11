using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11DeviceContext
{
    /// <summary>
    /// Wraps the ID3D11DeviceContext::OMGetRenderTargets function pointer (VTable slot 89).
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::System.IntPtr*, global::Windows.Win32.Graphics.Direct3D11.ID3D11DepthStencilView_unmanaged**, void> OMGetRenderTargets_89;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_OMGetRenderTargets_89(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, uint, global::System.IntPtr*, global::Windows.Win32.Graphics.Direct3D11.ID3D11DepthStencilView_unmanaged**, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, uint, global::System.IntPtr*, global::Windows.Win32.Graphics.Direct3D11.ID3D11DepthStencilView_unmanaged**, void>)ptr;

        public const string Name = "OMGetRenderTargets";

        /// <summary>
        /// Invokes ID3D11DeviceContext::OMGetRenderTargets.
        /// </summary>
        /// <param name="pThis">ID3D11DeviceContext interface pointer.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>

        public void Invoke(COM_PTR_IUNKNOWN<ID3D11DeviceContextImp> pThis, uint arg1, global::System.IntPtr* arg2, global::Windows.Win32.Graphics.Direct3D11.ID3D11DepthStencilView_unmanaged** arg3) => _proc(pThis, arg1, arg2, arg3);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}