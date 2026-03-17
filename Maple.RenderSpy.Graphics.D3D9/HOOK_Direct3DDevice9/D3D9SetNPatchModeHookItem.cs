using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetNPatchModeHookItem : HookItem<D3D9SetNPatchModeHookItem, Ptr_Func_SetNPatchMode_79, Ptr_Func_SetNPatchMode_79>, IHookItemFactory<D3D9SetNPatchModeHookItem>
    {
        public const string MethodName = Ptr_Func_SetNPatchMode_79.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, float, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetNPatchModeHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetNPatchModeHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetNPatchModeHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, float, COM_HRESULT>
                _proc = &Hook_SetNPatchMode;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetNPatchMode(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, float nSegments)
        {
            if (D3D9SetNPatchModeHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, nSegments);
                }
                return hookItem.OriginalMethod.Invoke(@this, nSegments);
            }
            return 0;
        }
    }
}
