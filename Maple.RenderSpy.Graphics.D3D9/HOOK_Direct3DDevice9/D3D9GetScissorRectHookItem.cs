using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetScissorRectHookItem : HookItem<D3D9GetScissorRectHookItem, Ptr_Func_GetScissorRect_76, Ptr_Func_GetScissorRect_76>, IHookItemFactory<D3D9GetScissorRectHookItem>
    {
        public const string MethodName = Ptr_Func_GetScissorRect_76.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetScissorRectHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetScissorRectHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetScissorRectHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT>, COM_HRESULT>
                _proc = &Hook_GetScissorRect;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetScissorRect(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.RECT> pRect)
        {
            if (D3D9GetScissorRectHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pRect);
                }
                return hookItem.OriginalMethod.Invoke(@this, pRect);
            }
            return 0;
        }
    }
}
