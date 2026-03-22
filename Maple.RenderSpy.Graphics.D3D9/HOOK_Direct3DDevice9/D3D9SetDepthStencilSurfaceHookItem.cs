using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetDepthStencilSurfaceHookItem : HookItem<D3D9SetDepthStencilSurfaceHookItem, Ptr_Func_SetDepthStencilSurface_39, Ptr_Func_SetDepthStencilSurface_39>, IGraphicsHookItem<D3D9SetDepthStencilSurfaceHookItem>
    {
        public const string MethodName = Ptr_Func_SetDepthStencilSurface_39.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, nint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetDepthStencilSurfaceHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetDepthStencilSurfaceHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetDepthStencilSurfaceHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, nint, COM_HRESULT>
                _proc = &Hook_SetDepthStencilSurface;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetDepthStencilSurface(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, nint pNewZStencil)
        {
            if (D3D9SetDepthStencilSurfaceHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pNewZStencil);
                }
                return hookItem.OriginalMethod.Invoke(@this, pNewZStencil);
            }
            return 0;
        }
    }
}
