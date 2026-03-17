using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetVertexShaderConstantFHookItem : HookItem<Ptr_Func_GetVertexShaderConstantF_95, Ptr_Func_GetVertexShaderConstantF_95>, IHookItemFactory<D3D9GetVertexShaderConstantFHookItem>
    {
        public const string MethodName = Ptr_Func_GetVertexShaderConstantF_95.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, nint, uint, D3D9GetVertexShaderConstantFHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetVertexShaderConstantFHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetVertexShaderConstantFHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetVertexShaderConstantFHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, nint, uint, COM_HRESULT>
                _proc = &Hook_GetVertexShaderConstantF;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetVertexShaderConstantF(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint StartRegister, nint pConstantData, uint Vector4fCount)
        {
            if (D3D9GetVertexShaderConstantFHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, StartRegister, pConstantData, Vector4fCount, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, StartRegister, pConstantData, Vector4fCount);
            }
            return 0;
        }
    }
}
