using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Dxgi.Common;
using Maple.RenderSpy.Graphics.DXGI.COM_DXGISwapChain;

namespace Maple.RenderSpy.Graphics.DXGI.HOOK_DXGISwapChain
{
    internal class DXGIResizeBuffersHookItem : HookItem<DXGIResizeBuffersHookItem, Ptr_Func_ResizeBuffers_13, Ptr_Func_ResizeBuffers_13>, IGraphicsHookItem<DXGIResizeBuffersHookItem>
    {
        public const string MethodName = Ptr_Func_ResizeBuffers_13.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, uint, uint, uint, uint, uint, DXGIResizeBuffersHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static DXGIResizeBuffersHookItem Create(ISupperHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<DXGIResizeBuffersHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<DXGIResizeBuffersHookItem>(
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
            if (DXGIResizeBuffersHookItem.TryGet(out var hookItem))
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
