using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Graphics.Direct3D;
using Maple.UnmanagedExtensions;
using Maple.RenderSpy.Graphics.Windows.COM;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9MultiplyTransformHookItem : HookItem<D3D9MultiplyTransformHookItem, Ptr_Func_MultiplyTransform_46, Ptr_Func_MultiplyTransform_46>, IGraphicsHookItem<D3D9MultiplyTransformHookItem>
    {
        public const string MethodName = Ptr_Func_MultiplyTransform_46.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, D3DTRANSFORMSTATETYPE, UnsafeRef<global::Windows.Win32.Graphics.Direct3D.D3DMATRIX>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9MultiplyTransformHookItem Create(ISupperHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9MultiplyTransformHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9MultiplyTransformHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, D3DTRANSFORMSTATETYPE, UnsafeRef<global::Windows.Win32.Graphics.Direct3D.D3DMATRIX>, COM_HRESULT>
                _proc = &Hook_MultiplyTransform;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_MultiplyTransform(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, D3DTRANSFORMSTATETYPE State, UnsafeRef<global::Windows.Win32.Graphics.Direct3D.D3DMATRIX> pMatrix)
        {
            if (D3D9MultiplyTransformHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, State, pMatrix);
                }
                return hookItem.OriginalMethod.Invoke(@this, State, pMatrix);
            }
            return 0;
        }
    }
}
