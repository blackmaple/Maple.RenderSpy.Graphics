using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11DeviceContext
{
    /// <summary>
    /// Wraps the ID3D11DeviceContext::RSGetViewports function pointer (VTable slot 95).
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint*, global::Windows.Win32.Graphics.Direct3D11.D3D11_VIEWPORT*, void> RSGetViewports_95;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_RSGetViewports_95(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, uint*, global::Windows.Win32.Graphics.Direct3D11.D3D11_VIEWPORT*, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, uint*, global::Windows.Win32.Graphics.Direct3D11.D3D11_VIEWPORT*, void>)ptr;

        public const string Name = "RSGetViewports";

        /// <summary>
        /// Invokes ID3D11DeviceContext::RSGetViewports.
        /// </summary>
        /// <param name="pThis">ID3D11DeviceContext interface pointer.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>

        public void Invoke(COM_PTR_IUNKNOWN<ID3D11DeviceContextImp> pThis, uint* arg1, global::Windows.Win32.Graphics.Direct3D11.D3D11_VIEWPORT* arg2) => _proc(pThis, arg1, arg2);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}