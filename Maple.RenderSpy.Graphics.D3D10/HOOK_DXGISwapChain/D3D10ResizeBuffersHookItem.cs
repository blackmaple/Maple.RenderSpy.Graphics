using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D10.COM_DXGISwapChain;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Dxgi.Common;

namespace Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain
{
    internal class D3D10ResizeBuffersHookItem : HookItem<D3D10ResizeBuffersHookItem, Ptr_Func_ResizeBuffers_13, Ptr_Func_ResizeBuffers_13>, IHookItemFactory<D3D10ResizeBuffersHookItem>
    {
        public const string MethodName = Ptr_Func_ResizeBuffers_13.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, uint, uint, uint, uint, uint, D3D10ResizeBuffersHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D10ResizeBuffersHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D10ResizeBuffersHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D10ResizeBuffersHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, uint, uint, uint, DXGI_FORMAT, uint, COM_HRESULT>
                _proc = &Hook_ResizeBuffers;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_ResizeBuffers(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, uint BufferCount, uint Width, uint Height, DXGI_FORMAT NewFormat, uint SwapChainFlags)
        {
            if (D3D10ResizeBuffersHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, BufferCount, Width, Height, (uint)NewFormat, SwapChainFlags, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, BufferCount, Width, Height, NewFormat, SwapChainFlags);
            }
            return 0;
        }
    }
}
