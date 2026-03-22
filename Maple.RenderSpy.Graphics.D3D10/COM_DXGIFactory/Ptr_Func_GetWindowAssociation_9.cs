using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D10.COM_DXGIFactory
{
    /// <summary>
    /// 封装 IDXGIFactory::GetWindowAssociation 函数指针 (VTable 索引 9)
    /// 获取窗口关联
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Foundation.HWND*, int> GetWindowAssociation_9;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetWindowAssociation_9(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, HWND*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, HWND*, int>)ptr;

        public const string Name = "GetWindowAssociation";

        /// <summary>
        /// 获取窗口关联
        /// </summary>
        /// <param name="pThis">IDXGIFactory 接口指针</param>
        /// <param name="pWindowHandle">接收窗口句柄的指针</param>
        /// <returns>HRESULT</returns>
        public int Invoke(COM_PTR_IUNKNOWN<IDXGIFactoryImp> pThis, HWND* pWindowHandle) => _proc(pThis, pWindowHandle);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
