using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.DXGI.COM_DXGIFactory
{
    /// <summary>
    /// 封装 IDXGIFactory::GetParent 函数指针 (VTable 索引 6)
    /// 获取对象的父对象
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetParent_6(nint ptr): Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, void**, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, void**, int>)ptr;

        public const string Name = "GetParent";

        public int Invoke(COM_PTR_IUNKNOWN<IDXGIFactoryImp> pThis, void** ppParent) => _proc(pThis, ppParent);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
