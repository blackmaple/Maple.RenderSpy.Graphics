using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetCurrentTexturePaletteHookItem : HookItem<D3D9SetCurrentTexturePaletteHookItem, Ptr_Func_SetCurrentTexturePalette_73, Ptr_Func_SetCurrentTexturePalette_73>, IHookItemFactory<D3D9SetCurrentTexturePaletteHookItem>
    {
        public const string MethodName = Ptr_Func_SetCurrentTexturePalette_73.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetCurrentTexturePaletteHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetCurrentTexturePaletteHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetCurrentTexturePaletteHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, COM_HRESULT>
                _proc = &Hook_SetCurrentTexturePalette;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetCurrentTexturePalette(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint PaletteNumber)
        {
            if (D3D9SetCurrentTexturePaletteHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, PaletteNumber);
                }
                return hookItem.OriginalMethod.Invoke(@this, PaletteNumber);
            }
            return 0;
        }
    }
}
