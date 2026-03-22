using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D10.COM_DXGIFactory
{
    /// <summary>
    /// 封装 IDXGIFactory::CreateSoftwareAdapter 函数指针 (VTable 索引 11)
    /// 创建软件适配器
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, void**, int> CreateSoftwareAdapter_11;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateSoftwareAdapter_11(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, void*, void**, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, void*, void**, int>)ptr;

        public const string Name = "CreateSoftwareAdapter";

        /// <summary>
        /// 创建软件适配器
        /// </summary>
        /// <param name="pThis">IDXGIFactory 接口指针</param>
        /// <param name="Module">软件光栅化器的模块句柄</param>
        /// <param name="ppAdapter">接收 IDXGIAdapter 接口指针的指针</param>
        /// <returns>HRESULT</returns>
        public int Invoke(COM_PTR_IUNKNOWN<IDXGIFactoryImp> pThis, void* Module, void** ppAdapter) => _proc(pThis, Module, ppAdapter);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
