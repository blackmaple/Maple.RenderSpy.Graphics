using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11DeviceContext
{
    /// <summary>
    /// Wraps the ID3D11DeviceContext::OMGetBlendState function pointer (VTable slot 91).
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D11.ID3D11BlendState_unmanaged**, float*, uint*, void> OMGetBlendState_91;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_OMGetBlendState_91(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, global::Windows.Win32.Graphics.Direct3D11.ID3D11BlendState_unmanaged**, float*, uint*, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, global::Windows.Win32.Graphics.Direct3D11.ID3D11BlendState_unmanaged**, float*, uint*, void>)ptr;

        public const string Name = "OMGetBlendState";

        /// <summary>
        /// Invokes ID3D11DeviceContext::OMGetBlendState.
        /// </summary>
        /// <param name="pThis">ID3D11DeviceContext interface pointer.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>

        public void Invoke(COM_PTR_IUNKNOWN<ID3D11DeviceContextImp> pThis, global::Windows.Win32.Graphics.Direct3D11.ID3D11BlendState_unmanaged** arg1, float* arg2, uint* arg3) => _proc(pThis, arg1, arg2, arg3);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}