using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D10.COM_DXGIDevice
{
    /// <summary>
    /// 封装 IDXGIDevice::GetGPUThreadPriority 函数指针 (VTable 索引 11)
    /// 获取 GPU 线程优先级
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, int*, int> GetGPUThreadPriority_11;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetGPUThreadPriority_11(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIDeviceImp>, int*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIDeviceImp>, int*, int>)ptr;

        public const string Name = "GetGPUThreadPriority";

        /// <summary>
        /// 获取 GPU 线程优先级
        /// </summary>
        /// <param name="pThis">IDXGIDevice 接口指针</param>
        /// <param name="pPriority">接收线程优先级的指针</param>
        /// <returns>HRESULT</returns>
        public int Invoke(COM_PTR_IUNKNOWN<IDXGIDeviceImp> pThis, int* pPriority) => _proc(pThis, pPriority);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
