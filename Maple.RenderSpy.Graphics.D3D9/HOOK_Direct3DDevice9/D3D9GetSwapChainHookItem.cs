using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetSwapChainHookItem : HookItem<D3D9GetSwapChainHookItem, Ptr_Func_GetSwapChain_14, Ptr_Func_GetSwapChain_14>, IHookItemFactory<D3D9GetSwapChainHookItem>
    {
        public const string MethodName = Ptr_Func_GetSwapChain_14.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, UnsafeOut<nint>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetSwapChainHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetSwapChainHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetSwapChainHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, UnsafeOut<nint>, COM_HRESULT>
                _proc = &Hook_GetSwapChain;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetSwapChain(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint iSwapChain, UnsafeOut<nint> ppSwapChain)
        {
            if (D3D9GetSwapChainHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, iSwapChain, ppSwapChain);
                }
                return hookItem.OriginalMethod.Invoke(@this, iSwapChain, ppSwapChain);
            }
            return 0;
        }
    }
}
