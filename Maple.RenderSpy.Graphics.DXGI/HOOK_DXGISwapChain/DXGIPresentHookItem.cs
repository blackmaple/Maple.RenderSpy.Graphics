using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Dxgi;
using Maple.RenderSpy.Graphics.DXGI.COM_DXGISwapChain;

namespace Maple.RenderSpy.Graphics.DXGI.HOOK_DXGISwapChain
{
    public class DXGIPresentHookItem : HookItem<DXGIPresentHookItem, Ptr_Func_Present_8, Ptr_Func_Present_8>, IGraphicsHookItem<DXGIPresentHookItem>
    {
        public const string MethodName = Ptr_Func_Present_8.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, uint, uint, DXGIPresentHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static DXGIPresentHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<DXGIPresentHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<DXGIPresentHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, uint, uint, COM_HRESULT>
                _proc = &Hook_Present;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_Present(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, uint SyncInterval, uint Flags)
        {
            if (DXGIPresentHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, SyncInterval,  Flags, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, SyncInterval, Flags);
            }
            return 0;
        }
    }
}
