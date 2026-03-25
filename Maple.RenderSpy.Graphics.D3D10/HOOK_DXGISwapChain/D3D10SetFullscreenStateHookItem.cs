using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D10.COM_DXGISwapChain;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain
{
    internal class D3D10SetFullscreenStateHookItem : HookItem<D3D10SetFullscreenStateHookItem, Ptr_Func_SetFullscreenState_10, Ptr_Func_SetFullscreenState_10>, IGraphicsHookItem<D3D10SetFullscreenStateHookItem>
    {
        public const string MethodName = Ptr_Func_SetFullscreenState_10.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, int, UnsafePtr, D3D10SetFullscreenStateHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D10SetFullscreenStateHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D10SetFullscreenStateHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D10SetFullscreenStateHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, int, UnsafePtr, COM_HRESULT>
                _proc = &Hook_SetFullscreenState;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetFullscreenState(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, int Fullscreen, UnsafePtr pTarget)
        {
            if (D3D10SetFullscreenStateHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Fullscreen, pTarget, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Fullscreen, pTarget);
            }
            return 0;
        }
    }
}
