using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9CreateVertexShaderHookItem : HookItem<D3D9CreateVertexShaderHookItem, Ptr_Func_CreateVertexShader_91, Ptr_Func_CreateVertexShader_91>, IGraphicsHookItem<D3D9CreateVertexShaderHookItem>
    {
        public const string MethodName = Ptr_Func_CreateVertexShader_91.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeRef<int>, Maple.UnmanagedExtensions.UnsafeOut<nint>, D3D9CreateVertexShaderHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9CreateVertexShaderHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9CreateVertexShaderHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9CreateVertexShaderHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeRef<int>, Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT>
                _proc = &Hook_CreateVertexShader;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_CreateVertexShader(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, Maple.UnmanagedExtensions.UnsafeRef<int> pFunction, Maple.UnmanagedExtensions.UnsafeOut<nint> ppShader)
        {
            if (D3D9CreateVertexShaderHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pFunction, ppShader, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, pFunction, ppShader);
            }
            return 0;
        }
    }
}
