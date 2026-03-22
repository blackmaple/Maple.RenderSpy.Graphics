using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D10.COM_DXGIFactory
{
    /// <summary>
    /// 封装 IDXGIFactory::SetPrivateData 函数指针 (VTable 索引 3)
    /// 设置与接口关联的私有数据
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::System.Guid*, uint, void*, int> SetPrivateData_3;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetPrivateData_3(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, global::System.Guid*, uint, void*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGIFactoryImp>, global::System.Guid*, uint, void*, int>)ptr;

        public const string Name = "SetPrivateData";

        /// <summary>
        /// 设置与接口关联的私有数据
        /// </summary>
        /// <param name="pThis">IDXGIFactory 接口指针</param>
        /// <param name="Name">数据标识符的 GUID</param>
        /// <param name="DataSize">数据大小（字节）</param>
        /// <param name="pData">指向数据的指针</param>
        /// <returns>HRESULT</returns>
        public int Invoke(COM_PTR_IUNKNOWN<IDXGIFactoryImp> pThis, global::System.Guid* Name, uint DataSize, void* pData) => _proc(pThis, Name, DataSize, pData);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
