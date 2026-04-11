using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11Texture2D
{
    /// <summary>
    /// Wraps the ID3D11Texture2DImp::GetEvictionPriority function pointer (VTable slot 9).
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint> GetEvictionPriority_9;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetEvictionPriority_9(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11Texture2DImp>, uint> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11Texture2DImp>, uint>)ptr;

        public const string Name = "GetEvictionPriority";

        /// <summary>
        /// Invokes ID3D11Texture2DImp::GetEvictionPriority.
        /// </summary>
        /// <param name="pThis">ID3D11Texture2DImp interface pointer.</param>
        /// <returns>Returns the underlying call result.</returns>
        public uint Invoke(COM_PTR_IUNKNOWN<ID3D11Texture2DImp> pThis) => _proc(pThis);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
