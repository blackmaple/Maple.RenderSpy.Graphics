using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.UnmanagedExtensions;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11Texture2D
{
    /// <summary>
    /// Wraps the ID3D11Texture2DImp::GetDesc function pointer (VTable slot 10).
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D11.D3D11_TEXTURE2D_DESC*, void> GetDesc_10;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetDesc_10(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11Texture2DImp>, UnsafeOut<global::Windows.Win32.Graphics.Direct3D11.D3D11_TEXTURE2D_DESC>, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11Texture2DImp>, UnsafeOut<global::Windows.Win32.Graphics.Direct3D11.D3D11_TEXTURE2D_DESC>, void>)ptr;

        public const string Name = "GetDesc";

        /// <summary>
        /// Invokes ID3D11Texture2DImp::GetDesc.
        /// </summary>
        /// <param name="pThis">ID3D11Texture2DImp interface pointer.</param>
        /// <param name="arg1">Argument 1.</param>
        public void Invoke(COM_PTR_IUNKNOWN<ID3D11Texture2DImp> pThis, UnsafeOut<global::Windows.Win32.Graphics.Direct3D11.D3D11_TEXTURE2D_DESC> arg1) => _proc(pThis, arg1);
        public void Invoke(COM_PTR_IUNKNOWN<ID3D11Texture2DImp> pThis, out global::Windows.Win32.Graphics.Direct3D11.D3D11_TEXTURE2D_DESC arg1) => _proc(pThis, UnsafeOut<global::Windows.Win32.Graphics.Direct3D11.D3D11_TEXTURE2D_DESC>.FromOut(out arg1));

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
