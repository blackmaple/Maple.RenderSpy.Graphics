using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Gdi;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9ColorFillHookItem : HookItem<Ptr_Func_ColorFill_35, Ptr_Func_ColorFill_35>, IHookItemFactory<D3D9ColorFillHookItem>
    {
        public const string MethodName = Ptr_Func_ColorFill_35.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, RECT*, uint, D3D9ColorFillHookItem, int>? SyncCallback { get; set; }

        public static D3D9ColorFillHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
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
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, RECT*, uint, int>
                _proc = &Hook_ColorFill;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_ColorFill(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, nint pSurface, RECT* pRect, uint color)
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
