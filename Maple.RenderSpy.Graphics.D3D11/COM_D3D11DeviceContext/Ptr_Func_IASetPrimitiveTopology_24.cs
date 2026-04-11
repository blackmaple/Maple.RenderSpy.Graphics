using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11DeviceContext
{
    /// <summary>
    /// Wraps the ID3D11DeviceContext::IASetPrimitiveTopology function pointer (VTable slot 24).
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D.D3D_PRIMITIVE_TOPOLOGY, void> IASetPrimitiveTopology_24;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_IASetPrimitiveTopology_24(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, global::Windows.Win32.Graphics.Direct3D.D3D_PRIMITIVE_TOPOLOGY, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, global::Windows.Win32.Graphics.Direct3D.D3D_PRIMITIVE_TOPOLOGY, void>)ptr;

        public const string Name = "IASetPrimitiveTopology";

        /// <summary>
        /// Invokes ID3D11DeviceContext::IASetPrimitiveTopology.
        /// </summary>
        /// <param name="pThis">ID3D11DeviceContext interface pointer.</param>
        /// <param name="arg1">Argument 1.</param>

        public void Invoke(COM_PTR_IUNKNOWN<ID3D11DeviceContextImp> pThis, global::Windows.Win32.Graphics.Direct3D.D3D_PRIMITIVE_TOPOLOGY arg1) => _proc(pThis, arg1);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}