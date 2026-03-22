using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_DXGIDevice
{
    /// <summary>
    /// 封装 IDXGIDevice::GetParent 函数指针 (VTable 索引 6)
    /// 获取对象的父对象
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetParent_6(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIDeviceImp>, void**, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIDeviceImp>, void**, int>)ptr;

        public const string Name = "GetParent";

        public int Invoke(COM_PTR_IUNKNOWN<IDXGIDeviceImp> pThis, void** ppParent) => _proc(pThis, ppParent);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
