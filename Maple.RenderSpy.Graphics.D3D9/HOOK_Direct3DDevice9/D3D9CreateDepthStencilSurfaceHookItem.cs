using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9CreateDepthStencilSurfaceHookItem : HookItem<D3D9CreateDepthStencilSurfaceHookItem, Ptr_Func_CreateDepthStencilSurface_29, Ptr_Func_CreateDepthStencilSurface_29>, IHookItemFactory<D3D9CreateDepthStencilSurfaceHookItem>
    {
        public const string MethodName = Ptr_Func_CreateDepthStencilSurface_29.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, D3DFORMAT, D3DMULTISAMPLE_TYPE, uint, int, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, D3D9CreateDepthStencilSurfaceHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9CreateDepthStencilSurfaceHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9CreateDepthStencilSurfaceHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9CreateDepthStencilSurfaceHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, D3DFORMAT, D3DMULTISAMPLE_TYPE, uint, int, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, COM_HRESULT>
                _proc = &Hook_CreateDepthStencilSurface;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_CreateDepthStencilSurface(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint Width, uint Height, D3DFORMAT Format, D3DMULTISAMPLE_TYPE MultiSample, uint MultisampleQuality, int Discard, Maple.UnmanagedExtensions.UnsafeOut<nint> ppSurface, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE> pSharedHandle)
        {
            if (D3D9CreateDepthStencilSurfaceHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Width, Height, Format, MultiSample, MultisampleQuality, Discard, ppSurface, pSharedHandle, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Width, Height, Format, MultiSample, MultisampleQuality, Discard, ppSurface, pSharedHandle);
            }
            return 0;
        }
    }
}
