using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetCurrentTexturePaletteHookItem : HookItem<D3D9GetCurrentTexturePaletteHookItem, Ptr_Func_GetCurrentTexturePalette_74, Ptr_Func_GetCurrentTexturePalette_74>, IHookItemFactory<D3D9GetCurrentTexturePaletteHookItem>
    {
        public const string MethodName = Ptr_Func_GetCurrentTexturePalette_74.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, UnsafeRef<int>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetCurrentTexturePaletteHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetCurrentTexturePaletteHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetCurrentTexturePaletteHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, UnsafeRef<int>, COM_HRESULT>
                _proc = &Hook_GetCurrentTexturePalette;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetCurrentTexturePalette(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, UnsafeRef<int> pPaletteNumber)
        {
            if (D3D9GetCurrentTexturePaletteHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pPaletteNumber);
                }
                return hookItem.OriginalMethod.Invoke(@this, pPaletteNumber);
            }
            return 0;
        }
    }
}
