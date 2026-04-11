using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.UnmanagedExtensions;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Dxgi;

namespace Maple.RenderSpy.Graphics.DXGI.COM_DXGISwapChain
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct IDXGISwapChainImp
    {
        public static readonly Guid GUID = new("310D36A0-D2E7-4C0A-AA04-6A9D23B8886A");
        internal readonly Ptr_Func_SetPrivateData_3 SetPrivateData_3;
        internal readonly Ptr_Func_SetPrivateDataInterface_4 SetPrivateDataInterface_4;
        internal readonly Ptr_Func_GetPrivateData_5 GetPrivateData_5;
        internal readonly Ptr_Func_GetParent_6 GetParent_6;
        internal readonly Ptr_Func_GetDevice_7 GetDevice_7;
        internal readonly Ptr_Func_Present_8 Present_8;
        internal readonly Ptr_Func_GetBuffer_9 GetBuffer_9;
        internal readonly Ptr_Func_SetFullscreenState_10 SetFullscreenState_10;
        internal readonly Ptr_Func_GetFullscreenState_11 GetFullscreenState_11;
        internal readonly Ptr_Func_GetDesc_12 GetDesc_12;
        internal readonly Ptr_Func_ResizeBuffers_13 ResizeBuffers_13;
        internal readonly Ptr_Func_ResizeTarget_14 ResizeTarget_14;
        internal readonly Ptr_Func_GetContainingOutput_15 GetContainingOutput_15;
        internal readonly Ptr_Func_GetFrameStatistics_16 GetFrameStatistics_16;
        internal readonly Ptr_Func_GetLastPresentCount_17 GetLastPresentCount_17;
    }

    public static class IDXGISwapChainImpExtension
    {
        extension(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this)
        {
            public COM_HRESULT GetDevice<T>(
            in Guid guid,
            out COM_PTR_IUNKNOWN<T> pDevice)
                where T : unmanaged
            {
                var h = @this.Interface_VTable.GetDevice_7.Invoke(@this, in guid, out var ppObject);
                pDevice = ppObject.Get<T>();
                return h;
            }

            //public COM_HRESULT GetDevice(out COM_PTR_IUNKNOWN<ID3D11DeviceImp> pDevice)
            //    => @this.GetDevice<ID3D11DeviceImp>(ID3D11DeviceImp.GUID, out pDevice);

            //internal COM_HRESULT GetDesc(out DXGI_SWAP_CHAIN_DESC pDesc)
            //    => @this.GetDesc(out pDesc);

            public nint GetOutputWindow()
                => @this.GetDesc<DXGI_SWAP_CHAIN_DESC>(out var pDesc) ? pDesc.OutputWindow : nint.Zero;

            public (uint Height, uint Width) GetOutputWindowSize()
                => @this.GetDesc<DXGI_SWAP_CHAIN_DESC>(out var pDesc) ? (pDesc.BufferDesc.Height, pDesc.BufferDesc.Width) : default;


            public COM_HRESULT GetDesc<T>(UnsafeOut<T> pDesc)
                where T : unmanaged
                => @this.Interface_VTable.GetDesc_12.Invoke(@this, pDesc);

            public COM_HRESULT GetDesc<T>(out T pDesc)
               where T : unmanaged
               => @this.GetDesc(UnsafeOut<T>.FromOut(out pDesc));

            //public COM_HRESULT GetBuffer(in Guid riid, out COM_PTR_IUNKNOWN pSurface)
            //{
            //    return @this.Interface_VTable.GetBuffer_9.Invoke(@this, 0, in riid, out pSurface);
            //}
            public COM_HRESULT GetBuffer<T>(in Guid riid, out COM_PTR_IUNKNOWN<T> pSurface)
                where T : unmanaged
            {
                var h = @this.Interface_VTable.GetBuffer_9.Invoke(@this, 0, in riid, out var ppObject);
                pSurface = ppObject.Get<T>();
                return h;
            }
        }
    }


    /*
         public delegate* unmanaged[MemberFunction]<void*, global::System.Guid*, void**, int> QueryInterface_0;
    public delegate* unmanaged[MemberFunction]<void*, uint> AddRef_1;
    public delegate* unmanaged[MemberFunction]<void*, uint> Release_2;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::System.Guid*, uint, void*, int> SetPrivateData_3;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::System.Guid*, void*, int> SetPrivateDataInterface_4;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::System.Guid*, uint*, void*, int> GetPrivateData_5;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::System.Guid*, void**, int> GetParent_6;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::System.Guid*, void**, int> GetDevice_7;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Dxgi.DXGI_PRESENT, int> Present_8;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::System.Guid*, void**, int> GetBuffer_9;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, int, void*, int> SetFullscreenState_10;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Foundation.BOOL*, global::Windows.Win32.Graphics.Dxgi.IDXGIOutput_unmanaged**, int> GetFullscreenState_11;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Dxgi.DXGI_SWAP_CHAIN_DESC*, int> GetDesc_12;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, uint, global::Windows.Win32.Graphics.Dxgi.Common.DXGI_FORMAT, uint, int> ResizeBuffers_13;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Dxgi.Common.DXGI_MODE_DESC*, int> ResizeTarget_14;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void**, int> GetContainingOutput_15;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Dxgi.DXGI_FRAME_STATISTICS*, int> GetFrameStatistics_16;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint*, int> GetLastPresentCount_17;
     */
}
