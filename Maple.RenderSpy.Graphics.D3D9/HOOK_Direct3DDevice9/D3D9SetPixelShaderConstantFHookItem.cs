using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetPixelShaderConstantFHookItem : HookItem<D3D9SetPixelShaderConstantFHookItem, Ptr_Func_SetPixelShaderConstantF_109, Ptr_Func_SetPixelShaderConstantF_109>, IGraphicsHookItem<D3D9SetPixelShaderConstantFHookItem>
    {
        public const string MethodName = Ptr_Func_SetPixelShaderConstantF_109.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<float>, uint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetPixelShaderConstantFHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9SetPixelShaderConstantFHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetPixelShaderConstantFHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<float>, uint, COM_HRESULT>
                _proc = &Hook_SetPixelShaderConstantF;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetPixelShaderConstantF(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint StartRegister, Maple.UnmanagedExtensions.UnsafeRef<float> pConstantData, uint Vector4fCount)
        {
            if (D3D9SetPixelShaderConstantFHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, StartRegister, pConstantData, Vector4fCount);
                }
                return hookItem.OriginalMethod.Invoke(@this, StartRegister, pConstantData, Vector4fCount);
            }
            return 0;
        }
    }
}
