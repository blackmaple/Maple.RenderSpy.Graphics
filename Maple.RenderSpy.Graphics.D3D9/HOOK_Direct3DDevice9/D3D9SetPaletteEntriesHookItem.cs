using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Gdi;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetPaletteEntriesHookItem : HookItem<D3D9SetPaletteEntriesHookItem, Ptr_Func_SetPaletteEntries_71, Ptr_Func_SetPaletteEntries_71>, IGraphicsHookItem<D3D9SetPaletteEntriesHookItem>
    {
        public const string MethodName = Ptr_Func_SetPaletteEntries_71.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, UnsafeRef<global::Windows.Win32.Graphics.Gdi.PALETTEENTRY>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetPaletteEntriesHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9SetPaletteEntriesHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetPaletteEntriesHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, UnsafeRef<global::Windows.Win32.Graphics.Gdi.PALETTEENTRY>, COM_HRESULT>
                _proc = &Hook_SetPaletteEntries;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetPaletteEntries(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint PaletteNumber, UnsafeRef<global::Windows.Win32.Graphics.Gdi.PALETTEENTRY> pEntries)
        {
            if (D3D9SetPaletteEntriesHookItem.TryGet(out var hookItem))
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
