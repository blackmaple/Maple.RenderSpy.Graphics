using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D10.COM_DXGISwapChain;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Dxgi;

namespace Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain
{
    internal class D3D10GetFullscreenStateHookItem : HookItem<D3D10GetFullscreenStateHookItem, Ptr_Func_GetFullscreenState_11, Ptr_Func_GetFullscreenState_11>, IGraphicsHookItem<D3D10GetFullscreenStateHookItem>
    {
        public const string MethodName = Ptr_Func_GetFullscreenState_11.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafePtr, UnsafeOut<UnsafePtr>, D3D10GetFullscreenStateHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D10GetFullscreenStateHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D10GetFullscreenStateHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D10GetFullscreenStateHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeOut<BOOL>, UnsafeOut<UnsafePtr>, COM_HRESULT>
                _proc = &Hook_GetFullscreenState;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetFullscreenState(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, UnsafeOut<BOOL> pFullscreen, UnsafeOut<UnsafePtr>  ppTarget)
        {
            if (D3D10GetFullscreenStateHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pFullscreen, ppTarget, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, pFullscreen, ppTarget);
            }
            return 0;
        }
    }
}
