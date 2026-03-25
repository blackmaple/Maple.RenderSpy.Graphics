using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Dxgi;

namespace Maple.RenderSpy.Graphics.D3D11.COM_DXGIFactory
{
    /// <summary>
    /// 封装 IDXGIFactory::MakeWindowAssociation 函数指针 (VTable 索引 8)
    /// 建立窗口关联
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_MakeWindowAssociation_8(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, void*, DXGI_MWA_FLAGS, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, void*, DXGI_MWA_FLAGS, int>)ptr;

        public const string Name = "MakeWindowAssociation";

        public int Invoke(COM_PTR_IUNKNOWN<IDXGIFactoryImp> pThis, void* WindowHandle, DXGI_MWA_FLAGS Flags) => _proc(pThis, WindowHandle, Flags);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
