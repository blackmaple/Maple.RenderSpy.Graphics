using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetPaletteEntriesHookItem : HookItem<Ptr_Func_SetPaletteEntries_71, Ptr_Func_SetPaletteEntries_71>, IHookItemFactory<D3D9SetPaletteEntriesHookItem>
    {
        public const string MethodName = Ptr_Func_SetPaletteEntries_71.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, ushort*, D3D9SetPaletteEntriesHookItem, int>? SyncCallback { get; set; }

        public static D3D9SetPaletteEntriesHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetPaletteEntriesHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetPaletteEntriesHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, ushort*, int>
                _proc = &Hook_SetPaletteEntries;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_SetPaletteEntries(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint PaletteNumber, ushort* pEntries)
        {
            if (D3D9SetPaletteEntriesHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, PaletteNumber, pEntries, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, PaletteNumber, pEntries);
            }
            return 0;
        }
    }
}
