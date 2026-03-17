using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetClipPlaneHookItem : HookItem<Ptr_Func_GetClipPlane_56, Ptr_Func_GetClipPlane_56>, IHookItemFactory<D3D9GetClipPlaneHookItem>
    {
        public const string MethodName = Ptr_Func_GetClipPlane_56.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, nint, D3D9GetClipPlaneHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetClipPlaneHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetClipPlaneHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetClipPlaneHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, nint, COM_HRESULT>
                _proc = &Hook_GetClipPlane;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetClipPlane(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint Index, nint pPlane)
        {
            if (D3D9GetClipPlaneHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Index, pPlane, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Index, pPlane);
            }
            return 0;
        }
    }
}
