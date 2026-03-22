using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Graphics.Gdi;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9StretchRectHookItem : HookItem<D3D9StretchRectHookItem, Ptr_Func_StretchRect_34, Ptr_Func_StretchRect_34>, IGraphicsHookItem<D3D9StretchRectHookItem>
    {
        public const string MethodName = Ptr_Func_StretchRect_34.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, nint, Maple.UnmanagedExtensions.UnsafeRef<Windows.Win32.Foundation.RECT>, nint, Maple.UnmanagedExtensions.UnsafeRef<Windows.Win32.Foundation.RECT>, D3DTEXTUREFILTERTYPE, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9StretchRectHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9StretchRectHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9StretchRectHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, nint, Maple.UnmanagedExtensions.UnsafeRef<Windows.Win32.Foundation.RECT>, nint, Maple.UnmanagedExtensions.UnsafeRef<Windows.Win32.Foundation.RECT>, D3DTEXTUREFILTERTYPE, COM_HRESULT>
                _proc = &Hook_StretchRect;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_StretchRect(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, nint pSourceSurface, Maple.UnmanagedExtensions.UnsafeRef<Windows.Win32.Foundation.RECT> pSourceRect, nint pDestSurface, Maple.UnmanagedExtensions.UnsafeRef<Windows.Win32.Foundation.RECT> pDestRect, D3DTEXTUREFILTERTYPE Filter)
        {
            if (D3D9StretchRectHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pSourceSurface, pSourceRect, pDestSurface, pDestRect, Filter);
                }
                return hookItem.OriginalMethod.Invoke(@this, pSourceSurface, pSourceRect, pDestSurface, pDestRect, Filter);
            }
            return 0;
        }
    }
}
