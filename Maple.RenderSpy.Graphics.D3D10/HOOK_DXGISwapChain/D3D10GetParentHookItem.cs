using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D10.COM_DXGISwapChain;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain
{
    internal class D3D10GetParentHookItem : HookItem<D3D10GetParentHookItem, Ptr_Func_GetParent_6, Ptr_Func_GetParent_6>, IGraphicsHookItem<D3D10GetParentHookItem>
    {
        public const string MethodName = Ptr_Func_GetParent_6.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeIn<global::System.Guid>, UnsafeOut<UnsafePtr>, D3D10GetParentHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D10GetParentHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D10GetParentHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D10GetParentHookItem>(
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
            if (D3D10GetParentHookItem.TryGet(out var hookItem))
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
