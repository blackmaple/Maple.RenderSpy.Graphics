using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Dxgi;

namespace Maple.RenderSpy.Graphics.D3D10.COM_DXGIDevice
{
    /// <summary>
    /// 封装 IDXGIDevice::QueryResourceResidency 函数指针 (VTable 索引 9)
    /// 查询资源的驻留状态
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::System.IntPtr*, global::Windows.Win32.Graphics.Dxgi.DXGI_RESIDENCY*, uint, int> QueryResourceResidency_9;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_QueryResourceResidency_9(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIDeviceImp>, global::System.IntPtr*, DXGI_RESIDENCY*, uint, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIDeviceImp>, global::System.IntPtr*, DXGI_RESIDENCY*, uint, int>)ptr;

        public const string Name = "QueryResourceResidency";

        /// <summary>
        /// 查询资源的驻留状态
        /// </summary>
        /// <param name="pThis">IDXGIDevice 接口指针</param>
        /// <param name="ppResources">要查询的资源接口指针数组</param>
        /// <param name="pResidencyStatus">接收驻留状态的数组</param>
        /// <param name="NumResources">资源数量</param>
        /// <returns>HRESULT</returns>
        public int Invoke(COM_PTR_IUNKNOWN<IDXGIDeviceImp> pThis, global::System.IntPtr* ppResources, DXGI_RESIDENCY* pResidencyStatus, uint NumResources) => _proc(pThis, ppResources, pResidencyStatus, NumResources);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
