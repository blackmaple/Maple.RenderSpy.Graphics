using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetRenderTargetHookItem : HookItem<D3D9GetRenderTargetHookItem, Ptr_Func_GetRenderTarget_38, Ptr_Func_GetRenderTarget_38>, IHookItemFactory<D3D9GetRenderTargetHookItem>
    {
        public const string MethodName = Ptr_Func_GetRenderTarget_38.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetRenderTargetHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetRenderTargetHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetRenderTargetHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT>
                _proc = &Hook_GetRenderTarget;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetRenderTarget(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint RenderTargetIndex, Maple.UnmanagedExtensions.UnsafeOut<nint> ppRenderTarget)
        {
            if (D3D9GetRenderTargetHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, RenderTargetIndex, ppRenderTarget);
                }
                return hookItem.OriginalMethod.Invoke(@this, RenderTargetIndex, ppRenderTarget);
            }
            return 0;
        }
    }
}
