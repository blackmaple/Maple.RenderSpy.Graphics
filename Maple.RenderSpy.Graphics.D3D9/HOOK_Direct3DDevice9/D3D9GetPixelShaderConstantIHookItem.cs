using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetPixelShaderConstantIHookItem : HookItem<D3D9GetPixelShaderConstantIHookItem, Ptr_Func_GetPixelShaderConstantI_112, Ptr_Func_GetPixelShaderConstantI_112>, IGraphicsHookItem<D3D9GetPixelShaderConstantIHookItem>
    {
        public const string MethodName = Ptr_Func_GetPixelShaderConstantI_112.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<int>, uint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetPixelShaderConstantIHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetPixelShaderConstantIHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetPixelShaderConstantIHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<int>, uint, COM_HRESULT>
                _proc = &Hook_GetPixelShaderConstantI;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetPixelShaderConstantI(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint StartRegister, Maple.UnmanagedExtensions.UnsafeRef<int> pConstantData, uint Vector4iCount)
        {
            if (D3D9GetPixelShaderConstantIHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, StartRegister, pConstantData, Vector4iCount);
                }
                return hookItem.OriginalMethod.Invoke(@this, StartRegister, pConstantData, Vector4iCount);
            }
            return 0;
        }
    }
}
