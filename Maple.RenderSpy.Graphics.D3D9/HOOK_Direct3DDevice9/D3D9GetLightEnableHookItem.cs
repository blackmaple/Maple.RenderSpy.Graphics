using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetLightEnableHookItem : HookItem<D3D9GetLightEnableHookItem, Ptr_Func_GetLightEnable_54, Ptr_Func_GetLightEnable_54>, IGraphicsHookItem<D3D9GetLightEnableHookItem>
    {
        public const string MethodName = Ptr_Func_GetLightEnable_54.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.BOOL>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetLightEnableHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetLightEnableHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetLightEnableHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.BOOL>, COM_HRESULT>
                _proc = &Hook_GetLightEnable;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetLightEnable(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint Index, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.BOOL> pEnable)
        {
            if (D3D9GetLightEnableHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Index, pEnable);
                }
                return hookItem.OriginalMethod.Invoke(@this, Index, pEnable);
            }
            return 0;
        }
    }
}
