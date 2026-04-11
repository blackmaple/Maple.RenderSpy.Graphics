using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11DeviceContext
{
    /// <summary>
    /// Wraps the ID3D11DeviceContext::IAGetVertexBuffers function pointer (VTable slot 79).
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, uint*, uint*, void> IAGetVertexBuffers_79;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_IAGetVertexBuffers_79(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, uint, uint, global::System.IntPtr*, uint*, uint*, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, uint, uint, global::System.IntPtr*, uint*, uint*, void>)ptr;

        public const string Name = "IAGetVertexBuffers";

        /// <summary>
        /// Invokes ID3D11DeviceContext::IAGetVertexBuffers.
        /// </summary>
        /// <param name="pThis">ID3D11DeviceContext interface pointer.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>

        public void Invoke(COM_PTR_IUNKNOWN<ID3D11DeviceContextImp> pThis, uint arg1, uint arg2, global::System.IntPtr* arg3, uint* arg4, uint* arg5) => _proc(pThis, arg1, arg2, arg3, arg4, arg5);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}