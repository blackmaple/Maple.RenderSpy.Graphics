using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetCursorPositionHookItem : HookItem<Ptr_Func_SetCursorPosition_11, Ptr_Func_SetCursorPosition_11>, IHookItemFactory<D3D9SetCursorPositionHookItem>
    {
        public const string MethodName = Ptr_Func_SetCursorPosition_11.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, uint, D3D9SetCursorPositionHookItem, int>? SyncCallback { get; set; }

        public static D3D9SetCursorPositionHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetCursorPositionHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetCursorPositionHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, uint, int>
                _proc = &Hook_SetCursorPosition;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_SetCursorPosition(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint X, uint Y, uint Flags)
        {
            if (D3D9SetCursorPositionHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, X, Y, Flags, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, X, Y, Flags);
            }
            return 0;
        }
    }
}
