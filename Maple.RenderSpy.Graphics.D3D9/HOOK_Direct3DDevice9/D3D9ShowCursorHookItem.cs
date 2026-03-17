using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9ShowCursorHookItem : HookItem<Ptr_Func_ShowCursor_12, Ptr_Func_ShowCursor_12>, IHookItemFactory<D3D9ShowCursorHookItem>
    {
        public const string MethodName = Ptr_Func_ShowCursor_12.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, int, D3D9ShowCursorHookItem, int>? SyncCallback { get; set; }

        public static D3D9ShowCursorHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9ShowCursorHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9ShowCursorHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, int, int>
                _proc = &Hook_ShowCursor;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_ShowCursor(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, int bShow)
        {
            if (D3D9ShowCursorHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, bShow, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, bShow);
            }
            return 0;
        }
    }
}
