using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D10.COM_DXGISwapChain;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Dxgi;

namespace Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain
{
    internal class D3D10GetDescHookItem : HookItem<D3D10GetDescHookItem, Ptr_Func_GetDesc_12, Ptr_Func_GetDesc_12>, IGraphicsHookItem<D3D10GetDescHookItem>
    {
        public const string MethodName = Ptr_Func_GetDesc_12.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafePtr, D3D10GetDescHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D10GetDescHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D10GetDescHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D10GetDescHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeOut<DXGI_SWAP_CHAIN_DESC>, COM_HRESULT>
                _proc = &Hook_GetDesc;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetDesc(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, UnsafeOut<DXGI_SWAP_CHAIN_DESC> pDesc)
        {
            if (D3D10GetDescHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pDesc, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, pDesc);
            }
            return 0;
        }
    }
}
