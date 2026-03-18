using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9EvictManagedResourcesHookItem : HookItem<D3D9EvictManagedResourcesHookItem, Ptr_Func_EvictManagedResources_5, Ptr_Func_EvictManagedResources_5>, IHookItemFactory<D3D9EvictManagedResourcesHookItem>
    {
        public const string MethodName = Ptr_Func_EvictManagedResources_5.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3D9EvictManagedResourcesHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9EvictManagedResourcesHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9EvictManagedResourcesHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9EvictManagedResourcesHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, COM_HRESULT>
                _proc = &Hook_EvictManagedResources;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_EvictManagedResources(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this)
        {
            if (D3D9EvictManagedResourcesHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this);
            }
            return 0;
        }
    }
}
