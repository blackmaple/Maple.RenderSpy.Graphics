using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9CreateCubeTextureHookItem : HookItem<Ptr_Func_CreateCubeTexture_25, Ptr_Func_CreateCubeTexture_25>, IHookItemFactory<D3D9CreateCubeTextureHookItem>
    {
        public const string MethodName = Ptr_Func_CreateCubeTexture_25.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, uint, uint, D3DFORMAT, D3DPOOL, nint*, HANDLE*, D3D9CreateCubeTextureHookItem, int>? SyncCallback { get; set; }

        public static D3D9CreateCubeTextureHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9CreateCubeTextureHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9CreateCubeTextureHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, uint, uint, D3DFORMAT, D3DPOOL, nint*, HANDLE*, int>
                _proc = &Hook_CreateCubeTexture;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_CreateCubeTexture(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint EdgeLength, uint Levels, uint Usage, D3DFORMAT Format, D3DPOOL Pool, nint* ppCubeTexture, HANDLE* pSharedHandle)
        {
            if (D3D9CreateCubeTextureHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, EdgeLength, Levels, Usage, Format, Pool, ppCubeTexture, pSharedHandle, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, EdgeLength, Levels, Usage, Format, Pool, ppCubeTexture, pSharedHandle);
            }
            return 0;
        }
    }
}
