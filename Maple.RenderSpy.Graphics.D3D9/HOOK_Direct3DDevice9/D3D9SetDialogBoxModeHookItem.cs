using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetDialogBoxModeHookItem : HookItem<D3D9SetDialogBoxModeHookItem, Ptr_Func_SetDialogBoxMode_20, Ptr_Func_SetDialogBoxMode_20>, IHookItemFactory<D3D9SetDialogBoxModeHookItem>
    {
        public const string MethodName = Ptr_Func_SetDialogBoxMode_20.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, int, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetDialogBoxModeHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetDialogBoxModeHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetDialogBoxModeHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, int, COM_HRESULT>
                _proc = &Hook_SetDialogBoxMode;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetDialogBoxMode(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, int bEnableDialogs)
        {
            if (D3D9SetDialogBoxModeHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, bEnableDialogs);
                }
                return hookItem.OriginalMethod.Invoke(@this, bEnableDialogs);
            }
            return 0;
        }
    }
}
