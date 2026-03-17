using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetDepthStencilSurfaceHookItem : HookItem<Ptr_Func_GetDepthStencilSurface_40, Ptr_Func_GetDepthStencilSurface_40>, IHookItemFactory<D3D9GetDepthStencilSurfaceHookItem>
    {
        public const string MethodName = Ptr_Func_GetDepthStencilSurface_40.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, D3D9GetDepthStencilSurfaceHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetDepthStencilSurfaceHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetDepthStencilSurfaceHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetDepthStencilSurfaceHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT>
                _proc = &Hook_GetDepthStencilSurface;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetDepthStencilSurface(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, nint ppZStencilSurface)
        {
            if (D3D9GetDepthStencilSurfaceHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, ppZStencilSurface, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, ppZStencilSurface);
            }
            return 0;
        }
    }
}
