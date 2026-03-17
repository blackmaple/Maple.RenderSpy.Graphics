using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetRenderStateHookItem : HookItem<D3D9GetRenderStateHookItem, Ptr_Func_GetRenderState_58, Ptr_Func_GetRenderState_58>, IHookItemFactory<D3D9GetRenderStateHookItem>
    {
        public const string MethodName = Ptr_Func_GetRenderState_58.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DRENDERSTATETYPE, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetRenderStateHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetRenderStateHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetRenderStateHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DRENDERSTATETYPE, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT>
                _proc = &Hook_GetRenderState;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetRenderState(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, D3DRENDERSTATETYPE State, Maple.UnmanagedExtensions.UnsafeRef<int> pValue)
        {
            if (D3D9GetRenderStateHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, State, pValue);
                }
                return hookItem.OriginalMethod.Invoke(@this, State, pValue);
            }
            return 0;
        }
    }
}
