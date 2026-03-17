using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Gdi;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetScissorRectHookItem : HookItem<D3D9SetScissorRectHookItem, Ptr_Func_SetScissorRect_75, Ptr_Func_SetScissorRect_75>, IHookItemFactory<D3D9SetScissorRectHookItem>
    {
        public const string MethodName = Ptr_Func_SetScissorRect_75.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, D3D9SetScissorRectHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetScissorRectHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetScissorRectHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetScissorRectHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT>
                _proc = &Hook_SetScissorRect;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetScissorRect(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, nint pRect)
        {
            if (D3D9SetScissorRectHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pRect, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, pRect);
            }
            return 0;
        }
    }
}
