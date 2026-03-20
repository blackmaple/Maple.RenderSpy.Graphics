using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetLightHookItem : HookItem<D3D9GetLightHookItem, Ptr_Func_GetLight_52, Ptr_Func_GetLight_52>, IHookItemFactory<D3D9GetLightHookItem>
    {
        public const string MethodName = Ptr_Func_GetLight_52.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DLIGHT9>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetLightHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetLightHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetLightHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DLIGHT9>, COM_HRESULT>
                _proc = &Hook_GetLight;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetLight(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint Index, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DLIGHT9> pLight)
        {
            if (D3D9GetLightHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Index, pLight);
                }
                return hookItem.OriginalMethod.Invoke(@this, Index, pLight);
            }
            return 0;
        }
    }
}
