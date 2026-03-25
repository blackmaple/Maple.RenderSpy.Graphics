using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D10.COM_DXGISwapChain;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain
{
    internal class D3D10GetContainingOutputHookItem : HookItem<D3D10GetContainingOutputHookItem, Ptr_Func_GetContainingOutput_15, Ptr_Func_GetContainingOutput_15>, IGraphicsHookItem<D3D10GetContainingOutputHookItem>
    {
        public const string MethodName = Ptr_Func_GetContainingOutput_15.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafePtr, D3D10GetContainingOutputHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D10GetContainingOutputHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D10GetContainingOutputHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D10GetContainingOutputHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeOut<nint>, COM_HRESULT>
                _proc = &Hook_GetContainingOutput;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetContainingOutput(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, UnsafeOut<nint> ppOutput)
        {
            if (D3D10GetContainingOutputHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, ppOutput, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, ppOutput);
            }
            return COM_HRESULT.S_FALSE;
        }
    }
}
