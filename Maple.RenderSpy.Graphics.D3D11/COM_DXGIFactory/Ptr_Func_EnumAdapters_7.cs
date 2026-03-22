using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_DXGIFactory
{
    /// <summary>
    /// 封装 IDXGIFactory::EnumAdapters 函数指针 (VTable 索引 7)
    /// 枚举适配器
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_EnumAdapters_7(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, uint, void**, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, uint, void**, int>)ptr;

        public const string Name = "EnumAdapters";

        public int Invoke(COM_PTR_IUNKNOWN<IDXGIFactoryImp> pThis, uint Adapter, void** ppAdapter) => _proc(pThis, Adapter, ppAdapter);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
