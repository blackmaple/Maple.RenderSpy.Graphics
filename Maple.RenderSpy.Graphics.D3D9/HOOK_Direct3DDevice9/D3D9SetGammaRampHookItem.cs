using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetGammaRampHookItem : HookItem<D3D9SetGammaRampHookItem, Ptr_Func_SetGammaRamp_21, Ptr_Func_SetGammaRamp_21>, IGraphicsHookItem<D3D9SetGammaRampHookItem>
    {
        public const string MethodName = Ptr_Func_SetGammaRamp_21.Name;

        public Action<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DGAMMARAMP>>? SyncCallback { get; set; }

        public static D3D9SetGammaRampHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9SetGammaRampHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetGammaRampHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DGAMMARAMP>, void>
                _proc = &Hook_SetGammaRamp;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static void Hook_SetGammaRamp(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint iSwapChain, uint Flags, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DGAMMARAMP> pRamp)
        {
            if (D3D9SetGammaRampHookItem.TryGet(out var hookItem))
            {
                hookItem.SyncCallback?.Invoke(@this, iSwapChain, Flags, pRamp);
                hookItem.OriginalMethod.Invoke(@this, iSwapChain, Flags, pRamp);
            }

        }
    }
}
