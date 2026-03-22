using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetRasterStatusHookItem : HookItem<D3D9GetRasterStatusHookItem, Ptr_Func_GetRasterStatus_19, Ptr_Func_GetRasterStatus_19>, IGraphicsHookItem<D3D9GetRasterStatusHookItem>
    {
        public const string MethodName = Ptr_Func_GetRasterStatus_19.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DRASTER_STATUS>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetRasterStatusHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetRasterStatusHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetRasterStatusHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DRASTER_STATUS>, COM_HRESULT>
                _proc = &Hook_GetRasterStatus;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetRasterStatus(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint iSwapChain, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DRASTER_STATUS> pRasterStatus)
        {
            if (D3D9GetRasterStatusHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, iSwapChain, pRasterStatus);
                }
                return hookItem.OriginalMethod.Invoke(@this, iSwapChain, pRasterStatus);
            }
            return 0;
        }
    }
}
