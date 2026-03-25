using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetDeviceCapsHookItem : HookItem<D3D9GetDeviceCapsHookItem, Ptr_Func_GetDeviceCaps_7, Ptr_Func_GetDeviceCaps_7>, IGraphicsHookItem<D3D9GetDeviceCapsHookItem>
    {
        public const string MethodName = Ptr_Func_GetDeviceCaps_7.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DCAPS9>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetDeviceCapsHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9GetDeviceCapsHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetDeviceCapsHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DCAPS9>, COM_HRESULT>
                _proc = &Hook_GetDeviceCaps;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetDeviceCaps(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DCAPS9> pCaps)
        {
            if (D3D9GetDeviceCapsHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pCaps);
                }
                return hookItem.OriginalMethod.Invoke(@this, pCaps);
            }
            return 0;
        }
    }
}
