using Maple.RenderSpy.Graphics.D3D;
using Maple.UnmanagedExtensions;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Dxgi.Common;

namespace Maple.RenderSpy.Graphics.D3D11.COM_DXGISwapChain
{
    /// <summary>
    /// 封装 IDXGISwapChain::GetBuffer 函数指针 (VTable 索引 9)
    /// 获取交换链的后备缓冲区
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::System.Guid*, void**, int> GetBuffer_9;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetBuffer_9(nint ptr) : Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, uint, UnsafeIn<System.Guid>, UnsafeOut<nint>, COM_HRESULT> _proc =
            (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, uint, UnsafeIn<System.Guid>, UnsafeOut<nint>, COM_HRESULT>)ptr;

        public const string Name = "GetBuffer";

        /// <summary>
        /// 获取交换链的后备缓冲区
        /// </summary>
        /// <param name="pThis">IDXGISwapChain 接口指针</param>
        /// <param name="Buffer">缓冲区索引</param>
        /// <param name="riid">请求的接口 IID</param>
        /// <param name="ppSurface">接收表面接口指针的指针</param>
        /// <returns>HRESULT</returns>
        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDXGISwapChainImp> pThis, uint Buffer, UnsafeIn<System.Guid> riid, UnsafeOut<nint> ppSurface) => _proc(pThis, Buffer, riid, ppSurface);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
