using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9CreateVertexDeclarationHookItem : HookItem<D3D9CreateVertexDeclarationHookItem, Ptr_Func_CreateVertexDeclaration_86, Ptr_Func_CreateVertexDeclaration_86>, IGraphicsHookItem<D3D9CreateVertexDeclarationHookItem>
    {
        public const string MethodName = Ptr_Func_CreateVertexDeclaration_86.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeOut<global::Windows.Win32.Graphics.Direct3D9.D3DVERTEXELEMENT9>, Maple.UnmanagedExtensions.UnsafeOut<nint>, D3D9CreateVertexDeclarationHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9CreateVertexDeclarationHookItem Create(ISupperHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9CreateVertexDeclarationHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9CreateVertexDeclarationHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeOut<global::Windows.Win32.Graphics.Direct3D9.D3DVERTEXELEMENT9>, Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT>
                _proc = &Hook_CreateVertexDeclaration;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_CreateVertexDeclaration(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, Maple.UnmanagedExtensions.UnsafeOut<global::Windows.Win32.Graphics.Direct3D9.D3DVERTEXELEMENT9> pVertexElements,Maple.UnmanagedExtensions.UnsafeOut<nint> ppDecl)
        {
            if (D3D9CreateVertexDeclarationHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pVertexElements, ppDecl, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, pVertexElements, ppDecl);
            }
            return 0;
        }
    }
}
