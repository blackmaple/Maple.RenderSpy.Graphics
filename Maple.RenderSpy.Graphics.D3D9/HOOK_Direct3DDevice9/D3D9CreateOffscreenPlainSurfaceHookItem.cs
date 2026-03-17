using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9CreateOffscreenPlainSurfaceHookItem : HookItem<Ptr_Func_CreateOffscreenPlainSurface_36, Ptr_Func_CreateOffscreenPlainSurface_36>, IHookItemFactory<D3D9CreateOffscreenPlainSurfaceHookItem>
    {
        public const string MethodName = Ptr_Func_CreateOffscreenPlainSurface_36.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, D3DFORMAT, D3DPOOL, nint*, D3D9CreateOffscreenPlainSurfaceHookItem, int>? SyncCallback { get; set; }

        public static D3D9CreateOffscreenPlainSurfaceHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9CreateOffscreenPlainSurfaceHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9CreateOffscreenPlainSurfaceHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, D3DFORMAT, D3DPOOL, nint*, int>
                _proc = &Hook_CreateOffscreenPlainSurface;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_CreateOffscreenPlainSurface(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint Width, uint Height, D3DFORMAT Format, D3DPOOL Pool, nint* ppSurface)
        {
            if (D3D9CreateOffscreenPlainSurfaceHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Width, Height, Format, Pool, ppSurface, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Width, Height, Format, Pool, ppSurface);
            }
            return 0;
        }
    }
}
