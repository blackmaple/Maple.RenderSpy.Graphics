using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Maple.RenderSpy.Graphics.DXGI.COM_DXGISwapChain;

namespace Maple.RenderSpy.Graphics.DXGI.HOOK_DXGISwapChain
{
    internal class DXGIGetParentHookItem : HookItem<DXGIGetParentHookItem, Ptr_Func_GetParent_6, Ptr_Func_GetParent_6>, IGraphicsHookItem<DXGIGetParentHookItem>
    {
        public const string MethodName = Ptr_Func_GetParent_6.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeIn<global::System.Guid>, UnsafeOut<UnsafePtr>, DXGIGetParentHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static DXGIGetParentHookItem Create(ISupperHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<DXGIGetParentHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<DXGIGetParentHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeIn<global::System.Guid>, UnsafeOut<UnsafePtr>, COM_HRESULT>
                _proc = &Hook_GetParent;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetParent(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, UnsafeIn<global::System.Guid> riid, UnsafeOut<UnsafePtr> ppParent)
        {
            if (DXGIGetParentHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, riid, ppParent, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, riid, ppParent);
            }
            return 0;
        }
    }
}
