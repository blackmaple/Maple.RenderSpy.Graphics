using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetCursorPropertiesHookItem : HookItem<Ptr_Func_SetCursorProperties_10, Ptr_Func_SetCursorProperties_10>, IHookItemFactory<D3D9SetCursorPropertiesHookItem>
    {
        public const string MethodName = Ptr_Func_SetCursorProperties_10.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, nint, D3D9SetCursorPropertiesHookItem, int>? SyncCallback { get; set; }

        public static D3D9SetCursorPropertiesHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
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
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, nint, int>
                _proc = &Hook_SetCursorProperties;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_SetCursorProperties(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint XHotSpot, uint YHotSpot, nint pCursorBitmap)
        {
            if (D3D9SetCursorPropertiesHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, XHotSpot, YHotSpot, pCursorBitmap, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, XHotSpot, YHotSpot, pCursorBitmap);
            }
            return 0;
        }
    }
}
