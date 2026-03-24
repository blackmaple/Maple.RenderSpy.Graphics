using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D11.COM_D3D11Device;
using Maple.UnmanagedExtensions;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Dxgi.Common;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11Device
{
    /// <summary>
    /// 封装 ID3D11Device::CheckFormatSupport 函数指针 (VTable 索引 29)
    /// 检查格式支持
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Dxgi.Common.DXGI_FORMAT, uint*, int> CheckFormatSupport_29;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CheckFormatSupport_29(nint ptr) : Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceImp>, DXGI_FORMAT, uint*, HRESULT>
            _proc
            = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceImp>, DXGI_FORMAT, uint*, HRESULT>)ptr;

        public const string Name = "CheckFormatSupport";

        /// <summary>
        /// 检查格式支持
        /// </summary>
        /// <param name="pThis">ID3D11Device 接口指针</param>
        /// <param name="Format">要检查的格式</param>
        /// <param name="pFormatSupport">返回格式支持标志</param>
        /// <returns>HRESULT</returns>
        public HRESULT Invoke(
            COM_PTR_IUNKNOWN<ID3D11DeviceImp> pThis,
            DXGI_FORMAT Format,
            uint* pFormatSupport) => _proc(pThis, Format, pFormatSupport);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
