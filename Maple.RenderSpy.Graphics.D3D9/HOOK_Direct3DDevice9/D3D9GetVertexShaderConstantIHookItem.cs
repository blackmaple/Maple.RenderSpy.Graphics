using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetVertexShaderConstantIHookItem : HookItem<D3D9GetVertexShaderConstantIHookItem, Ptr_Func_GetVertexShaderConstantI_97, Ptr_Func_GetVertexShaderConstantI_97>, IGraphicsHookItem<D3D9GetVertexShaderConstantIHookItem>
    {
        public const string MethodName = Ptr_Func_GetVertexShaderConstantI_97.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<int>, uint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetVertexShaderConstantIHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetVertexShaderConstantIHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetVertexShaderConstantIHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<int>, uint, COM_HRESULT>
                _proc = &Hook_GetVertexShaderConstantI;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetVertexShaderConstantI(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint StartRegister, Maple.UnmanagedExtensions.UnsafeRef<int> pConstantData, uint Vector4iCount)
        {
            if (D3D9GetVertexShaderConstantIHookItem.TryGet(out var hookItem))
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
