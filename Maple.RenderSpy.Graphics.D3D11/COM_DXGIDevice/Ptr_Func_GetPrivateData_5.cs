using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_DXGIDevice
{
    /// <summary>
    /// 封装 IDXGIDevice::GetPrivateData 函数指针 (VTable 索引 5)
    /// 获取与接口关联的私有数据
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetPrivateData_5(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIDeviceImp>, global::System.Guid*, uint*, void*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIDeviceImp>, global::System.Guid*, uint*, void*, int>)ptr;

        public const string Name = "GetPrivateData";

        public int Invoke(COM_PTR_IUNKNOWN<IDXGIDeviceImp> pThis, global::System.Guid* Name, uint* pDataSize, void* pData) => _proc(pThis, Name, pDataSize, pData);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
