using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9CreateRenderTargetHookItem : HookItem<D3D9CreateRenderTargetHookItem, Ptr_Func_CreateRenderTarget_28, Ptr_Func_CreateRenderTarget_28>, IHookItemFactory<D3D9CreateRenderTargetHookItem>
    {
        public const string MethodName = Ptr_Func_CreateRenderTarget_28.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, D3DFORMAT, D3DMULTISAMPLE_TYPE, uint, int, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, D3D9CreateRenderTargetHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9CreateRenderTargetHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9CreateRenderTargetHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9CreateRenderTargetHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, D3DFORMAT, D3DMULTISAMPLE_TYPE, uint, int, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, COM_HRESULT>
                _proc = &Hook_CreateRenderTarget;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_CreateRenderTarget(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint Width, uint Height, D3DFORMAT Format, D3DMULTISAMPLE_TYPE MultiSample, uint MultisampleQuality, int Lockable, Maple.UnmanagedExtensions.UnsafeOut<nint> ppSurface, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE> pSharedHandle)
        {
            if (D3D9CreateRenderTargetHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Width, Height, Format, MultiSample, MultisampleQuality, Lockable, ppSurface, pSharedHandle, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Width, Height, Format, MultiSample, MultisampleQuality, Lockable, ppSurface, pSharedHandle);
            }
            return 0;
        }
    }
}
