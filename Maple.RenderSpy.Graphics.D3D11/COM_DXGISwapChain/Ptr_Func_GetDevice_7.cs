using Maple.RenderSpy.Graphics.D3D;
using Maple.UnmanagedExtensions;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_DXGISwapChain
{
    /// <summary>
    /// 封装 IDXGISwapChain::GetDevice 函数指针 (VTable 索引 7)
    /// 获取创建此交换链的设备
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::System.Guid*, void**, int> GetDevice_7;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetDevice_7(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeIn<global::System.Guid>, UnsafeOut<nint>, COM_HRESULT>
            _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeIn<global::System.Guid>, UnsafeOut<nint>, COM_HRESULT>)ptr;

        public const string Name = "GetDevice";

        /// <summary>
        /// 获取创建此交换链的设备
        /// </summary>
        /// <param name="pThis">IDXGISwapChain 接口指针</param>
        /// <param name="riid">设备接口的 IID</param>
        /// <param name="ppDevice">接收设备接口指针的指针</param>
        /// <returns>HRESULT</returns>
        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDXGISwapChainImp> pThis, UnsafeIn<global::System.Guid> riid, UnsafeOut<nint> ppDevice) => _proc(pThis, riid, ppDevice);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
