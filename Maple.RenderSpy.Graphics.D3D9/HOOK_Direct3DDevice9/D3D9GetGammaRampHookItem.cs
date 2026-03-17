using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetGammaRampHookItem : HookItem<D3D9GetGammaRampHookItem, Ptr_Func_GetGammaRamp_22, Ptr_Func_GetGammaRamp_22>, IHookItemFactory<D3D9GetGammaRampHookItem>
    {
        public const string MethodName = Ptr_Func_GetGammaRamp_22.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, nint, int>? SyncCallback { get; set; }

        public static D3D9GetGammaRampHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetGammaRampHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetGammaRampHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, nint, int>
                _proc = &Hook_GetGammaRamp;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_GetGammaRamp(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint iSwapChain, nint pRamp)
        {
            if (D3D9GetGammaRampHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, iSwapChain, pRamp);
                }
                return hookItem.OriginalMethod.Invoke(@this, iSwapChain, pRamp);
            }
            return 0;
        }
    }
}
