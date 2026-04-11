using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11Texture2D
{
    /// <summary>
    /// Wraps the ID3D11Texture2DImp::GetDevice function pointer (VTable slot 3).
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void**, void> GetDevice_3;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetDevice_3(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11Texture2DImp>, void**, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11Texture2DImp>, void**, void>)ptr;

        public const string Name = "GetDevice";

        /// <summary>
        /// Invokes ID3D11Texture2DImp::GetDevice.
        /// </summary>
        /// <param name="pThis">ID3D11Texture2DImp interface pointer.</param>
        /// <param name="arg1">Argument 1.</param>
        public void Invoke(COM_PTR_IUNKNOWN<ID3D11Texture2DImp> pThis, void** arg1) => _proc(pThis, arg1);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
