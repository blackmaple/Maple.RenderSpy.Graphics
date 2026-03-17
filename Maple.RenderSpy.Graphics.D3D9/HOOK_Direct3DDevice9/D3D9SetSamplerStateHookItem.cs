using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetSamplerStateHookItem : HookItem<Ptr_Func_SetSamplerState_69, Ptr_Func_SetSamplerState_69>, IHookItemFactory<D3D9SetSamplerStateHookItem>
    {
        public const string MethodName = Ptr_Func_SetSamplerState_69.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, D3DSAMPLERSTATETYPE, uint, D3D9SetSamplerStateHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetSamplerStateHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetSamplerStateHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetSamplerStateHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, D3DSAMPLERSTATETYPE, uint, COM_HRESULT>
                _proc = &Hook_SetSamplerState;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetSamplerState(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint Sampler, D3DSAMPLERSTATETYPE Type, uint Value)
        {
            if (D3D9SetSamplerStateHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Sampler, Type, Value, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Sampler, Type, Value);
            }
            return 0;
        }
    }
}
