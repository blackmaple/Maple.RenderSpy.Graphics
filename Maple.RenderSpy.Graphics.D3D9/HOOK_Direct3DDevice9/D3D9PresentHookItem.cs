using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Gdi;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9PresentHookItem : HookItem<D3D9PresentHookItem, Ptr_Func_Present_17, Ptr_Func_Present_17>, IHookItemFactory<D3D9PresentHookItem>
    {
        public const string MethodName = Ptr_Func_Present_17.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, nint, nint, nint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9PresentHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9PresentHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9PresentHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT>, nint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Gdi.RGNDATA>, COM_HRESULT> _proc = &Hook_Present;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_Present(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT> pSourceRect, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT> pDestRect, nint hDestWindowOverride, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Gdi.RGNDATA> pDirtyRegion)
        {
            if (D3D9PresentHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pSourceRect, pDestRect, hDestWindowOverride, pDirtyRegion);
                }
                return hookItem.OriginalMethod.Invoke(@this, pSourceRect, pDestRect, hDestWindowOverride, pDirtyRegion);
            }
            return 0;
        }
    }
}
