using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetRenderTargetHookItem : HookItem<D3D9SetRenderTargetHookItem, Ptr_Func_SetRenderTarget_37, Ptr_Func_SetRenderTarget_37>, IGraphicsHookItem<D3D9SetRenderTargetHookItem>
    {
        public const string MethodName = Ptr_Func_SetRenderTarget_37.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, nint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetRenderTargetHookItem Create(ISupperHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9SetRenderTargetHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetRenderTargetHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, nint, COM_HRESULT>
                _proc = &Hook_SetRenderTarget;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetRenderTarget(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint RenderTargetIndex, nint pRenderTarget)
        {
            if (D3D9SetRenderTargetHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, RenderTargetIndex, pRenderTarget);
                }
                return hookItem.OriginalMethod.Invoke(@this, RenderTargetIndex, pRenderTarget);
            }
            return 0;
        }
    }
}
