using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetPixelShaderConstantIHookItem : HookItem<Ptr_Func_SetPixelShaderConstantI_111, Ptr_Func_SetPixelShaderConstantI_111>, IHookItemFactory<D3D9SetPixelShaderConstantIHookItem>
    {
        public const string MethodName = Ptr_Func_SetPixelShaderConstantI_111.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, int*, uint, D3D9SetPixelShaderConstantIHookItem, int>? SyncCallback { get; set; }

        public static D3D9SetPixelShaderConstantIHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetPixelShaderConstantIHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetPixelShaderConstantIHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, int*, uint, int>
                _proc = &Hook_SetPixelShaderConstantI;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_SetPixelShaderConstantI(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint StartRegister, int* pConstantData, uint Vector4iCount)
        {
            if (D3D9SetPixelShaderConstantIHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, StartRegister, pConstantData, Vector4iCount, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, StartRegister, pConstantData, Vector4iCount);
            }
            return 0;
        }
    }
}
