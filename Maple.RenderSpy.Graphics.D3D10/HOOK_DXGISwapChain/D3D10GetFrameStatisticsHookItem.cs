using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D10.COM_DXGISwapChain;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Dxgi;

namespace Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain
{
    internal class D3D10GetFrameStatisticsHookItem : HookItem<D3D10GetFrameStatisticsHookItem, Ptr_Func_GetFrameStatistics_16, Ptr_Func_GetFrameStatistics_16>, IGraphicsHookItem<D3D10GetFrameStatisticsHookItem>
    {
        public const string MethodName = Ptr_Func_GetFrameStatistics_16.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafePtr, D3D10GetFrameStatisticsHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D10GetFrameStatisticsHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D10GetFrameStatisticsHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D10GetFrameStatisticsHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeOut<DXGI_FRAME_STATISTICS>, COM_HRESULT>
                _proc = &Hook_GetFrameStatistics;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetFrameStatistics(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, UnsafeOut<DXGI_FRAME_STATISTICS> pStats)
        {
            if (D3D10GetFrameStatisticsHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pStats, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, pStats);
            }
            return 0;
        }
    }
}
