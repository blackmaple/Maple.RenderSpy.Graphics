using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D10.COM_DXGIDevice
{
    /// <summary>
    /// 封装 IDXGIDevice::GetParent 函数指针 (VTable 索引 6)
    /// 获取对象的父对象
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::System.Guid*, void**, int> GetParent_6;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetParent_6(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIDeviceImp>, global::System.Guid*, void**, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIDeviceImp>, global::System.Guid*, void**, int>)ptr;

        public const string Name = "GetParent";

        /// <summary>
        /// 获取对象的父对象
        /// </summary>
        /// <param name="pThis">IDXGIDevice 接口指针</param>
        /// <param name="riid">父接口的 IID</param>
        /// <param name="ppParent">接收父对象接口指针的指针</param>
        /// <returns>HRESULT</returns>
        public int Invoke(COM_PTR_IUNKNOWN<IDXGIDeviceImp> pThis, global::System.Guid* riid, void** ppParent) => _proc(pThis, riid, ppParent);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
