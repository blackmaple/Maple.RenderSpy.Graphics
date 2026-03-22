using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Maple.RenderSpy.Graphics.D3D11.COM_DXGISwapChain
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct IDXGISwapChainImp
    {
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
