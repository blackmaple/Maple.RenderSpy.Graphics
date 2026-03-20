using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetPixelShaderConstantBHookItem : HookItem<D3D9GetPixelShaderConstantBHookItem, Ptr_Func_GetPixelShaderConstantB_114, Ptr_Func_GetPixelShaderConstantB_114>, IHookItemFactory<D3D9GetPixelShaderConstantBHookItem>
    {
        public const string MethodName = Ptr_Func_GetPixelShaderConstantB_114.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.BOOL>, uint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetPixelShaderConstantBHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetPixelShaderConstantBHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetPixelShaderConstantBHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.BOOL>, uint, COM_HRESULT>
                _proc = &Hook_GetPixelShaderConstantB;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetPixelShaderConstantB(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint StartRegister, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.BOOL> pConstantData, uint BoolCount)
        {
            if (D3D9GetPixelShaderConstantBHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, StartRegister, pConstantData, BoolCount);
                }
                return hookItem.OriginalMethod.Invoke(@this, StartRegister, pConstantData, BoolCount);
            }
            return 0;
        }
    }
}
