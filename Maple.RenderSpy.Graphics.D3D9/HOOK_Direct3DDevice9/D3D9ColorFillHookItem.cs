using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Gdi;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9ColorFillHookItem : HookItem<D3D9ColorFillHookItem,Ptr_Func_ColorFill_35, Ptr_Func_ColorFill_35>, IGraphicsHookItem<D3D9ColorFillHookItem>
    {
        public const string MethodName = Ptr_Func_ColorFill_35.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, nint, Maple.UnmanagedExtensions.UnsafeRef<Windows.Win32.Foundation.RECT>, uint, D3D9ColorFillHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9ColorFillHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9ColorFillHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9ColorFillHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, nint, Maple.UnmanagedExtensions.UnsafeRef<Windows.Win32.Foundation.RECT>, uint, COM_HRESULT>
                _proc = &Hook_ColorFill;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_ColorFill(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, nint pSurface, Maple.UnmanagedExtensions.UnsafeRef<Windows.Win32.Foundation.RECT> pRect, uint color)
        {
            if (D3D9ColorFillHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pSurface, pRect, color, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, pSurface, pRect, color);
            }
            return 0;
        }
    }
}
