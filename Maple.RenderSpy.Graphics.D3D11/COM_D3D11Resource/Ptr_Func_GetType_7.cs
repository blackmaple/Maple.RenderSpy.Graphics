using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11Resource
{
    /// <summary>
    /// Wraps the ID3D11ResourceImp::GetType function pointer (VTable slot 7).
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D11.D3D11_RESOURCE_DIMENSION*, void> GetType_7;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetType_7(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11ResourceImp>, global::Windows.Win32.Graphics.Direct3D11.D3D11_RESOURCE_DIMENSION*, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11ResourceImp>, global::Windows.Win32.Graphics.Direct3D11.D3D11_RESOURCE_DIMENSION*, void>)ptr;

        public const string Name = "GetType";

        /// <summary>
        /// Invokes ID3D11ResourceImp::GetType.
        /// </summary>
        /// <param name="pThis">ID3D11ResourceImp interface pointer.</param>
        /// <param name="arg1">Argument 1.</param>
        public void Invoke(COM_PTR_IUNKNOWN<ID3D11ResourceImp> pThis, global::Windows.Win32.Graphics.Direct3D11.D3D11_RESOURCE_DIMENSION* arg1) => _proc(pThis, arg1);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
