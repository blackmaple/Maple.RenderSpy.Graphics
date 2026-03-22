using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D10.COM_DXGIDevice
{
    /// <summary>
    /// 封装 IDXGIDevice::SetGPUThreadPriority 函数指针 (VTable 索引 10)
    /// 设置 GPU 线程优先级
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, int, int> SetGPUThreadPriority_10;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetGPUThreadPriority_10(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIDeviceImp>, int, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIDeviceImp>, int, int>)ptr;

        public const string Name = "SetGPUThreadPriority";

        /// <summary>
        /// 设置 GPU 线程优先级
        /// </summary>
        /// <param name="pThis">IDXGIDevice 接口指针</param>
        /// <param name="Priority">线程优先级（范围 -7 到 7）</param>
        /// <returns>HRESULT</returns>
        public int Invoke(COM_PTR_IUNKNOWN<IDXGIDeviceImp> pThis, int Priority) => _proc(pThis, Priority);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
