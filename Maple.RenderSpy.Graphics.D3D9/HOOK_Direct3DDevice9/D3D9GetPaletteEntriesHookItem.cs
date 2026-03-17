using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Gdi;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetPaletteEntriesHookItem : HookItem<D3D9GetPaletteEntriesHookItem, Ptr_Func_GetPaletteEntries_72, Ptr_Func_GetPaletteEntries_72>, IHookItemFactory<D3D9GetPaletteEntriesHookItem>
    {
        public const string MethodName = Ptr_Func_GetPaletteEntries_72.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, UnsafeRef<global::Windows.Win32.Graphics.Gdi.PALETTEENTRY>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetPaletteEntriesHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetPaletteEntriesHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetPaletteEntriesHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, UnsafeRef<global::Windows.Win32.Graphics.Gdi.PALETTEENTRY>, COM_HRESULT>
                _proc = &Hook_GetPaletteEntries;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetPaletteEntries(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint PaletteNumber, UnsafeRef<global::Windows.Win32.Graphics.Gdi.PALETTEENTRY> pEntries)
        {
            if (D3D9GetPaletteEntriesHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, PaletteNumber, pEntries);
                }
                return hookItem.OriginalMethod.Invoke(@this, PaletteNumber, pEntries);
            }
            return 0;
        }
    }
}
