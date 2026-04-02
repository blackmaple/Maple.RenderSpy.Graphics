using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetDirect3DHookItem : HookItem<D3D9GetDirect3DHookItem, Ptr_Func_GetDirect3D_6, Ptr_Func_GetDirect3D_6>, IGraphicsHookItem<D3D9GetDirect3DHookItem>
    {
        public const string MethodName = Ptr_Func_GetDirect3D_6.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, UnsafeOut<nint>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetDirect3DHookItem Create(ISupperHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9GetDirect3DHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetDirect3DHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, UnsafeOut<nint>, COM_HRESULT>
                _proc = &Hook_GetDirect3D;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetDirect3D(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, UnsafeOut<nint> ppDirect3D)
        {
            if (D3D9GetDirect3DHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, ppDirect3D);
                }
                return hookItem.OriginalMethod.Invoke(@this, ppDirect3D);
            }
            return 0;
        }
    }
}
