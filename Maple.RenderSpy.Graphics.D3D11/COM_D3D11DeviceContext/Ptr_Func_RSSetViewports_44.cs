using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11DeviceContext
{
    /// <summary>
    /// Wraps the ID3D11DeviceContext::RSSetViewports function pointer (VTable slot 44).
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Direct3D11.D3D11_VIEWPORT*, void> RSSetViewports_44;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_RSSetViewports_44(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, uint, global::Windows.Win32.Graphics.Direct3D11.D3D11_VIEWPORT*, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, uint, global::Windows.Win32.Graphics.Direct3D11.D3D11_VIEWPORT*, void>)ptr;

        public const string Name = "RSSetViewports";

        /// <summary>
        /// Invokes ID3D11DeviceContext::RSSetViewports.
        /// </summary>
        /// <param name="pThis">ID3D11DeviceContext interface pointer.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        public void Invoke(COM_PTR_IUNKNOWN<ID3D11DeviceContextImp> pThis, params ReadOnlySpan<global::Windows.Win32.Graphics.Direct3D11.D3D11_VIEWPORT> pViews)
        {
            ref var ref_array = ref MemoryMarshal.GetReference(pViews);
            var ptr_array = Unsafe.AsPointer(ref ref_array);
            _proc(pThis, (uint)pViews.Length, (global::Windows.Win32.Graphics.Direct3D11.D3D11_VIEWPORT*)ptr_array);
        }

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}