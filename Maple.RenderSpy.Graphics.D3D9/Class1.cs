

using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Windows.Win32;
using Windows.Win32.Graphics.Direct3D;
using Windows.Win32.Graphics.Direct3D9;

unsafe
{


    var d3d = PInvoke.Direct3DCreate9(PInvoke.D3D_SDK_VERSION);
    var count = d3d.GetAdapterCount();
    var ptr = ComInterfaceMarshaller<IDirect3D9>.ConvertToUnmanaged(d3d);
    void*** ppVTable = (void***)ptr;
    void** pVTable = *ppVTable;
    var release =
        (delegate* unmanaged[Stdcall]<void*, uint>)(pVTable)[2];
    var addref =
    (delegate* unmanaged[Stdcall]<void*, uint>)(pVTable)[1];
    count = addref(ptr);
    count = release(ptr);

    var ptr_com = new UnsafePtr<COM_IUNKNOWN<COM_INTERFACE_Direct3D9>>(ptr);
    count = ptr_com.RefRaw.VTable.RefRaw.IUNKNOWN_VTABLE.AddRef.Invoke(ptr_com.Ptr);
    count = release(ptr);
    count = ptr_com.RefRaw.VTable.RefRaw.INTERFACE_VTABLE.GetAdapterCount_4(ptr_com.Ptr);


    ComInterfaceMarshaller<IDirect3D9>.Free(ptr);
}


/*
     public delegate* unmanaged[MemberFunction]<void*, global::System.Guid*, void**, int> QueryInterface_0;
    public delegate* unmanaged[MemberFunction]<void*, uint> AddRef_1;
    public delegate* unmanaged[MemberFunction]<void*, uint> Release_2;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, int> RegisterSoftwareDevice_3;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint> GetAdapterCount_4;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::Windows.Win32.Graphics.Direct3D9.D3DADAPTER_IDENTIFIER9*, int> GetAdapterIdentifier_5;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, uint> GetAdapterModeCount_6;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDISPLAYMODE*, int> EnumAdapterModes_7;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDISPLAYMODE*, int> GetAdapterDisplayMode_8;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDEVTYPE, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, int, int> CheckDeviceType_9;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDEVTYPE, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, uint, global::Windows.Win32.Graphics.Direct3D9.D3DRESOURCETYPE, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, int> CheckDeviceFormat_10;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDEVTYPE, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, int, global::Windows.Win32.Graphics.Direct3D9.D3DMULTISAMPLE_TYPE, uint*, int> CheckDeviceMultiSampleType_11;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDEVTYPE, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, int> CheckDepthStencilMatch_12;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDEVTYPE, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, int> CheckDeviceFormatConversion_13;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDEVTYPE, global::Windows.Win32.Graphics.Direct3D9.D3DCAPS9*, int> GetDeviceCaps_14;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, void*> GetAdapterMonitor_15;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDEVTYPE, void*, uint, global::Windows.Win32.Graphics.Direct3D9.D3DPRESENT_PARAMETERS*, void**, int> CreateDevice_16;

 
 */
Console.ReadLine();

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct COM_INTERFACE_Direct3D9
{
    public delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, void*, int> RegisterSoftwareDevice_3;
    public delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, uint> GetAdapterCount_4;
    public delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, uint, uint, global::Windows.Win32.Graphics.Direct3D9.D3DADAPTER_IDENTIFIER9*, int> GetAdapterIdentifier_5;
    public delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, uint> GetAdapterModeCount_6;
    public delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDISPLAYMODE*, int> EnumAdapterModes_7;
    public delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDISPLAYMODE*, int> GetAdapterDisplayMode_8;
    public delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDEVTYPE, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, int, int> CheckDeviceType_9;
    public delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDEVTYPE, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, uint, global::Windows.Win32.Graphics.Direct3D9.D3DRESOURCETYPE, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, int> CheckDeviceFormat_10;
    public delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDEVTYPE, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, int, global::Windows.Win32.Graphics.Direct3D9.D3DMULTISAMPLE_TYPE, uint*, int> CheckDeviceMultiSampleType_11;
    public delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDEVTYPE, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, int> CheckDepthStencilMatch_12;
    public delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDEVTYPE, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, global::Windows.Win32.Graphics.Direct3D9.D3DFORMAT, int> CheckDeviceFormatConversion_13;
    public delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDEVTYPE, global::Windows.Win32.Graphics.Direct3D9.D3DCAPS9*, int> GetDeviceCaps_14;
    public delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, uint, void*> GetAdapterMonitor_15;
    public delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, uint, global::Windows.Win32.Graphics.Direct3D9.D3DDEVTYPE, void*, uint, global::Windows.Win32.Graphics.Direct3D9.D3DPRESENT_PARAMETERS*, void**, int> CreateDevice_16;

}