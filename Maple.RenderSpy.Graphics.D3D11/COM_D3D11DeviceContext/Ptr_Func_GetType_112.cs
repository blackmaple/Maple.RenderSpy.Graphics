using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11DeviceContext
{
    /// <summary>
    /// Wraps the ID3D11DeviceContext::GetType function pointer (VTable slot 112).
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D11.D3D11_DEVICE_CONTEXT_TYPE> GetType_112;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetType_112(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, global::Windows.Win32.Graphics.Direct3D11.D3D11_DEVICE_CONTEXT_TYPE> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, global::Windows.Win32.Graphics.Direct3D11.D3D11_DEVICE_CONTEXT_TYPE>)ptr;

        public const string Name = "GetType";

        /// <summary>
        /// Invokes ID3D11DeviceContext::GetType.
        /// </summary>
        /// <param name="pThis">ID3D11DeviceContext interface pointer.</param>
        /// <returns>Returns the underlying call result.</returns>
        public global::Windows.Win32.Graphics.Direct3D11.D3D11_DEVICE_CONTEXT_TYPE Invoke(COM_PTR_IUNKNOWN<ID3D11DeviceContextImp> pThis) => _proc(pThis);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}