using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11DeviceContext
{
    /// <summary>
    /// 封装 ID3D11DeviceContext::OMSetRenderTargets 函数指针 (VTable 索引 33)
    /// 设置输出合并阶段的渲染目标和深度模板视图。
    /// public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::System.IntPtr*, void*, void> OMSetRenderTargets_33;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_OMSetRenderTargets_33(nint ptr) : Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, uint, UnsafePtr, UnsafePtr, void>
            _proc
            = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>, uint, UnsafePtr, UnsafePtr, void>)ptr;

        public const string Name = "OMSetRenderTargets";

        public void Invoke(COM_PTR_IUNKNOWN<ID3D11DeviceContextImp> pThis, UnsafePtr pDepthStencilView, params ReadOnlySpan<UnsafePtr> pRenderTargetViews)
        {
            ref var ref_array = ref MemoryMarshal.GetReference(pRenderTargetViews);
            var ptr_array = Unsafe.AsPointer(ref ref_array);
            _proc(pThis, (uint)pRenderTargetViews.Length, new nint(ptr_array), pDepthStencilView);
        }

        /// <summary>
        /// 设置输出合并阶段的渲染目标和深度模板视图。
        /// </summary>
        /// <param name="pThis">ID3D11DeviceContext 接口指针</param>
        /// <param name="numViews">渲染目标视图数量</param>
        /// <param name="ppRenderTargetViews">渲染目标视图指针数组</param>
        /// <param name="pDepthStencilView">深度模板视图指针</param>
        public void Invoke(COM_PTR_IUNKNOWN<ID3D11DeviceContextImp> pThis,uint numViews =default, UnsafePtr ppRenderTargetViews = default, UnsafePtr pDepthStencilView = default)
        {
            _proc(pThis, numViews, ppRenderTargetViews, pDepthStencilView);
        }

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
