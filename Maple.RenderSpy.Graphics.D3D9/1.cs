using System.Runtime.InteropServices.Marshalling;
using Windows.Win32;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Graphics.Direct3D;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9;
using Maple.RenderSpy.Graphics.D3D9.TempWindow;

  Console.WriteLine("123");
  
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
    
    var ptr_com =  new COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3D9> (ptr);
    count = ptr_com.IUnknown_VTable.AddRef_1.Invoke(ptr_com);
    count = release(ptr);
    count = ptr_com.Interface_VTable.GetAdapterCount_4.Invoke(ptr_com);

    // 若想在 VS/VSCode 中“鼠标点击或快捷键”直接跳转到 D3D9TempWindow 的定义，
    // 只需确保项目已正确加载，无需额外插件。
    // 快捷键：F12 或 Ctrl+左键单击 即可跳转。
    using (var frm = new D3D9TempWindow())
    { 
        Console.WriteLine("123");
    }

    ComInterfaceMarshaller<IDirect3D9>.Free(ptr);
}

  Console.WriteLine("123");
Console.ReadLine();
