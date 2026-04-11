using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11Texture2D
{
    /// <summary>
    /// Wraps the ID3D11Texture2DImp::SetEvictionPriority function pointer (VTable slot 8).
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, void> SetEvictionPriority_8;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetEvictionPriority_8(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11Texture2DImp>, uint, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11Texture2DImp>, uint, void>)ptr;

        public const string Name = "SetEvictionPriority";

        /// <summary>
        /// Invokes ID3D11Texture2DImp::SetEvictionPriority.
        /// </summary>
        /// <param name="pThis">ID3D11Texture2DImp interface pointer.</param>
        /// <param name="arg1">Argument 1.</param>
        public void Invoke(COM_PTR_IUNKNOWN<ID3D11Texture2DImp> pThis, uint arg1) => _proc(pThis, arg1);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
