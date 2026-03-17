using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Graphics.Gdi;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9UpdateSurfaceHookItem : HookItem<D3D9UpdateSurfaceHookItem,Ptr_Func_UpdateSurface_30, Ptr_Func_UpdateSurface_30>, IHookItemFactory<D3D9UpdateSurfaceHookItem>
    {
        public const string MethodName = Ptr_Func_UpdateSurface_30.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, Maple.UnmanagedExtensions.UnsafeRef<Windows.Win32.Foundation.RECT>, nint, Maple.UnmanagedExtensions.UnsafeRef<global::System.Drawing.Point>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9UpdateSurfaceHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9UpdateSurfaceHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9UpdateSurfaceHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, Maple.UnmanagedExtensions.UnsafeRef<Windows.Win32.Foundation.RECT>, nint, Maple.UnmanagedExtensions.UnsafeRef<global::System.Drawing.Point>, COM_HRESULT>
                _proc = &Hook_UpdateSurface;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_UpdateSurface(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, nint pSourceSurface, Maple.UnmanagedExtensions.UnsafeRef<Windows.Win32.Foundation.RECT> pSourceRect, nint pDestinationSurface, Maple.UnmanagedExtensions.UnsafeRef<global::System.Drawing.Point> pDestPoint)
        {
            if (D3D9UpdateSurfaceHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pSourceSurface, pSourceRect, pDestinationSurface, pDestPoint);
                }
                return hookItem.OriginalMethod.Invoke(@this, pSourceSurface, pSourceRect, pDestinationSurface, pDestPoint);
            }
            return 0;
        }
    }
}
