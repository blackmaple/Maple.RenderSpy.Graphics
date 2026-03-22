using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetRenderStateHookItem : HookItem<D3D9SetRenderStateHookItem, Ptr_Func_SetRenderState_57, Ptr_Func_SetRenderState_57>, IGraphicsHookItem<D3D9SetRenderStateHookItem>
    {
        public const string MethodName = Ptr_Func_SetRenderState_57.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, D3DRENDERSTATETYPE, uint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetRenderStateHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetRenderStateHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetRenderStateHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, D3DRENDERSTATETYPE, uint, COM_HRESULT>
                _proc = &Hook_SetRenderState;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetRenderState(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, D3DRENDERSTATETYPE State, uint Value)
        {
            if (D3D9SetRenderStateHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, State, Value);
                }
                return hookItem.OriginalMethod.Invoke(@this, State, Value);
            }
            return 0;
        }
    }
}
