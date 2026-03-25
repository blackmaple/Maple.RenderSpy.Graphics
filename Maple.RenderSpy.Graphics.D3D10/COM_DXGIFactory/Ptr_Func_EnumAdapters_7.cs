using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D10.COM_DXGIFactory
{
    /// <summary>
    /// 封装 IDXGIFactory::EnumAdapters 函数指针 (VTable 索引 7)
    /// 枚举显示适配器
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, void**, int> EnumAdapters_7;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_EnumAdapters_7(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, uint, void**, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, uint, void**, int>)ptr;

        public const string Name = "EnumAdapters";

        /// <summary>
        /// 枚举显示适配器
        /// </summary>
        /// <param name="pThis">IDXGIFactory 接口指针</param>
        /// <param name="Adapter">适配器索引</param>
        /// <param name="ppAdapter">接收 IDXGIAdapter 接口指针的指针</param>
        /// <returns>HRESULT</returns>
        public int Invoke(COM_PTR_IUNKNOWN<IDXGIFactoryImp> pThis, uint Adapter, void** ppAdapter) => _proc(pThis, Adapter, ppAdapter);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
