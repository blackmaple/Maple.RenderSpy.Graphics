using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;
using Maple.RenderSpy.Graphics.COM;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9CreateVolumeTextureHookItem : HookItem<D3D9CreateVolumeTextureHookItem,Ptr_Func_CreateVolumeTexture_24, Ptr_Func_CreateVolumeTexture_24>, IGraphicsHookItem<D3D9CreateVolumeTextureHookItem>
    {
        public const string MethodName = Ptr_Func_CreateVolumeTexture_24.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, uint, uint, uint, D3DFORMAT, D3DPOOL, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, D3D9CreateVolumeTextureHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9CreateVolumeTextureHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9CreateVolumeTextureHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9CreateVolumeTextureHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, uint, uint, uint, D3DFORMAT, D3DPOOL, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, COM_HRESULT>
                _proc = &Hook_CreateVolumeTexture;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_CreateVolumeTexture(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint Width, uint Height, uint Depth, uint Levels, uint Usage, D3DFORMAT Format, D3DPOOL Pool, Maple.UnmanagedExtensions.UnsafeOut<nint> ppVolumeTexture, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE> pSharedHandle)
        {
            if (D3D9CreateVolumeTextureHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Width, Height, Depth, Levels, Usage, Format, Pool, ppVolumeTexture, pSharedHandle, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Width, Height, Depth, Levels, Usage, Format, Pool, ppVolumeTexture, pSharedHandle);
            }
            return 0;
        }
    }
}
