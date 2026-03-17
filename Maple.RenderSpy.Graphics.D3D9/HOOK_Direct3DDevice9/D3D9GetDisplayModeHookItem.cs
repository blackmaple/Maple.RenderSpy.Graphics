using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetDisplayModeHookItem : HookItem<D3D9GetDisplayModeHookItem, Ptr_Func_GetDisplayMode_8, Ptr_Func_GetDisplayMode_8>, IHookItemFactory<D3D9GetDisplayModeHookItem>
    {
        public const string MethodName = Ptr_Func_GetDisplayMode_8.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, nint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetDisplayModeHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetDisplayModeHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetDisplayModeHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, nint, COM_HRESULT>
                _proc = &Hook_GetDisplayMode;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetDisplayMode(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint iSwapChain, nint pMode)
        {
            if (D3D9GetDisplayModeHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, iSwapChain, pMode);
                }
                return hookItem.OriginalMethod.Invoke(@this, iSwapChain, pMode);
            }
            return 0;
        }
    }
}
