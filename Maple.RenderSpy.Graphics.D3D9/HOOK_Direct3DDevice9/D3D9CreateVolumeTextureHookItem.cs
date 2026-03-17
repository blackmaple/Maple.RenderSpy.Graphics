using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9CreateVolumeTextureHookItem : HookItem<Ptr_Func_CreateVolumeTexture_24, Ptr_Func_CreateVolumeTexture_24>, IHookItemFactory<D3D9CreateVolumeTextureHookItem>
    {
        public const string MethodName = Ptr_Func_CreateVolumeTexture_24.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, uint, uint, uint, D3DFORMAT, D3DPOOL, nint*, HANDLE*, D3D9CreateVolumeTextureHookItem, int>? SyncCallback { get; set; }

        public static D3D9CreateVolumeTextureHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
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
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, uint, uint, uint, D3DFORMAT, D3DPOOL, nint*, HANDLE*, int>
                _proc = &Hook_CreateVolumeTexture;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_CreateVolumeTexture(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint Width, uint Height, uint Depth, uint Levels, uint Usage, D3DFORMAT Format, D3DPOOL Pool, nint* ppVolumeTexture, HANDLE* pSharedHandle)
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
