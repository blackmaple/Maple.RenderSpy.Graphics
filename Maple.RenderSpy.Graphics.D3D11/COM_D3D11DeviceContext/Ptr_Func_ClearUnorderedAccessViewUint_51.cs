using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11DeviceContext
{
    /// <summary>
    /// Wraps the ID3D11DeviceContext::ClearUnorderedAccessViewUint function pointer (VTable slot 51).
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, uint*, void> ClearUnorderedAccessViewUint_51;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_ClearUnorderedAccessViewUint_51(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, void*, uint*, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, void*, uint*, void>)ptr;

        public const string Name = "ClearUnorderedAccessViewUint";

        /// <summary>
        /// Invokes ID3D11DeviceContext::ClearUnorderedAccessViewUint.
        /// </summary>
        /// <param name="pThis">ID3D11DeviceContext interface pointer.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>

        public void Invoke(COM_PTR_IUNKNOWN<ID3D11DeviceContextImp> pThis, void* arg1, uint* arg2) => _proc(pThis, arg1, arg2);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}