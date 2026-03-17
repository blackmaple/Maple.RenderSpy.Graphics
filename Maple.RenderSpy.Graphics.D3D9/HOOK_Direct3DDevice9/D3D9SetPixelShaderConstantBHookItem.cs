using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetPixelShaderConstantBHookItem : HookItem<Ptr_Func_SetPixelShaderConstantB_113, Ptr_Func_SetPixelShaderConstantB_113>, IHookItemFactory<D3D9SetPixelShaderConstantBHookItem>
    {
        public const string MethodName = Ptr_Func_SetPixelShaderConstantB_113.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, byte*, uint, D3D9SetPixelShaderConstantBHookItem, int>? SyncCallback { get; set; }

        public static D3D9SetPixelShaderConstantBHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetPixelShaderConstantBHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetPixelShaderConstantBHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, byte*, uint, int>
                _proc = &Hook_SetPixelShaderConstantB;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_SetPixelShaderConstantB(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint StartRegister, byte* pConstantData, uint BoolCount)
        {
            if (D3D9SetPixelShaderConstantBHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, StartRegister, pConstantData, BoolCount, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, StartRegister, pConstantData, BoolCount);
            }
            return 0;
        }
    }
}
