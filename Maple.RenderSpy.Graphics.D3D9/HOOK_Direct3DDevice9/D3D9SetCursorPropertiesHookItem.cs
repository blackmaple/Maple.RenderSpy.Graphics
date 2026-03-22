using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetCursorPropertiesHookItem : HookItem<D3D9SetCursorPropertiesHookItem, Ptr_Func_SetCursorProperties_10, Ptr_Func_SetCursorProperties_10>, IGraphicsHookItem<D3D9SetCursorPropertiesHookItem>
    {
        public const string MethodName = Ptr_Func_SetCursorProperties_10.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, nint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetCursorPropertiesHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetCursorPropertiesHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetCursorPropertiesHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, nint, COM_HRESULT>
                _proc = &Hook_SetCursorProperties;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetCursorProperties(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint XHotSpot, uint YHotSpot, nint pCursorBitmap)
        {
            if (D3D9SetCursorPropertiesHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, XHotSpot, YHotSpot, pCursorBitmap);
                }
                return hookItem.OriginalMethod.Invoke(@this, XHotSpot, YHotSpot, pCursorBitmap);
            }
            return 0;
        }
    }
}
