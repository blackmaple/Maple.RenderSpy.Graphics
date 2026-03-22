using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D10.COM_D3D10Device;
using Maple.RenderSpy.Graphics.D3D10.COM_DXGISwapChain;
using Maple.UnmanagedExtensions;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Dxgi;

namespace Maple.RenderSpy.Graphics.D3D10.COM_DXGIFactory
{
    /// <summary>
    /// 封装 IDXGIFactory::CreateSwapChain 函数指针 (VTable 索引 10)
    /// 创建交换链
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, global::Windows.Win32.Graphics.Dxgi.DXGI_SWAP_CHAIN_DESC*, void**, int> CreateSwapChain_10;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateSwapChain_10(nint ptr) : Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, COM_PTR_IUNKNOWN<ID3D10DeviceImp>, UnsafeIn<DXGI_SWAP_CHAIN_DESC>, UnsafeOut<COM_PTR_IUNKNOWN<IDXGISwapChainImp>>, HRESULT>
            _proc
            = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, COM_PTR_IUNKNOWN<ID3D10DeviceImp>, UnsafeIn<DXGI_SWAP_CHAIN_DESC>, UnsafeOut<COM_PTR_IUNKNOWN<IDXGISwapChainImp>>, HRESULT>)ptr;

        public const string Name = "CreateSwapChain";

        /// <summary>
        /// 创建交换链
        /// </summary>
        /// <param name="pThis">IDXGIFactory 接口指针</param>
        /// <param name="pDevice">设备指针</param>
        /// <param name="pDesc">交换链描述</param>
        /// <param name="ppSwapChain">接收 IDXGISwapChain 接口指针的指针</param>
        /// <returns>HRESULT</returns>
        public HRESULT Invoke(
            COM_PTR_IUNKNOWN<IDXGIFactoryImp> pThis,
             COM_PTR_IUNKNOWN<ID3D10DeviceImp> pDevice,
            in DXGI_SWAP_CHAIN_DESC pDesc,
            out COM_PTR_IUNKNOWN<IDXGISwapChainImp> ppSwapChain) => _proc(
                pThis, pDevice, 
                UnsafeIn<DXGI_SWAP_CHAIN_DESC>.FromIn(in pDesc), 
                UnsafeOut<COM_PTR_IUNKNOWN<IDXGISwapChainImp>>.FromOut(out ppSwapChain));

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
