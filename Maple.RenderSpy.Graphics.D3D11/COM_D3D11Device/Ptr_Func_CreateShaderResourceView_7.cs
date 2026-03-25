using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D11.COM_D3D11Device;
using Maple.UnmanagedExtensions;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Direct3D11;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11Device
{
    /// <summary>
    /// 封装 ID3D11Device::CreateShaderResourceView 函数指针 (VTable 索引 7)
    /// 创建着色器资源视图
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, global::Windows.Win32.Graphics.Direct3D11.D3D11_SHADER_RESOURCE_VIEW_DESC*, global::Windows.Win32.Graphics.Direct3D11.ID3D11ShaderResourceView_unmanaged**, int> CreateShaderResourceView_7;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateShaderResourceView_7(nint ptr) : Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceImp>, void*, UnsafeIn<D3D11_SHADER_RESOURCE_VIEW_DESC>, UnsafeOut<UnsafePtr>, HRESULT>
            _proc
            = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceImp>, void*, UnsafeIn<D3D11_SHADER_RESOURCE_VIEW_DESC>, UnsafeOut<UnsafePtr>, HRESULT>)ptr;

        public const string Name = "CreateShaderResourceView";

        /// <summary>
        /// 创建着色器资源视图
        /// </summary>
        /// <param name="pThis">ID3D11Device 接口指针</param>
        /// <param name="pResource">资源指针</param>
        /// <param name="pDesc">视图描述</param>
        /// <param name="ppSRView">接收 ID3D11ShaderResourceView 接口指针的指针</param>
        /// <returns>HRESULT</returns>
        public HRESULT Invoke(
            COM_PTR_IUNKNOWN<ID3D11DeviceImp> pThis,
            void* pResource,
            in D3D11_SHADER_RESOURCE_VIEW_DESC pDesc,
            UnsafeOut<UnsafePtr> ppSRView) => _proc(
                pThis,
                pResource,
                UnsafeIn<D3D11_SHADER_RESOURCE_VIEW_DESC>.FromIn(in pDesc),
                ppSRView);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
