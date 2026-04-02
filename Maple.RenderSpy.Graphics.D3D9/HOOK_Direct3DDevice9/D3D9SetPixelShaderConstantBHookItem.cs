using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetPixelShaderConstantBHookItem : HookItem<D3D9SetPixelShaderConstantBHookItem, Ptr_Func_SetPixelShaderConstantB_113, Ptr_Func_SetPixelShaderConstantB_113>, IGraphicsHookItem<D3D9SetPixelShaderConstantBHookItem>
    {
        public const string MethodName = Ptr_Func_SetPixelShaderConstantB_113.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.BOOL>, uint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetPixelShaderConstantBHookItem Create(ISupperHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9SetPixelShaderConstantBHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetPixelShaderConstantBHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.BOOL>, uint, COM_HRESULT>
                _proc = &Hook_SetPixelShaderConstantB;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetPixelShaderConstantB(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint StartRegister, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.BOOL> pConstantData, uint BoolCount)
        {
            if (D3D9SetPixelShaderConstantBHookItem.TryGet(out var hookItem))
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
