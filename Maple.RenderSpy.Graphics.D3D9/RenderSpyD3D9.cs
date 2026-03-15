using System.Runtime.InteropServices.Marshalling;
using Windows.Win32;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Graphics.Direct3D;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9;
using Maple.RenderSpy.Graphics.D3D9.TempWindow;
using Maple.UnmanagedExtensions;


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

    var ptr_com = new COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3D9>(ptr);
    count = ptr_com.IUnknown_VTable.AddRef_1.Invoke(ptr_com);
    count = release(ptr);
    count = ptr_com.Interface_VTable.GetAdapterCount_4.Invoke(ptr_com);

    // 若想在 VS/VSCode 中“鼠标点击或快捷键”直接跳转到 D3D9TempWindow 的定义，
    // 只需确保项目已正确加载，无需额外插件。
    // 快捷键：F12 或 Ctrl+左键单击 即可跳转。
    var factory = new D3D9TempWindowFactory();
    using (var frm = factory.Create())
    {
        Console.WriteLine(frm.ToString());
        var ret = ptr_com.Interface_VTable.CreateDevice_16.Invoke(ptr_com,
                    PInvoke.D3DADAPTER_DEFAULT,
                D3DDEVTYPE.D3DDEVTYPE_NULLREF,
                frm,
                PInvoke.D3DCREATE_SOFTWARE_VERTEXPROCESSING|PInvoke.D3DCREATE_DISABLE_DRIVER_MANAGEMENT,
                new D3DPRESENT_PARAMETERS() 
                {
                    BackBufferWidth = 0,
                    BackBufferHeight = 0,
                    BackBufferFormat = D3DFORMAT.D3DFMT_UNKNOWN,
                    BackBufferCount = 0,
                    MultiSampleType = D3DMULTISAMPLE_TYPE.D3DMULTISAMPLE_NONE,
                    SwapEffect = D3DSWAPEFFECT.D3DSWAPEFFECT_DISCARD,
                    hDeviceWindow = frm,
                    Windowed = true,
                    EnableAutoDepthStencil = false,
                    AutoDepthStencilFormat = D3DFORMAT.D3DFMT_UNKNOWN,
                    FullScreen_RefreshRateInHz = 0,
                    
                },
                out var ppReturnedDeviceInterface
                );
        Console.WriteLine(ret.ToString());

         
    }



    ComInterfaceMarshaller<IDirect3D9>.Free(ptr);
}

Console.WriteLine("123");
Console.ReadLine();
