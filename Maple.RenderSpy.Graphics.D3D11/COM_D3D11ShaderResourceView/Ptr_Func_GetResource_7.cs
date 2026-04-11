using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11ShaderResourceView
{
    /// <summary>
    /// Wraps the ID3D11ShaderResourceViewImp::GetResource function pointer (VTable slot 7).
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void**, void> GetResource_7;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetResource_7(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11ShaderResourceViewImp>, void**, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11ShaderResourceViewImp>, void**, void>)ptr;

        public const string Name = "GetResource";

        /// <summary>
        /// Invokes ID3D11ShaderResourceViewImp::GetResource.
        /// </summary>
        /// <param name="pThis">ID3D11ShaderResourceViewImp interface pointer.</param>
        /// <param name="arg1">Argument 1.</param>
        public void Invoke(COM_PTR_IUNKNOWN<ID3D11ShaderResourceViewImp> pThis, void** arg1) => _proc(pThis, arg1);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
