using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Graphics.Direct3D;
using Maple.UnmanagedExtensions;
using Maple.RenderSpy.Graphics.COM;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetTransformHookItem : HookItem<D3D9GetTransformHookItem, Ptr_Func_GetTransform_45, Ptr_Func_GetTransform_45>, IGraphicsHookItem<D3D9GetTransformHookItem>
    {
        public const string MethodName = Ptr_Func_GetTransform_45.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, D3DTRANSFORMSTATETYPE, UnsafeRef<global::Windows.Win32.Graphics.Direct3D.D3DMATRIX>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetTransformHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetTransformHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetTransformHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, D3DTRANSFORMSTATETYPE, UnsafeRef<global::Windows.Win32.Graphics.Direct3D.D3DMATRIX>, COM_HRESULT>
                _proc = &Hook_GetTransform;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetTransform(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, D3DTRANSFORMSTATETYPE State, UnsafeRef<global::Windows.Win32.Graphics.Direct3D.D3DMATRIX> pMatrix)
        {
            if (D3D9GetTransformHookItem.TryGet(out var hookItem))
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
