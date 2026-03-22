using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetSamplerStateHookItem : HookItem<D3D9GetSamplerStateHookItem, Ptr_Func_GetSamplerState_68, Ptr_Func_GetSamplerState_68>, IGraphicsHookItem<D3D9GetSamplerStateHookItem>
    {
        public const string MethodName = Ptr_Func_GetSamplerState_68.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, D3DSAMPLERSTATETYPE, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetSamplerStateHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetSamplerStateHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetSamplerStateHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, D3DSAMPLERSTATETYPE, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT>
                _proc = &Hook_GetSamplerState;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetSamplerState(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint Sampler, D3DSAMPLERSTATETYPE Type, Maple.UnmanagedExtensions.UnsafeRef<int> pValue)
        {
            if (D3D9GetSamplerStateHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Sampler, Type, pValue);
                }
                return hookItem.OriginalMethod.Invoke(@this, Sampler, Type, pValue);
            }
            return 0;
        }
    }
}
