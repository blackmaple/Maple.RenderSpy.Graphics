using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetVertexShaderHookItem : HookItem<D3D9GetVertexShaderHookItem, Ptr_Func_GetVertexShader_93, Ptr_Func_GetVertexShader_93>, IHookItemFactory<D3D9GetVertexShaderHookItem>
    {
        public const string MethodName = Ptr_Func_GetVertexShader_93.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, UnsafeOut<nint>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetVertexShaderHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetVertexShaderHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetVertexShaderHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, UnsafeOut<nint>, COM_HRESULT>
                _proc = &Hook_GetVertexShader;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetVertexShader(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, UnsafeOut<nint> ppShader)
        {
            if (D3D9GetVertexShaderHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, ppShader);
                }
                return hookItem.OriginalMethod.Invoke(@this, ppShader);
            }
            return 0;
        }
    }
}
