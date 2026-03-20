using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9ClearHookItem : HookItem<D3D9ClearHookItem, Ptr_Func_Clear_43, Ptr_Func_Clear_43>, IHookItemFactory<D3D9ClearHookItem>
    {
        public const string MethodName = Ptr_Func_Clear_43.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DRECT>, uint, uint, float, uint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9ClearHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9ClearHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9ClearHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DRECT>, uint, uint, float, uint, COM_HRESULT>
                _proc = &Hook_Clear;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_Clear(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint Count, UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DRECT> pRects, uint Flags, uint Color, float Z, uint Stencil)
        {
            if (D3D9ClearHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Count, pRects, Flags, Color, Z, Stencil);
                }
                return hookItem.OriginalMethod.Invoke(@this, Count, pRects, Flags, Color, Z, Stencil);
            }
            return 0;
        }
    }
}
